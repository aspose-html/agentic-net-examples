// Use the online Color Contrast Checker API to programmatically verify contrast ratios for identified elements.

using System;
using System.Net.Http;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with inline styles
            string htmlContent = "<html><body><p style='color:#ffffff;background-color:#000000;'>Sample text</p></body></html>";

            // Load HTML from string using two‑argument constructor (content, baseUri)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get the first <p> element
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length > 0)
            {
                HTMLElement paragraph = (HTMLElement)paragraphs[0];

                // Extract color values from style
                string textColor = paragraph.Style.Color;               // e.g., "#ffffff"
                string backgroundColor = paragraph.Style.BackgroundColor; // e.g., "#000000"

                // Prepare request to the online Color Contrast Checker API (WebAIM)
                // API expects colors without the leading '#'
                string textColorParam = string.IsNullOrEmpty(textColor) ? "000000" : textColor.TrimStart('#');
                string bgColorParam = string.IsNullOrEmpty(backgroundColor) ? "ffffff" : backgroundColor.TrimStart('#');
                string requestUri = "https://webaim.org/resources/contrastchecker/?fcolor=" + textColorParam + "&bcolor=" + bgColorParam + "&api";

                // Call the API
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                string apiResult = response.Content.ReadAsStringAsync().Result;

                // Output the API response
                Console.WriteLine("Contrast check result:");
                Console.WriteLine(apiResult);
            }
            else
            {
                Console.WriteLine("No <p> elements found in the document.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}