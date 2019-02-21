
public struct ShopNotificationViewData
{
    public int FreeLootBoxesCount;
    public bool Enabled;
    
    public ShopNotificationViewData(ChangedShopNotificationData changedShopNotificationData)
    {
        FreeLootBoxesCount = changedShopNotificationData.NotificationCount;
        Enabled = changedShopNotificationData.Enabled;
    }  
}
