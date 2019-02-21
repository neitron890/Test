using Shop.ShopEntities.Purchasers;
using Shop.ShopEntities.ShopCard;

namespace Shop.ShopEntities.Shop
{
    public class ShopCardModel
    {       
        private readonly ShopCardData _shopCardData;
        private readonly IPurchaser _purchaser;
    
        public ShopCardModel(IPurchaser purchaser, ShopCardData shopLotData)
        {
            _shopCardData = shopLotData;
            _purchaser = purchaser;
        }

        public void RequestCardPurchasing()
        {     
            if (_shopCardData.price.Length > 0)
                _purchaser.BuyProductID(_shopCardData.cardName);
        
            _shopCardData.PurchaseState = ECardState.Requested;
            _shopCardData.NotifyThatDataChanged();
        }
    }
}
