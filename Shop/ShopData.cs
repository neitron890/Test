using System;
using Shop.ShopEntities.ShopCard;

namespace Shop.ShopEntities.Shop
{
    public class ShopData
    {
        public event Action<ShopData> DataChanged = data => {};

        public EShopState State { get; private set; } = EShopState.Disabled;

        private readonly ShopCardStateSwitcher _shopCardStateSwitcher;
    
        public ShopData(ShopCardStateSwitcher shopCardStateSwitcher)
        {
            _shopCardStateSwitcher = shopCardStateSwitcher;
        }

        public void SetState(EShopState state)
        {        
            _shopCardStateSwitcher.Switch(state);
            State = state;                           
        }

        public void NotifyThatDataChanged()
        {
            DataChanged(this);
        }
    }
}
