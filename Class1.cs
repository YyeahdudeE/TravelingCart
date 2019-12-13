using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using System;
using System.Collections.Generic;

namespace TravelingCart
{
  public class  ModEntry : Mod
  {
    public override void Entry(IModHelper helper)
    {
        Helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
    }

        private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            ModConfig config = this.Helper.ReadConfig<ModConfig>();

            int num = new Random().Next(0, 100);

            Forest forest = (Forest)Game1.getLocationFromName("Forest");
            if (((Game1.dayOfMonth == 1 || Game1.dayOfMonth == 8 || Game1.dayOfMonth == 15 || Game1.dayOfMonth == 22) && config.Monday >= num) ||
                ((Game1.dayOfMonth == 2 || Game1.dayOfMonth == 9 || Game1.dayOfMonth == 16 || Game1.dayOfMonth == 23) && config.Tuesday >= num) ||
                ((Game1.dayOfMonth == 3 || Game1.dayOfMonth == 10 || Game1.dayOfMonth == 17 || Game1.dayOfMonth == 24) && config.Wednesday >= num) ||
                ((Game1.dayOfMonth == 4 || Game1.dayOfMonth == 11 || Game1.dayOfMonth == 18 || Game1.dayOfMonth == 25) && config.Thursday >= num) ||
                ((Game1.dayOfMonth == 5 || Game1.dayOfMonth == 12 || Game1.dayOfMonth == 19 || Game1.dayOfMonth == 26) && config.Friday >= num) ||
                ((Game1.dayOfMonth == 6 || Game1.dayOfMonth == 13 || Game1.dayOfMonth == 20 || Game1.dayOfMonth == 27) && config.Saturday >= num) ||
                ((Game1.dayOfMonth == 7 || Game1.dayOfMonth == 14 || Game1.dayOfMonth == 21 || Game1.dayOfMonth == 28) && config.Sunday >= num))
            {



                forest.travelingMerchantDay = true;
                forest.travelingMerchantBounds.Add(new Rectangle(23 * Game1.tileSize, 10 * Game1.tileSize, 123 * Game1.pixelZoom, 28 * Game1.pixelZoom));
                forest.travelingMerchantBounds.Add(new Rectangle(23 * Game1.tileSize + 45 * Game1.pixelZoom, 10 * Game1.tileSize + 26 * Game1.pixelZoom, 19 * Game1.pixelZoom, 12 * Game1.pixelZoom));
                forest.travelingMerchantBounds.Add(new Rectangle(23 * Game1.tileSize + 85 * Game1.pixelZoom, 10 * Game1.tileSize + 26 * Game1.pixelZoom, 26 * Game1.pixelZoom, 12 * Game1.pixelZoom));

                foreach (Rectangle travelingMerchantBound in forest.travelingMerchantBounds)
                    Utility.clearObjectsInArea(travelingMerchantBound, (GameLocation)forest);
            }
            else
            {
                forest.travelingMerchantBounds.Clear();
                forest.travelingMerchantDay = false;
            }
        }
  }

  class ModConfig
  {
        public int Monday { get; set; } = 20;
        public int Tuesday { get; set; } = 20;
        public int Wednesday { get; set; } = 20;
        public int Thursday { get; set; } = 20;
        public int Friday { get; set; } = 30;
        public int Saturday { get; set; } = 100;
        public int Sunday { get; set; } = 100;
   }
}
