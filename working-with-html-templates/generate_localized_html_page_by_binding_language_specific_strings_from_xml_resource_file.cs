// Generate a localized HTML page by binding language‑specific strings from an XML resource file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string xmlPath = "resources.xml";
            string htmlTemplatePath = "template.html";
            string outputPath = "localized.html";

            // Create a minimal XML resource file if it does not exist
            if (!System.IO.File.Exists(xmlPath))
            {
                string xmlContent = "<resources><string name=\"title\">Hello World</string><string name=\"welcome\">Welcome to our site</string></resources>";
                System.IO.File.WriteAllText(xmlPath, xmlContent);
            }

            // Create a minimal HTML template with placeholders if it does not exist
            if (!System.IO.File.Exists(htmlTemplatePath))
            {
                string htmlTemplate = "<html><head><title>{{title}}</title></head><body><h1>{{welcome}}</h1></body></html>";
                System.IO.File.WriteAllText(htmlTemplatePath, htmlTemplate);
            }

            // Load XML resource strings
            var xdoc = System.Xml.Linq.XDocument.Load(xmlPath);
            var resourceMap = new System.Collections.Generic.Dictionary<string, string>();
            foreach (var elem in xdoc.Root.Elements("string"))
            {
                var nameAttr = elem.Attribute("name");
                if (nameAttr != null)
                {
                    string name = nameAttr.Value;
                    string value = elem.Value;
                    resourceMap[name] = value;
                }
            }

            // Read HTML template content
            string htmlContent = System.IO.File.ReadAllText(htmlTemplatePath, System.Text.Encoding.UTF8);

            // Replace placeholders with localized strings
            foreach (var kvp in resourceMap)
            {
                string placeholder = "{{" + kvp.Key + "}}";
                htmlContent = htmlContent.Replace(placeholder, kvp.Value);
            }

            // Load HTML into Aspose.Html.HTMLDocument using safe fallback constructor
            string basePath = System.IO.Path.GetDirectoryName(htmlTemplatePath);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, basePath);

            // Save the localized HTML page
            document.Save(outputPath);

            System.Console.WriteLine("Localized HTML saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}