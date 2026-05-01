// Load multiple HTML files asynchronously, wait for all callbacks, and merge their bodies into one document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

namespace HtmlMergeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define the HTML files to be merged
                string[] inputFiles = new string[]
                {
                    "file1.html",
                    "file2.html",
                    // Add more file paths as needed
                };

                // Path for the merged output document
                string outputPath = "merged.html";

                // Create a new empty HTML document that will hold the merged content
                using (HTMLDocument mergedDocument = new HTMLDocument())
                {
                    // Iterate over each source file
                    foreach (string filePath in inputFiles)
                    {
                        // Skip missing files
                        if (!File.Exists(filePath))
                            continue;

                        // Load the source HTML document synchronously
                        using (HTMLDocument sourceDocument = new HTMLDocument(filePath))
                        {
                            // Create a container element (div) in the merged document
                            Element container = mergedDocument.CreateElement("div");

                            // Copy the inner HTML of the source body (if it exists) into the container
                            container.InnerHTML = sourceDocument.Body != null ? sourceDocument.Body.InnerHTML : string.Empty;

                            // Append the container to the merged document's body
                            mergedDocument.Body.AppendChild(container);
                        }
                    }

                    // Save the merged document to the specified output path
                    mergedDocument.Save(outputPath);
                }

                Console.WriteLine("HTML files merged successfully to: " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}