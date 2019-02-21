using Newtonsoft.Json;
using UnityEngine;

namespace Shop
{
    public class PriceData
    {
        public const string INAPP_RESOURCE_TYPE = "inapp";
        public const string GOLD_RESOURCE_TYPE = "gold";
        public const string CHIPS_RESOURCE_TYPE = "chips";
        
        public string resourceId;  
        public decimal amount;
        public string valute;
        public string resourceType;
                
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Texture2D Texture;
    }

    public struct PriceViewModel
    {
        public Texture2D Texture2D;
        public int Value;
        public string Valute;
    }
}

