using System.Collections.Generic;
using Shop.ShopEntities.Shop;

namespace Shop.ShopEntities.ShopCard
{
   public class ShopCardStateSwitcher
   {
      private List<ShopCardData> _shopCardDatas;

      public ShopCardStateSwitcher(List<ShopCardData> shopCardDatas)
      {
         _shopCardDatas = shopCardDatas;
      }

      public void Switch(EShopState state)
      {
         if (state == EShopState.ShortView)        
         {      
            var showedCard = 0;
            _shopCardDatas.ForEach(shopLotData =>
            {
               bool condition = showedCard < 2 && shopLotData.isBigSize|| 
                                showedCard < 5 && !shopLotData.isBigSize;                
               shopLotData.Enabled = condition;
            
               if (shopLotData.Enabled)
                  showedCard++;
            
               shopLotData.NotifyThatDataChanged();
            });         
         }
         else if (state == EShopState.FullView)          
            _shopCardDatas.ForEach(shopLotData =>
            {
               shopLotData.Enabled = true;
               shopLotData.NotifyThatDataChanged();
            });     
      }
   }
}
