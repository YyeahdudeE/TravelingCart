using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using System;
using System.Collections.Generic;

namespace TravelingCart
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
        }

        private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            ModConfig config = this.Helper.ReadConfig<ModConfig>();

            int rand = new Random().Next(1, 100);
            int day = Game1.dayOfMonth;

            Forest forest = (Forest)Game1.getLocationFromName("Forest");

            if (forest is null) { return; }
            if (((day == 1 || day == 8 || day == 15 || day == 22) && config.Monday >= rand) ||
                ((day == 2 || day == 9 || day == 16 || day == 23) && config.Tuesday >= rand) ||
                ((day == 3 || day == 10 || day == 17 || day == 24) && config.Wednesday >= rand) ||
                ((day == 4 || day == 11 || day == 18 || day == 25) && config.Thursday >= rand) ||
                ((day == 5 || day == 12 || day == 19 || day == 26) && config.Friday >= rand) ||
                ((day == 6 || day == 13 || day == 20 || day == 27) && config.Saturday >= rand) ||
                ((day == 7 || day == 14 || day == 21 || day == 28) && config.Sunday >= rand))
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
        public int Monday { get; set; } = 0;
        public int Tuesday { get; set; } = 0;
        public int Wednesday { get; set; } = 0;
        public int Thursday { get; set; } = 0;
        public int Friday { get; set; } = 0;
        public int Saturday { get; set; } = 100;
        public int Sunday { get; set; } = 100;
    }
}
