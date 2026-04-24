// Convert HTML to BMP and encrypt the output using CryptoStream before writing to a secure location.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string bmpOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");
            string encryptedOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_encrypted.dat");

            // Ensure input file exists (for demo purposes, create a simple HTML file if missing)
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Convert HTML to BMP using Aspose.HTML
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, bmpOutputPath);

            // Read the generated BMP bytes
            byte[] bmpBytes = File.ReadAllBytes(bmpOutputPath);

            // Encrypt the BMP bytes using AES and write to a secure location
            using (Aes aes = Aes.Create())
            {
                aes.Key = new byte[32]; // Replace with a secure key
                aes.IV = new byte[16];  // Replace with a secure IV

                using (FileStream fs = new FileStream(encryptedOutputPath, FileMode.Create, FileAccess.Write))
                using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bmpBytes, 0, bmpBytes.Length);
                }
            }

            Console.WriteLine("HTML converted to BMP and encrypted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}