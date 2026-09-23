// Skip duplicate images by comparing SHA256 hashes before saving new files.

using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mht";
            string outputDocxPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: 7bit\r\n\r\n<html><body><p>Sample content with an image.</p><img src=\"https://via.placeholder.com/150\" /></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml, Encoding.UTF8);
            }

            // Process images: download, compute hash, embed unique images as data URIs
            var seenHashes = new HashSet<string>();
            using (HTMLDocument document = new HTMLDocument(inputPath))
            using (HttpClient httpClient = new HttpClient())
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Element imageElement = (Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                        continue;

                    Uri baseUri = new Uri(document.BaseURI.ToString(), UriKind.Absolute);
                    Uri resolvedUri = new Uri(baseUri, src);
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(resolvedUri.AbsoluteUri);
                    using (SHA256 sha = SHA256.Create())
                    {
                        byte[] hashBytes = sha.ComputeHash(imageBytes);
                        string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                        if (!seenHashes.Add(hashString))
                        {
                            // Duplicate image; skip embedding
                            continue;
                        }

                        string mimeType = GetMimeType(Path.GetExtension(resolvedUri.AbsolutePath));
                        string dataUri = "data:" + mimeType + ";base64," + Convert.ToBase64String(imageBytes);
                        imageElement.SetAttribute("src", dataUri);
                    }
                }

                // Optionally save the processed HTML (not required for conversion)
                // document.Save("processed.html");
            }

            // Convert MHTML to DOCX
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                DocSaveOptions options = new DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputDocxPath);
            }

            // Compute SHA-256 hash of the output DOCX file
            byte[] outputBytes = File.ReadAllBytes(outputDocxPath);
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(outputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                Console.WriteLine("Output DOCX Path: " + outputDocxPath);
                Console.WriteLine("SHA-256 Hash: " + hashString);
            }
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