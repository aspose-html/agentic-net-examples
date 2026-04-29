// Process a folder of HTML files, validate each, and output individual JSON reports to a target directory.

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                string jsonPath = Path.Combine(outputFolder, fileName + ".json");
                var report = new Dictionary<string, object>();
                try
                {
                    using (HTMLDocument doc = new HTMLDocument(htmlPath))
                    {
                        bool hasBody = doc.Body != null;
                        report["valid"] = hasBody;
                        report["message"] = hasBody ? "Valid HTML" : "Missing body element";
                    }
                }
                catch (Exception ex)
                {
                    report["valid"] = false;
                    report["message"] = ex.Message;
                }
                string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonPath, json);
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }
}