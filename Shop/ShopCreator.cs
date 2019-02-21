using Shop.ShopEntities.ShopCard;
using UnityEngine;

namespace Shop.ShopEntities.Shop
{
    public class ShopCreator
    {
        public static void Create(SFSX2Manager sfsx2Manager)
        {
            var customData = GameLayer.I.CustomData;
        
            customData.BalanceChanged += () =>
            {
                var shopCardsStateSwitcher = new ShopCardStateSwitcher(customData.BalanceData.ShopCards);
                var shopData = new ShopData(shopCardsStateSwitcher);
                var shopModel = new ShopModel(shopData);
                var shopView = Object.FindObjectOfType<ShopView>();
                shopView.SetModel(shopModel);
                shopView.Bind();           
                shopData.DataChanged += data => shopView.ShopDataChanged(shopData);
                shopData.NotifyThatDataChanged();

                ShopNotificationCreator.Create(customData.BalanceData.ShopCards);  
            
                var viewElementsSpawnData = shopView.GetComponent<ViewElementsSpawnData>(); // it's not right, spawning element must be by info recieved from server 
                ShopCardsCreator.Create(customData, sfsx2Manager, viewElementsSpawnData);         
                                  
            };
        }
    }
}
