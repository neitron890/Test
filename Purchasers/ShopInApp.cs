using System.Collections.Generic;

namespace Shop.ShopEntities.Purchasers
{
    public class ShopInApp
    {
        public string inappId;
        public string inappName;


        public static List<ShopInApp> GetDefault()
        {
            return new List<ShopInApp>
            {
                new ShopInApp
                {
                    inappId = "iap00010",
                    inappName = "chips_1"
                },
                new ShopInApp
                {
                    inappId = "iap00020",
                    inappName = "chips_2"
                },
                new ShopInApp
                {
                    inappId = "iap00030",
                    inappName = "chips_5"
                },
                new ShopInApp
                {
                    inappId = "iap00040",
                    inappName = "chips_10"
                },
                new ShopInApp
                {
                    inappId = "iap00050",
                    inappName = "chips_20"
                },
                new ShopInApp
                {
                    inappId = "iap00060",
                    inappName = "chips_50"
                },
                new ShopInApp
                {
                    inappId = "iap00070",
                    inappName = "chips_100"
                },

                new ShopInApp
                {
                    inappId = "iap01010",
                    inappName = "gold_1"
                },
                new ShopInApp
                {
                    inappId = "iap01020",
                    inappName = "gold_2"
                },
                new ShopInApp
                {
                    inappId = "iap01030",
                    inappName = "gold_5"
                },
                new ShopInApp
                {
                    inappId = "iap01040",
                    inappName = "gold_10"
                },
                new ShopInApp
                {
                    inappId = "iap01050",
                    inappName = "gold_20"
                },
                new ShopInApp
                {
                    inappId = "iap01060",
                    inappName = "gold_50"
                },
                new ShopInApp
                {
                    inappId = "iap01070",
                    inappName = "gold_100"
                },
                new ShopInApp
                {
                    inappId = "iap05010",
                    inappName = "action_1"
                },
                new ShopInApp
                {
                    inappId = "iap05020",
                    inappName = "action_2"
                },
                new ShopInApp
                {
                    inappId = "iap05030",
                    inappName = "action_5"
                },
                new ShopInApp
                {
                    inappId = "iap05040",
                    inappName = "action_10"
                },
                new ShopInApp
                {
                    inappId = "iap05050",
                    inappName = "action_20"
                },
                new ShopInApp
                {
                    inappId = "iap05060",
                    inappName = "action_50"
                },
                new ShopInApp
                {
                    inappId = "iap05070",
                    inappName = "action_100"
                }
            };
        }
    }
}

