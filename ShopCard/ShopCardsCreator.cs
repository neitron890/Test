using System.Linq;
using Shop.ShopEntities.Purchasers;
using Shop.ShopEntities.Shop;
using UnityEngine;


namespace Shop.ShopEntities.ShopCard
{
    public class ShopCardsCreator
    {
        public static void Create(ICustomData customData, SFSX2Manager sfsx2Manager, 
            ViewElementsSpawnData viewElementsSpawnData)
        {
            var rewardGetter = new RewardGetter(customData);
            
            var realOfferPurchaser = new RealOfferPurchaser(customData.BalanceData.ShopCards, 
                customData.BalanceData.ShopInApps, rewardGetter, sfsx2Manager);                            
            var inGameOfferPurchaser = new InGameOfferPurchaser(rewardGetter);
            
            customData.BalanceData.ShopCards.ForEach(shopCardData =>
            {                     
                var cardPurchaser = shopCardData.price.Any(x => x.resourceType == global::Shop.PriceData.INAPP_RESOURCE_TYPE)
                    ? (IPurchaser)realOfferPurchaser
                    : inGameOfferPurchaser;
                
                var shopCardModel = new ShopCardModel(cardPurchaser, shopCardData);                                
                
                var offersSpawnInfo =
                    viewElementsSpawnData.GetSpawnInfo(shopCardData.isBigSize ? "big_offers" : "small_offers");
                shopCardData.Sprite = Resources.Load<Sprite>("Shop/Textures/" + shopCardData.decorationId);                
                var shopCardPrefab = Resources.Load<GameObject>("Shop/shop_card");
                var shopCardPrefabGameobject = GameObject.Instantiate(shopCardPrefab,
                    offersSpawnInfo.LocalPosition,
                    offersSpawnInfo.Rotation,
                    offersSpawnInfo.Parent);
                var shopCardView = shopCardPrefabGameobject.GetComponent<ShopCardView>();

                shopCardData.DataChanged += changedData => 
                    shopCardView.DataChanged(new ShopCardViewModel(changedData));
                shopCardData.NotifyThatDataChanged();
            
                shopCardView.BuyButton.onClick.AddListener(() =>
                    shopCardModel.RequestCardPurchasing());
            });                       
        }
    }
}

