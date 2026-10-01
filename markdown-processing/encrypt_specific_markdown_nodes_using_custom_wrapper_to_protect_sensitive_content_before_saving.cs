// Encrypt specific Markdown nodes using a custom wrapper to protect sensitive content before saving.

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a custom wrapper for sensitive content
            string htmlContent = "<html><body><p>Public information.</p><protected>Secret data</protected></body></html>";
            string baseUri = "";

            // Convert HTML to Markdown using Aspose.Html
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = System.IO.Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);

            // Encrypt the sensitive part ("Secret data") in the markdown
            string sensitiveText = "Secret data";
            string encryptedText = EncryptString(sensitiveText);
            // Replace the plain sensitive text with its encrypted representation
            markdown = markdown.Replace(sensitiveText, encryptedText);

            // Save the final markdown to a file
            string outputPath = "output.md";
            System.IO.File.WriteAllText(outputPath, markdown, Encoding.UTF8);

            Console.WriteLine($"Markdown file saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple AES encryption with a static key and IV for demonstration purposes
    private static string EncryptString(string plainText)
    {
        // NOTE: In real scenarios, never hardcode keys/IVs. This is for example only.
        byte[] key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF"); // 32 bytes for AES-256
        byte[] iv = Encoding.UTF8.GetBytes("ABCDEF0123456789"); // 16 bytes for AES

        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                {
                    sw.Write(plainText);
                }
                byte[] encryptedBytes = ms.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }
}