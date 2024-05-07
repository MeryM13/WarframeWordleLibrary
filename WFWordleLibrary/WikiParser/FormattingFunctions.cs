using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFWordleLibrary.WikiParser
{
    public class FormattingFunctions
    {
        const string NewLine = "\n";
        const string Tab = "\t";
        const string Quote = "\"";
        const string Space = " ";
        const string DoubleSpace = "  ";
        const string DoubleQuote = "\"\"";

        public static void DeleteLines(ref string input, string[] propsToDelete)
        {
            foreach (var prop in propsToDelete)
            {
                while (input.Contains($"{prop}"))
                {
                    int start = input.IndexOf($"{prop}");
                    int end = input.IndexOf(NewLine, start) + 1;
                    input = input.Remove(start, end - start);
                }
            }
        }

        public static void RemoveBlanks(ref string input)
        {
            input = input.Replace(Tab, Space); //replaces tab with space
            while (input.Contains(DoubleSpace))
            {
                input = input.Replace(DoubleSpace, Space); //replaces double spaces with singular ones
            }
        }

        public static void AddQuotes(ref string input)
        {
            input = input
            .Replace("&quot;", Quote) //replaces text with actual quotes
                .Replace(" &amp; ", "&") //replaces text with actual &
            .Replace(" =", Quote + ":") //replaces ' =' with ':' and adds closing quote for keys 
            .Replace(",\n ", ",\n " + Quote) //adds opening quote for keys in children elements
            .Replace("{\n", "{ " + Quote) //adds opening quote for keys in main elements
            .Replace(Quote + "},", "},"); //removes wrongfully placed quotes on the ends of main elements
        }

        public static void BracketsCorrection(ref string input)
        {
            input = input
                .Replace("\" ", Quote)
                .Replace("\"\n },", " },") //retracts object closing brackets (for proper work of DeleteLines method)
                .Replace("\"[\"", Quote).Replace("\"]\"", Quote) //puts complex names in quotes instead of brackets
            .Replace("\"['", Quote).Replace("']\"", Quote); //because Gauss decided to be fucking quirky
        }

        public static void ConvertObjectToList(ref string input, string[] propsToConvert)
        {
            foreach (string prop in propsToConvert)
            {
                input = input.Replace(Quote + prop + "\": {", Quote + prop + "\": [");
            }
            input = input
                .Replace("\"},", "\" ],") //replaces object brackets with list brackets
            .Replace("[ }", "[ ]");
        }

        public static void FormattingCoorrection(ref string input)
        {
            input = input
                .Replace("\"}", "}")
                .Replace(",\n },", " },")
                .Replace(DoubleQuote, Quote);
        }
    }
}
