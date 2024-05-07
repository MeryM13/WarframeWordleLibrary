using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFWordleLibrary.WikiParser
{
    public class WikiParsers
    {
        public static void ParseWarframeWikiToJson()
        {
            var doc = FileHandling.GetHtmlDocument(PathsDictionary.Paths["WarframeWiki"]);

            string result = doc.DocumentNode
                  .SelectSingleNode(@"/html/body/div[4]/div[4]/div[3]/main/div[3]/div/div[1]/pre")
                  .InnerText;

            result = "{\n" + result[result.IndexOf("Ash")..];

            FormattingFunctions.DeleteLines(ref result, ["Type", "Conclave", "Themes", "CodexSecret",
                "InitialEnergy", "InternalName", "MaxRank",
                "SellPrice", "SquadPortrait", "Vaulted", "CompatibilityTags", "AdditionalNotes"]);

            FormattingFunctions.RemoveBlanks(ref result);

            FormattingFunctions.AddQuotes(ref result);

            FormattingFunctions.DeleteLines(ref result, ["FullImages", "Portrait"]);

            FormattingFunctions.BracketsCorrection(ref result);

            FormattingFunctions.ConvertObjectToList(ref result, ["Abilities", "Polarities"]);

            FormattingFunctions.FormattingCoorrection(ref result);

            FormattingFunctions.DeleteLines(ref result, ["\"Day\"", "\"Night\"", "\"Heal\"", "\"Protect\""]);

            result = result
                .Replace(": \",", ": \"\",")
                .Replace("\n Caliban", "\n \"Caliban")
                .Replace("]= ", ": ")
                .Replace(",\n }", "");

            FileHandling.CreateJsonDocument(PathsDictionary.Paths["WarframeJson"], result);
        }
    }
}
