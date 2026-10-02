// Generate a localized HTML page by binding language‑specific strings from an XML resource file.

class Program
{
    static void Main()
    {
        try
        {
            string sourceHtmlPath = "template.html";
            string xmlPath = "resources.xml";
            string outputPath = "localized.html";
            string language = "en";

            if (!System.IO.File.Exists(sourceHtmlPath))
            {
                string sampleHtml = "<html><head><title>{{title}}</title></head><body><h1>{{header}}</h1><p>{{message}}</p></body></html>";
                System.IO.File.WriteAllText(sourceHtmlPath, sampleHtml, System.Text.Encoding.UTF8);
            }

            if (!System.IO.File.Exists(xmlPath))
            {
                string sampleXml = "<resources>" +
                                   "<string name=\"title\" lang=\"en\">Welcome</string>" +
                                   "<string name=\"header\" lang=\"en\">Hello</string>" +
                                   "<string name=\"message\" lang=\"en\">This is an English message.</string>" +
                                   "<string name=\"title\" lang=\"fr\">Bienvenue</string>" +
                                   "<string name=\"header\" lang=\"fr\">Bonjour</string>" +
                                   "<string name=\"message\" lang=\"fr\">Ceci est un message en français.</string>" +
                                   "</resources>";
                System.IO.File.WriteAllText(xmlPath, sampleXml, System.Text.Encoding.UTF8);
            }

            string htmlContent = System.IO.File.ReadAllText(sourceHtmlPath, System.Text.Encoding.UTF8);
            var xmlDoc = System.Xml.Linq.XDocument.Load(xmlPath);

            string[] keys = new string[] { "title", "header", "message" };
            foreach (string key in keys)
            {
                var element = System.Linq.Enumerable.FirstOrDefault(
                    xmlDoc.Root.Elements("string"),
                    e => (string)e.Attribute("name") == key && (string)e.Attribute("lang") == language);
                if (element != null)
                {
                    string value = element.Value;
                    htmlContent = htmlContent.Replace("{{" + key + "}}", value);
                }
            }

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}