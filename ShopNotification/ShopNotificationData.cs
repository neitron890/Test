using System;

public class ShopNotificationData
{
    public event Action<ChangedShopNotificationData> Changed = notificationCount => {};
    public int NotificationCount;
    public bool Enabled = false;

    public void NotifyThatDataChanged()
    {
        Changed(new ChangedShopNotificationData(this));
    }
}

public struct ChangedShopNotificationData
{
    public int NotificationCount;
    public bool Enabled;
    
    public ChangedShopNotificationData(ShopNotificationData shopNotificationData)
    {
        NotificationCount = shopNotificationData.NotificationCount;
        Enabled = shopNotificationData.Enabled;
    }
}
