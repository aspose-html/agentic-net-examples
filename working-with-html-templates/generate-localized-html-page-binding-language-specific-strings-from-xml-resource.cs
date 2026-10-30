// Generate a localized HTML page by binding language‑specific strings from an XML resource file.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Paths for resources
            System.String xmlPath = "strings.xml";
            System.String templatePath = "template.html";
            System.String outputPath = "localized.html";

            // Create a minimal XML resource file if it does not exist
            if (!System.IO.File.Exists(xmlPath))
            {
                System.String sampleXml = "<resources><en><title>Hello</title><body>Welcome</body></en><es><title>Hola</title><body>Bienvenido</body></es></resources>";
                System.IO.File.WriteAllText(xmlPath, sampleXml, System.Text.Encoding.UTF8);
            }

            // Create a minimal HTML template file if it does not exist
            if (!System.IO.File.Exists(templatePath))
            {
                System.String sampleTemplate = "<html><head><title>{{title}}</title></head><body><p>{{body}}</p></body></html>";
                System.IO.File.WriteAllText(templatePath, sampleTemplate, System.Text.Encoding.UTF8);
            }

            // Load XML resource
            System.Xml.Linq.XDocument xmlDoc = System.Xml.Linq.XDocument.Load(xmlPath);

            // Choose language (e.g., "es" for Spanish)
            System.String language = "es";

            // Retrieve language-specific strings
            System.Xml.Linq.XElement langElement = xmlDoc.Root.Element(language);
            if (langElement == null)
                throw new System.Exception("Language not found in resources.");

            System.String title = (string)langElement.Element("title");
            System.String body = (string)langElement.Element("body");

            // Load HTML template
            System.String template = System.IO.File.ReadAllText(templatePath, System.Text.Encoding.UTF8);

            // Bind strings to template
            System.String htmlContent = template.Replace("{{title}}", title).Replace("{{body}}", body);

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Save the localized HTML page
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}