using System;

namespace Shop.ShopEntities.Purchasers
{
    public class InGameOfferPurchaser : IPurchaser
    {
        private IRewardGetter _rewardGetter;

        public InGameOfferPurchaser(IRewardGetter rewardGetter)
        {
            _rewardGetter = rewardGetter;
        }

        public void BuyProductID(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
