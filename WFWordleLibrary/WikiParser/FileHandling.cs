using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFWordleLibrary.WikiParser
{
    public class FileHandling
    {
        public static HtmlDocument? GetHtmlDocument(string url)
        {
            HtmlWeb web = new();
            return web.Load(url);
        }

        public static void CreateJsonDocument(string path, string content)
        {
            try
            {
                using FileStream fs = File.Create(path);
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static JObject LoadJson(string path)
        {
            return JObject.Parse(File.ReadAllText(path));
        }
    }
}
