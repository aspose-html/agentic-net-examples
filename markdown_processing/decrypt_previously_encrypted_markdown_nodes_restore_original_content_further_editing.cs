// Decrypt previously encrypted Markdown nodes to restore original content for further editing.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input HTML file containing encrypted markdown nodes
            string inputPath = args.Length > 0 ? args[0] : "encrypted.html";
            // Output HTML file with decrypted content
            string outputPath = args.Length > 1 ? args[1] : "decrypted.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all elements that hold encrypted markdown (identified by the "encrypted" CSS class)
            var encryptedNodes = document.QuerySelectorAll(".encrypted");

            // Decrypt each node's content (assumes Base64 encoding)
            foreach (Node node in encryptedNodes)
            {
                string base64 = node.TextContent;
                if (!string.IsNullOrEmpty(base64))
                {
                    byte[] data = Convert.FromBase64String(base64);
                    string decoded = Encoding.UTF8.GetString(data);
                    node.TextContent = decoded;
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine("Decryption completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}