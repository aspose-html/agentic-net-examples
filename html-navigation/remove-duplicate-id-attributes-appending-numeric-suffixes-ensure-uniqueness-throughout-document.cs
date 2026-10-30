// Remove duplicate ID attributes by appending numeric suffixes to ensure uniqueness throughout the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with duplicate IDs
            string htmlContent = "<html><body>" +
                                 "<div id=\"item\">A</div>" +
                                 "<p id=\"item\">B</p>" +
                                 "<span id=\"unique\">C</span>" +
                                 "<div id=\"item\">D</div>" +
                                 "</body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have an id attribute
            Aspose.Html.Collections.NodeList elementsWithId = doc.QuerySelectorAll("[id]");

            // Track seen IDs and their next suffix
            System.Collections.Generic.Dictionary<string, int> idCounts = new System.Collections.Generic.Dictionary<string, int>(System.StringComparer.Ordinal);

            for (int i = 0; i < elementsWithId.Length; i++)
            {
                Aspose.Html.Dom.Element element = elementsWithId[i] as Aspose.Html.Dom.Element;
                if (element == null)
                    continue;

                string currentId = element.GetAttribute("id");
                if (string.IsNullOrEmpty(currentId))
                    continue;

                if (!idCounts.ContainsKey(currentId))
                {
                    // First occurrence of this ID
                    idCounts[currentId] = 1;
                }
                else
                {
                    // Duplicate ID found, generate a unique one
                    int suffix = idCounts[currentId];
                    string newId;
                    do
                    {
                        newId = currentId + "_" + suffix;
                        suffix++;
                    } while (idCounts.ContainsKey(newId));

                    element.SetAttribute("id", newId);
                    // Update counters
                    idCounts[currentId] = suffix;
                    idCounts[newId] = 1;
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            doc.Save(outputPath);

            System.Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}