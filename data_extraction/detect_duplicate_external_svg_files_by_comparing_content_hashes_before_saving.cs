// Detect duplicate external SVG files by comparing content hashes before saving.

using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "input_svgs";
            string outputDir = "output_svgs";
            Directory.CreateDirectory(outputDir);
            var seenHashes = new HashSet<string>();
            foreach (var filePath in Directory.GetFiles(inputDir, "*.svg"))
            {
                string content = File.ReadAllText(filePath);
                byte[] hashBytes;
                using (var sha = SHA256.Create())
                {
                    hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(content));
                }
                string hash = BitConverter.ToString(hashBytes).Replace("-", "");
                if (!seenHashes.Add(hash))
                    continue;
                string fileName = Path.GetFileName(filePath);
                string outputPath = Path.Combine(outputDir, fileName);
                var svgDoc = new SVGDocument(content, filePath);
                svgDoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}