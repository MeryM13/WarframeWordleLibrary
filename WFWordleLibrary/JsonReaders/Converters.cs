using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFWordleLibrary.Model;

namespace WFWordleLibrary.JsonReaders
{
    public class Converters(WarframeWordleContext context)
    {
        WarframeWordleContext context = context;

        public int GetNumberOfExalteds(string WarframeName)
        {
            switch (WarframeName)
            {
                case "Excalibur":
                case "Mesa":
                case "Hildryn":
                case "Khora":
                case "Dante":
                case "Baruuk":
                case "Ivara":
                case "Valkyr":
                case "Wukong":
                    {
                        return 1;
                    }
                case "Titania":
                case "Sevagoth":
                    {
                        return 2;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public int GetConvertableProperty(KeyValuePair<string, JToken?> json, string propName)
        {
            switch (propName)
            {
                case "AuraPolarity":
                    {
                        var set = context.Polarities;
                        if (json.Value[propName] == null)
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        string value = json.Value[propName].ToString();
                        if (string.IsNullOrWhiteSpace(value))
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        return set.Where(p => p.PolarityName == value || p.PolarityLetter == value).FirstOrDefault().Id;
                    }
                case "Progenitor":
                    {
                        var set = context.Elements;
                        if (json.Value[propName] == null)
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        string value = json.Value[propName].ToString();
                        if (string.IsNullOrWhiteSpace(value))
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        return set.Where(x => x.ElementName == value).FirstOrDefault().Id;
                    }
                case "Introduced":
                    {
                        var set = context.GameUpdates;
                        if (json.Value[propName] == null)
                            return 1;
                        string value = json.Value[propName].ToString();
                        if (string.IsNullOrWhiteSpace(value) || value == "Vanilla")
                            return 1;
                        if (value == "TBA")
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        if (value.Contains("The Silver Grove"))
                            return 18;
                        return int.Parse(value.Split('.')[0]);
                    }
                case "Tactical":
                case "Subsumed":
                    {
                        if (json.Value[propName] == null)
                            return 0;
                        List<string> abilities = JsonConvert.DeserializeObject<List<string>>(json.Value["Abilities"].ToString());
                        string abilityName = json.Value[propName].ToString();
                        return abilities.IndexOf(abilityName) + 1;
                    }
                case "Sex":
                    {
                        var set = context.Genders;
                        if (json.Value[propName] == null)
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        string value = json.Value[propName].ToString();
                        if (string.IsNullOrWhiteSpace(value) || value.Contains("Non-binary"))
                            return set.OrderBy(x => x.Id).LastOrDefault().Id;
                        return set.Where(x => x.GenderName == value).FirstOrDefault().Id;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
