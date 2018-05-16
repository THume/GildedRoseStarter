using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        const int maxQuality = 50;
        const int minQuality = 0;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name.Contains("Sulfuras")) continue;

                item.SellIn = item.SellIn - 1;
                if (item.Name.Contains("Aged Brie"))
                {
                    item.Quality = item.Quality < maxQuality ? item.Quality + 1 : 50;
                    continue;
                }

                if (item.Name.Contains("Backstage passes"))
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        int increment = 1;
                        if (item.SellIn < 6)
                        {
                            increment = 3;
                        }
                        else if (item.SellIn < 11)
                        {
                            increment = 2;
                        }
                        item.Quality = item.Quality + increment <= maxQuality ? item.Quality + increment : 50;
                    }
                    continue;
                }

                int depreciate = 1;
                if (item.Name.Contains("Conjured"))
                {
                    depreciate = 2;
                }

                if (item.SellIn < 0) depreciate = depreciate * 2;
                item.Quality = item.Quality - depreciate >= minQuality ? item.Quality - depreciate : 0;
            }
        }
    }
}
