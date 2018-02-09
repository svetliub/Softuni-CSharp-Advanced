using System;
using System.Collections.Generic;
using System.Linq;

namespace p03_GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            var items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, Dictionary<string, long>> bagOfWealth = new Dictionary<string, Dictionary<string, long>>();

            long cashAmount = 0;
            long goldAmount = 0;
            long gemAmount = 0;
            long bagAmount = 0;

            for (int i = 0; i < items.Count; i += 2)
            {
                string item = items[i];
                long itemAmount = long.Parse(items[i + 1]);

                if (bagAmount + itemAmount > bagCapacity)
                {
                    continue;
                }

                if (item.ToLower() == "gold")
                {
                    if (!bagOfWealth.ContainsKey(item))
                    {
                        bagOfWealth.Add(item, new Dictionary<string, long>());
                        bagOfWealth[item].Add(item, 0);
                    }

                    bagOfWealth["Gold"]["Gold"] += itemAmount;
                    goldAmount += itemAmount;
                }
                else if (item.ToLower().EndsWith("gem") && (gemAmount + itemAmount) <= goldAmount && item.Length >= 4)
                {
                    if (!bagOfWealth.ContainsKey("Gem"))
                    {
                        bagOfWealth.Add("Gem", new Dictionary<string, long>());
                    }

                    if (!bagOfWealth["Gem"].ContainsKey(item))
                    {
                        bagOfWealth["Gem"].Add(item, 0);
                    }

                    bagOfWealth["Gem"][item] += itemAmount;
                    gemAmount += itemAmount;
                }
                else if (item.Length == 3 && (cashAmount + itemAmount) <= gemAmount)
                {
                    if (!bagOfWealth.ContainsKey("Cash"))
                    {
                        bagOfWealth.Add("Cash", new Dictionary<string, long>());
                    }

                    if (!bagOfWealth["Cash"].ContainsKey(item))
                    {
                        bagOfWealth["Cash"].Add(item, 0);
                    }

                    bagOfWealth["Cash"][item] += itemAmount;
                    cashAmount += itemAmount;
                }

                bagAmount += itemAmount;
            }

            foreach (var item in bagOfWealth.OrderByDescending(k => k.Value.Values.Sum()))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Sum(g => g.Value)}");
                foreach (var pair in item.Value.OrderByDescending(k => k.Key))
                {
                    Console.WriteLine($"##{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}
