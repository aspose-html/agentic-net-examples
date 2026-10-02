// Convert HTML to BMP and encrypt the output using CryptoStream before writing to a secure location.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            string htmlContent = "<html><body><h1>Hello, BMP!</h1></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                string bmpPath = Path.Combine(outputDir, "output.bmp");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, bmpPath);

                string encryptedPath = Path.Combine(outputDir, "output_encrypted.dat");

                using (Aes aes = Aes.Create())
                {
                    // Example key and IV (for demonstration only)
                    aes.Key = new byte[32];
                    aes.IV = new byte[16];

                    using (FileStream input = File.OpenRead(bmpPath))
                    using (FileStream output = File.Create(encryptedPath))
                    using (CryptoStream crypto = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        input.CopyTo(crypto);
                    }
                }
            }

            Console.WriteLine("Conversion and encryption completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}