// Save downloaded icons to a dedicated icons directory using a custom naming convention.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;

class Program
{
    static async Task Main()
    {
        try
        {
            string htmlPath = "input.html";
            string iconsDirectory = "icons";
            Directory.CreateDirectory(iconsDirectory);

            var document = new HTMLDocument(htmlPath);
            var imgElements = document.GetElementsByTagName("img");

            using var httpClient = new HttpClient();
            int index = 0;

            foreach (var node in imgElements)
            {
                var element = node as Aspose.Html.Dom.Element;
                if (element == null) continue;

                string src = element.GetAttribute("src");
                if (string.IsNullOrEmpty(src)) continue;

                Uri uri;
                if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                    uri = new Uri(src);
                else
                    uri = new Uri(new Uri(htmlPath), src);

                byte[] data = await httpClient.GetByteArrayAsync(uri);
                string extension = Path.GetExtension(uri.AbsolutePath);
                if (string.IsNullOrEmpty(extension)) extension = ".bin";

                string fileName = $"icon_{index}{extension}";
                string outputPath = Path.Combine(iconsDirectory, fileName);
                await File.WriteAllBytesAsync(outputPath, data);
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}