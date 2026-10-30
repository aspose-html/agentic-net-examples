// Apply a regular expression to mask email addresses within all text nodes for privacy compliance.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Contact: john.doe@example.com and jane_smith@domain.org</p></body></html>");
            }

            // Build a file URI for the request
            string fileUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;

            // Initialize Aspose.HTML configuration and request
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(fileUri);

            // Load the document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Regular expression to match email addresses
                Regex emailRegex = new Regex("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}", RegexOptions.Compiled);

                // Select all text nodes using XPath
                Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//text()", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
                Aspose.Html.Dom.Node node;
                while ((node = result.IterateNext()) != null)
                {
                    // Cast to CharacterData to access the text content
                    Aspose.Html.Dom.CharacterData charData = node as Aspose.Html.Dom.CharacterData;
                    if (charData != null && !string.IsNullOrEmpty(charData.Data))
                    {
                        // Replace email addresses with a masked placeholder
                        string masked = emailRegex.Replace(charData.Data, "[masked email]");
                        charData.Data = masked;
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Email addresses have been masked and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}