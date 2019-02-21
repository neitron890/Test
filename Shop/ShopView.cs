using UnityEngine;
using UnityEngine.UI;

namespace Shop.ShopEntities.Shop
{
    public class ShopView : MonoBehaviour
    {   
        public ContentSizeFitter ScrollContentSizeFitter;
        public Button OpenButton;
        public Button CloseButton;

        private ShopModel _shopModel;

        public void Bind()
        {
            CloseButton.onClick.AddListener(() =>
           
                _shopModel.ChangeState(EShopState.Disabled));            
        
            OpenButton.onClick.AddListener(() =>
                _shopModel.ChangeState(EShopState.ShortView));
        }

        public void SetModel(ShopModel shopModel)
        {
            _shopModel = shopModel;
        }

        public void ShopDataChanged(ShopData shopData)
        {
            if (shopData.State == EShopState.FullView)
            {
                gameObject.SetActive(true);
                ScrollContentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
                ScrollContentSizeFitter.enabled = false;
                Canvas.ForceUpdateCanvases();            
                ScrollContentSizeFitter.enabled = true;
            }        
            else if (shopData.State == EShopState.ShortView)
            {
                gameObject.SetActive(true);    
                ScrollContentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
                ScrollContentSizeFitter.enabled = false;
                Canvas.ForceUpdateCanvases();            
                ScrollContentSizeFitter.enabled = true;
            }
            else if (shopData.State == EShopState.Disabled)        
                gameObject.SetActive(false);             
        }
    }
}
