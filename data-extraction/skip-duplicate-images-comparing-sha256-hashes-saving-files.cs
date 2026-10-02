// Skip duplicate images by comparing SHA256 hashes before saving new files.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputDocxPath = "output.docx";

            // Process images in the HTML document, skipping duplicates
            var seenImageHashes = new HashSet<string>();
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            using (var httpClient = new HttpClient())
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                        continue;

                    Uri baseUri = new Uri(document.BaseURI.ToString(), UriKind.Absolute);
                    Uri resolvedUri = new Uri(baseUri, src);
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(resolvedUri.AbsoluteUri);

                    // Compute SHA-256 hash of the image
                    string hash;
                    using (SHA256 sha = SHA256.Create())
                    {
                        byte[] hashBytes = sha.ComputeHash(imageBytes);
                        hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    }

                    // Skip duplicate images
                    if (!seenImageHashes.Add(hash))
                        continue;

                    string mimeType = GetMimeType(Path.GetExtension(resolvedUri.AbsolutePath));
                    string dataUri = "data:" + mimeType + ";base64," + Convert.ToBase64String(imageBytes);
                    imageElement.SetAttribute("src", dataUri);
                }
            }

            // Convert MHTML to DOCX
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputDocxPath);
            }

            // Compute SHA-256 hash of the output DOCX
            byte[] outputBytes = File.ReadAllBytes(outputDocxPath);
            string outputHash;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(outputBytes);
                outputHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }

            Console.WriteLine("Output DOCX: " + outputDocxPath);
            Console.WriteLine("SHA-256: " + outputHash);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string GetMimeType(string extension)
    {
        switch (extension.ToLowerInvariant())
        {
            case ".png": return "image/png";
            case ".jpg":
            case ".jpeg": return "image/jpeg";
            case ".gif": return "image/gif";
            case ".svg": return "image/svg+xml";
            case ".webp": return "image/webp";
            default: return "application/octet-stream";
        }
    }
}