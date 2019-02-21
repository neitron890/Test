namespace Shop.ShopEntities.Shop
{
    public enum EShopState
    {
        FullView,
        ShortView,
        Disabled,
    }

    public class ShopModel
    {  
        private ShopData _data;
    
        public ShopModel(ShopData data)
        {
            _data = data;
        }  

        public void ChangeState(EShopState state)
        {
            if (_data.State == EShopState.Disabled)        
                state = EShopState.ShortView;            
       
            _data.SetState(state);
            _data.NotifyThatDataChanged();
        }        
    }
}