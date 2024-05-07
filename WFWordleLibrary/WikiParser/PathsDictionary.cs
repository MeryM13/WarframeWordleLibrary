using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFWordleLibrary.WikiParser
{
    public class PathsDictionary
    {
        public static Dictionary<string, string> Paths = new()
        {
            { "WarframeWiki", @"https://warframe.fandom.com/wiki/Module:Warframes/data" },
            { "WarframeJson", @"..\..\..\Jsons\WarframeWikiJson.json" }
        };
    }
}
