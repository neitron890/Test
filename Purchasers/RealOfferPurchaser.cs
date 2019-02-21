using System;
using System.Collections.Generic;
using System.Linq;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Shop.ShopEntities.ShopCard;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Shop.ShopEntities.Purchasers
{
    public class RealOfferPurchaser : IStoreListener,  IPurchaser
    {
        private static IStoreController _storeController;
        private readonly List<ShopCardData> _shopCardDatas;
        private readonly List<ShopInApp> _shopInApps;
        private SFSX2Manager _sfsx2Manager;
        private IRewardGetter _rewardGetter;
        
        private readonly Dictionary<string, string> _shopcardIdToStoreSkUs = 
            new Dictionary<string, string>();
        private readonly Dictionary<string, int> _storeSkUsToShopcardId = 
            new Dictionary<string, int>();
    
        public RealOfferPurchaser(List<ShopCardData> shopCardDatas, 
            List<ShopInApp> shopInApps, IRewardGetter rewardGetter, 
            SFSX2Manager sfsx2Manager)
        {
            _shopCardDatas = shopCardDatas;
            _shopInApps = shopInApps;
            _sfsx2Manager = sfsx2Manager;
            _rewardGetter = rewardGetter;                    
        
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());   
            
            _shopInApps.ForEach(realInApp =>                                    
                builder.AddProduct(realInApp.inappName, ProductType.Consumable, new IDs
                {
                    {realInApp.inappName, GooglePlay.Name},
                    {realInApp.inappName, AppleAppStore.Name},
                }));
        
            UnityPurchasing.Initialize(this, builder);
        }
    
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;

            UpdatePriceInShopCards();
        }

        private void UpdatePriceInShopCards()
        {
             foreach (ShopCardData shopCardData in _shopCardDatas)        
                 foreach (var price in shopCardData.price)            
                     if (price.resourceType == global::Shop.PriceData.INAPP_RESOURCE_TYPE)
                     {                    
                         var shopInApp = _shopInApps.FirstOrDefault(x => x.inappId == price.resourceId);
                         
                         if (shopInApp != null)
                         {                                               
                             Product product = _storeController.products.all.FirstOrDefault(y => 
                                 y.definition.storeSpecificId == shopInApp.inappName);
                             
                             if (product != null)
                             {                                       
                                 _shopcardIdToStoreSkUs[shopCardData.cardName] = shopInApp.inappName;
                                 _storeSkUsToShopcardId[shopInApp.inappName] = shopCardData.id;                                                                         
                                 
                                 shopCardData.price[0].amount = product.metadata.localizedPrice;
                                 shopCardData.price[0].valute = product.metadata.localizedPriceString;
                                 shopCardData.NotifyThatDataChanged();
                             }
                         }
                     }  
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }

        public void BuyProductID(string iapID)
        {
            if (_storeController == null)
            {
                Debug.Log("BuyProductID FAIL. Not initialized."); 
                return;
            }       
        
            string sku;
            if (!_shopcardIdToStoreSkUs.TryGetValue(iapID, out sku))
            {
                Debug.LogError("Product with iapID: " + iapID + " is not found in real purchasing. " +
                               "Check ShopInApps data arrived from server. " +
                               "Or default values in ShopInApp.cs");
                return;
            }
        
            try
            {                                  
                Product product = _storeController.products.WithID(sku);           
            
                Debug.Log("ProcessPurchase");

                if (product != null && product.availableToPurchase)
                {
                    _storeController.InitiatePurchase(product);
                    Debug.Log("InitiatePurchase");
                }                                                         
                else                    
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");                                                           
            }
            catch (Exception e)
            {
                Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
            }
        }           

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {              
            int cardId;
            if (!_storeSkUsToShopcardId.TryGetValue(args.purchasedProduct.definition.storeSpecificId, out cardId))
            {
                Debug.LogError("Card with id: " + cardId + " is not found in shop cards. " +
                               "Check shop card data arrived from server.");
            
                return PurchaseProcessingResult.Pending;
            }
        
            var toObject = new SFSObject();
            toObject.PutUtfString("storeType",
                Application.platform == RuntimePlatform.Android ? "GOOGLE_PLAY"
                : Application.platform == RuntimePlatform.IPhonePlayer ? "APP_STORE": String.Empty);            
            toObject.PutInt("shopCardId", cardId);
            toObject.PutUtfString("receiptId", args.purchasedProduct.receipt);
        
            var request = new ExtensionRequest("shopTestBuy", toObject);
            _sfsx2Manager.GetSfs().Send(request); 
            _sfsx2Manager.GetSfs().AddEventListener("purchaseTestBuy", eventArgs =>
            {
                if (eventArgs.Params.Contains("result"))                                
                    if ((int)eventArgs.Params["result"] == 0)
                        _storeController.ConfirmPendingPurchase(args.purchasedProduct);                                                
            });                

            return PurchaseProcessingResult.Pending;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }  
    }
}
