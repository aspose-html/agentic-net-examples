// Encrypt specific Markdown nodes using a custom wrapper to protect sensitive content before saving.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

namespace MarkdownEncryptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for input and output markdown files
                string inputMarkdownPath = "input.md";
                string outputMarkdownPath = "output.md";

                // Read the original markdown content
                string markdownContent = File.ReadAllText(inputMarkdownPath);

                // Create a temporary markdown file for conversion
                string tempMdPath = Path.GetTempFileName();
                File.WriteAllText(tempMdPath, markdownContent);

                // Convert the markdown file to an HTMLDocument
                HTMLDocument htmlDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(tempMdPath);

                // Find markdown nodes that need protection (e.g., <p class="sensitive">)
                var sensitiveNodes = htmlDoc.QuerySelectorAll("p.sensitive");
                foreach (Element node in sensitiveNodes)
                {
                    // Create a custom wrapper element
                    var wrapper = htmlDoc.CreateElement("encrypted");

                    // Move the original node's children into the wrapper
                    while (node.FirstChild != null)
                    {
                        wrapper.AppendChild(node.FirstChild);
                    }

                    // Append the wrapper back to the node
                    node.AppendChild(wrapper);
                }

                // Save the modified HTMLDocument back to markdown
                MarkdownSaveOptions mdOptions = new MarkdownSaveOptions();
                htmlDoc.Save(outputMarkdownPath, mdOptions);

                // Clean up the temporary file
                File.Delete(tempMdPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}