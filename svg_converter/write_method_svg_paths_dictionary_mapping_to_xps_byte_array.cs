// Write a method that takes SVG paths and returns a dictionary mapping each to its XPS byte array.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace SvgToXpsConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                var svgPaths = new List<string>
                {
                    "example1.svg",
                    "example2.svg"
                };

                var result = ConvertSvgPathsToXpsBytes(svgPaths);

                foreach (var kvp in result)
                {
                    Console.WriteLine($"SVG Path: {kvp.Key}, XPS Bytes Length: {kvp.Value.Length}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static Dictionary<string, byte[]> ConvertSvgPathsToXpsBytes(IEnumerable<string> svgPaths)
        {
            var dictionary = new Dictionary<string, byte[]>();

            foreach (var svgPath in svgPaths)
            {
                // Create XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Generate a temporary file path for the XPS output
                string tempXpsPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xps");

                // Convert SVG file to XPS file
                Converter.ConvertSVG(svgPath, options, tempXpsPath);

                // Read the generated XPS file into a byte array
                byte[] xpsBytes = File.ReadAllBytes(tempXpsPath);

                // Add to the result dictionary
                dictionary[svgPath] = xpsBytes;

                // Clean up the temporary file
                File.Delete(tempXpsPath);
            }

            return dictionary;
        }
    }
}