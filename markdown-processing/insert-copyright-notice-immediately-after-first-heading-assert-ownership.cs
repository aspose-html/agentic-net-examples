// Insert a copyright notice immediately after the first heading to assert ownership.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            // Example: Load HTML from URL and save to file
            // Copyright (c) 2026 YourCompany. All rights reserved.
            try
            {
                string url = "https://example.com";
                string outputPath = "output.html";

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
                document.Title = "Sample Title";
                document.Save(outputPath);

                Console.WriteLine("Document saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}