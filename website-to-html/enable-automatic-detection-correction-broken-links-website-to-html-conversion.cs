// Enable automatic detection and correction of broken links during website‑to‑HTML conversion.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Load the website into an HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com");

            // List to store broken link URLs
            List<string> brokenLinks = new List<string>();

            // Detect broken links and correct them
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(resolvedUrl);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl.ToString());
                    // Simple correction: replace broken href with a placeholder
                    linkElement.SetAttribute("href", "#");
                }
            }

            // Save the corrected HTML to a file
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save("output.html", saveOptions);

            // Output results
            Console.WriteLine("Broken links detected and corrected:");
            foreach (string bl in brokenLinks)
            {
                Console.WriteLine(bl);
            }
            Console.WriteLine("Corrected HTML saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}