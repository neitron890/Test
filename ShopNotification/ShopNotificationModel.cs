using System.Collections.Generic;
using Shop.ShopEntities.ShopCard;

public class ShopNotificationModel
{
    private ShopNotificationData _data;
   
    
    public ShopNotificationModel(List<ShopCardData> shopCardDatas, ShopNotificationData data)
    {
        _data = data;             
        
        shopCardDatas.ForEach(shopCard => 
        {
            shopCard.PurchaseStateChanged += (purchaseState) =>
            {
                var notificationCount = 0;
                for (var index = 0; index < shopCardDatas.Count; index++)
                {
                    ShopCardData x = shopCardDatas[index];
                    var all = true;
                    for (var i = 0; i < x.price.Length; i++)
                    {
                        Shop.PriceData price = x.price[i];
                        if (price.amount != 0)
                        {
                            all = false;
                            break;
                        }
                    }

                    if (all && purchaseState == ECardState.Taked)
                        notificationCount++;
                }

                _data.NotificationCount = notificationCount;  
                _data.NotifyThatDataChanged();
            };                       
        });         
    }                  
}
