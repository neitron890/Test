using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.ShopEntities.ShopCard
{
    public class ShopCardView : MonoBehaviour
    {
        public TextMeshProUGUI Title;
        public Image Back;
        public Button BuyButton;
        public Button InfoButton;
        public Image Icon;
        public TextMeshProUGUI CoastByReal;
        public TextMeshProUGUI CoastBySoft;
        public GameObject CoastByRealGO;
        public GameObject CoastBySoftGO;
        public Image SoftCoastIcon;

        public void DataChanged(ShopCardViewModel viewModel)
        {
            gameObject.SetActive(viewModel.Enabled);
        
            Color color;
            if (ColorUtility.TryParseHtmlString("#" + viewModel.BackColor, out color))            
                Back.color = color;

            foreach (PriceViewModel priceViewModel in viewModel.PriceViewModel)    
                if (priceViewModel.Valute == null)
                {
                    // var priceIconRect = new Rect(0,0, priceViewModel.SpendingResourceTexture.width, 
                    //     priceViewModel.SpendingResourceTexture.height);
                    // var priceIcon = Sprite.Create(priceViewModel.SpendingResourceTexture, priceIconRect, Vector2.zero);
                    // SoftCoastIcon.sprite = priceIcon;
                    CoastBySoft.text = priceViewModel.Value.ToString();
                    CoastByRealGO.SetActive(false);
                    CoastBySoftGO.SetActive(true);
                }
                else
                {
                    CoastByReal.text = priceViewModel.Valute;
                    CoastByRealGO.SetActive(true);
                    CoastBySoftGO.SetActive(false);
                }

            Icon.sprite = viewModel.Sprite;        
            Title.text = viewModel.Title;        
            InfoButton.gameObject.SetActive(viewModel.IsInfoLabel);
        }
    }
}
