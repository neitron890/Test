using System;
using Newtonsoft.Json;
using Reward;
using UnityEngine;

namespace Shop.ShopEntities.ShopCard
{
    public enum EOfferSize
    {
        Big,
        Small
    }

    public enum ESpendingResource
    {
        Real,
        Hard,
        Soft
    }

    public enum ECardState
    {
        Requested,
        Buyed,
        Taked
    }

    [Serializable]
    public class ShopCardData
    {   
        public event Action<ShopCardData> DataChanged = data => {};
        public event Action<ECardState> PurchaseStateChanged = purchaseState => {};
    
        public int id;
        public string cardName;
        public bool isBigSize;
        public bool isInfoLabel;
        public string title;
        public global::Shop.PriceData[] price;
        public string decorationId;
        public RewardData[] rewards;
        public string inGroup;
        public string openGroup;
        public int order;

        public void NotifyThatDataChanged()
        {
            DataChanged(this);
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Enabled = true;
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Sprite Sprite;
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ECardState PurchaseState;
    }
}