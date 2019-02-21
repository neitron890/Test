using Assets.Scripts.CustomData;
using Reward;

public interface IRewardGetter
{
    void GetReward(RewardData rewardData);
}

public class RewardGetter : IRewardGetter
{
    private readonly ICustomData _customData;
    
    public RewardGetter(ICustomData customData)
    {
        _customData = customData;                
    }

    public void GetReward(RewardData rewardData)
    {
        if (rewardData.rewardType == RewardBase.Chips)
            _customData.AddChips(rewardData.amount);
        
        if (rewardData.rewardType == RewardBase.Gold)
            _customData.AddGold((int)rewardData.amount);

        if (rewardData.rewardType == RewardBase.Sticker)
        {
            var stiker = GameLayer.I.CustomData.BalanceData.stickers.Find(s => s.id == rewardData.rewardId);
            _customData.AvailableStickers.Add(stiker);
        }        
        if (rewardData.rewardType == RewardBase.Lootbox)
        {        
            
        }
    }
}
