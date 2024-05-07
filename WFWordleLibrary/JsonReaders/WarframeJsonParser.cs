using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFWordleLibrary.Model;
using WFWordleLibrary.Model.Database;
using WFWordleLibrary.WikiParser;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WFWordleLibrary.JsonReaders
{
    public class WarframeJsonParser(WarframeWordleContext context)
    {
        WarframeWordleContext context = context;

        public List<Warframe> ParseWarframeList()
        {
            JObject details = FileHandling.LoadJson(PathsDictionary.Paths["WarframeJson"]);
            Converters conv = new(context);
            List<Warframe> result = new();
            foreach (var item in details)
            {
                if (item.Key.Contains("Prime"))
                {
                    string frame = item.Key.Split(' ')[0];
                    result.Where(x => x.Name.Contains(frame)).FirstOrDefault().HasPrime = true;
                    continue;
                }

                if (item.Key.Contains("Shadow") || item.Key.Contains("Umbra"))
                    continue;

                Warframe warframe = new()
                {
                    Name = item.Value["Name"].ToString(),
                    Description = item.Value["Description"].ToString(),
                    Gender = conv.GetConvertableProperty(item, "Sex"),
                    HasExalteds = conv.GetNumberOfExalteds(item.Value["Name"].ToString()),
                    ReleasedInUpdate = conv.GetConvertableProperty(item, "Introduced"),
                    Health = int.Parse(item.Value["Health"].ToString()),
                    Shields = int.Parse(item.Value["Shield"].ToString()),
                    Energy = int.Parse(item.Value["Energy"].ToString()),
                    Armor = int.Parse(item.Value["Armor"].ToString()),
                    SprintSpeed = decimal.Parse(item.Value["Sprint"].ToString().Replace('.', ',')),
                    SubsumedAbility = conv.GetConvertableProperty(item, "Subsumed"),
                    TacticalAbility = conv.GetConvertableProperty(item, "Tactical"),
                    AuraPolarity = conv.GetConvertableProperty(item, "AuraPolarity"),
                    ProgenitorElement = conv.GetConvertableProperty(item, "Progenitor")
                };
                result.Add(warframe);
            }
            result = result.OrderBy(x => x.ReleasedInUpdate).ToList();
            return result;
        }
    }
}
