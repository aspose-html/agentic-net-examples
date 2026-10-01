// Generate a word count statistic and embed it as a comment at the top of the document.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello world! This is a sample HTML document.</p></body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Compute word count from the body text
            string bodyText = document.Body.TextContent ?? string.Empty;
            int wordCount = 0;
            foreach (string word in bodyText.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                wordCount++;
            }

            // Create a comment node with the word count statistic
            string commentText = $" WordCount: {wordCount} ";
            var commentNode = document.CreateComment(commentText);

            // Insert the comment before the root element
            document.InsertBefore(commentNode, document.DocumentElement);

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed successfully. Word count: {wordCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}