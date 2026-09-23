// Detect duplicate external SVG files by comparing content hashes before saving.

using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with duplicate SVG elements
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string htmlContent = @"<!DOCTYPE html>
<html>
<body>
<svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' /></svg>
<svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' /></svg>
<svg width='100' height='100'><rect width='100' height='100' style='fill:blue;' /></svg>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Hash set to track seen SVG content hashes
            HashSet<string> seenHashes = new HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Compute SHA256 hash of the SVG markup
                byte[] markupBytes = Encoding.UTF8.GetBytes(markup);
                string hash;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(markupBytes);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2"));
                    hash = sb.ToString();
                }

                // Skip duplicate SVGs
                if (!seenHashes.Add(hash))
                {
                    continue;
                }

                // Save unique SVG to file
                string outputPath = $"output_{i}.svg";
                SVGDocument svgDoc = new SVGDocument(markup, "");
                svgDoc.Save(outputPath);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}