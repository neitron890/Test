using UnityEngine;

namespace Shop.ShopEntities.ShopCard
{
    public struct PriceViewModel
    {
        public PriceViewModel(global::Shop.PriceData priceData)
        {
            SpendingResourceTexture = priceData.Texture;
            Value = (float)priceData.amount;
            Valute = priceData.valute;
        }

        public Texture2D SpendingResourceTexture;
        public float Value;
        public string Valute;
    }
}
