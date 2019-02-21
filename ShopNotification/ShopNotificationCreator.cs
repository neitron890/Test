using System.Collections.Generic;
using System.Linq;
using Shop.ShopEntities.ShopCard;
using UnityEngine;

public class ShopNotificationCreator
{
    public static void Create(List<ShopCardData> shopCardDatas)
    {
        var notificationData = new ShopNotificationData();
        var shopNotificationModel = new ShopNotificationModel(shopCardDatas, notificationData);
        var shopNotificationView = Object.FindObjectOfType<ShopNotificationView>();                                      
        
        notificationData.Changed += (changedData) =>
            shopNotificationView.DataChanged(new ShopNotificationViewData(changedData));  
        notificationData.NotifyThatDataChanged();      
    }
}
