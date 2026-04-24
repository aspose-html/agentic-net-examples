// Expose a public API method that returns a collection of file paths for all extracted SVGs from a given URL.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;

namespace SvgExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Example URL containing inline SVG elements
                string url = "https://example.com/page-with-svgs.html";

                // Extract SVG file paths
                List<string> svgPaths = ExtractSvgFilePaths(url);

                // Output the collected file paths
                foreach (var path in svgPaths)
                {
                    Console.WriteLine(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads an HTML document from the specified URL, extracts all inline SVG elements,
        /// generates a file name for each, and returns the collection of file paths.
        /// </summary>
        /// <param name="url">The URL of the HTML document.</param>
        /// <returns>List of file paths for the extracted SVGs.</returns>
        public static List<string> ExtractSvgFilePaths(string url)
        {
            // Create an HTMLDocument instance with the target URL
            HTMLDocument document = new HTMLDocument(url);

            // Retrieve all <svg> elements in the document
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare a list to hold the generated file paths
            List<string> filePaths = new List<string>();

            // Base directory for the SVG files (current directory)
            string outputFolder = Directory.GetCurrentDirectory();

            // Iterate over each SVG element and generate a file name
            for (int i = 0; i < svgs.Length; i++)
            {
                // Generate a file name like "0.svg", "1.svg", etc.
                string fileName = $"{i}.svg";

                // Combine with the output folder to create a full path
                string fullPath = Path.Combine(outputFolder, fileName);

                // Add the path to the collection
                filePaths.Add(fullPath);
            }

            return filePaths;
        }
    }
}