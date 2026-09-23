// Cache downloaded external SVG files locally to avoid redundant network requests.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the external SVG
            string svgUrl = "https://upload.wikimedia.org/wikipedia/commons/0/02/SVG_logo.svg";

            // Local cache folder
            string cacheFolder = "Cache";
            Directory.CreateDirectory(cacheFolder);

            // Local cached file path
            string cachedFileName = "cached.svg";
            string cachedFilePath = Path.Combine(cacheFolder, cachedFileName);

            // Download and cache the SVG if not already cached
            if (!File.Exists(cachedFilePath))
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] data = client.GetByteArrayAsync(svgUrl).Result;
                    File.WriteAllBytes(cachedFilePath, data);
                }
            }

            // Base URI for the SVG document (folder containing the cached file)
            string baseUri = new Uri(Path.GetFullPath(cacheFolder) + Path.DirectorySeparatorChar).AbsoluteUri;

            // Load the SVG document using the cached file and base URI
            using (SVGDocument doc = new SVGDocument(cachedFilePath, baseUri))
            {
                // Save the SVG to an output file
                string outputPath = "output.svg";
                doc.Save(outputPath);
                Console.WriteLine("SVG saved to: " + Path.GetFullPath(outputPath));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}