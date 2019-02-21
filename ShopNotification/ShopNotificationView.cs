using TMPro;
using UnityEngine;

public class ShopNotificationView : MonoBehaviour
{
    public TextMeshProUGUI NotificationText;

    public void DataChanged(ShopNotificationViewData shopNotificationViewData)
    {        
        gameObject.SetActive(shopNotificationViewData.Enabled);

        NotificationText.text = shopNotificationViewData.FreeLootBoxesCount.ToString();
    }
}
