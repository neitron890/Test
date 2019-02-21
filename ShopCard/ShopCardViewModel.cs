using System.Linq;
using UnityEngine;

namespace Shop.ShopEntities.ShopCard
{
    public struct ShopCardViewModel
    {
        public ShopCardViewModel(ShopCardData cardData)
        {
            IsInfoLabel = cardData.isInfoLabel;
            Title = GameLayer.I.Localization.GetString(cardData.title);
            PriceViewModel = cardData.price.Select(x => new PriceViewModel(x)).ToArray();
            Sprite = cardData.Sprite;
            BackColor = Random.ColorHSV(0,1).ToString();
            Enabled = cardData.Enabled;
        }

        public bool Enabled;
        public bool IsInfoLabel;
        public string Title;
        public PriceViewModel[] PriceViewModel;
        public Sprite Sprite;
        public string BackColor;
    }
}
