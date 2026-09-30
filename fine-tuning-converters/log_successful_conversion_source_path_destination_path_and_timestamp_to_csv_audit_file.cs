// Log each successful conversion with source path, destination path, and timestamp to a CSV audit file.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtml = "input.html";
            string outputHtml = "output.html";
            string csvPath = "audit.csv";

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputHtml))
            {
                File.WriteAllText(inputHtml, "<html><body><h1>Sample</h1></body></html>");
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputHtml);

            // Save the document to the destination path
            document.Save(outputHtml);

            // Log conversion details to CSV
            string timestamp = DateTime.Now.ToString("o");
            string line = $"{inputHtml},{outputHtml},{timestamp}";

            using (StreamWriter csvWriter = new StreamWriter(csvPath, true))
            {
                // Write header if the file is empty
                if (csvWriter.BaseStream.Length == 0)
                {
                    csvWriter.WriteLine("Source,Destination,Timestamp");
                }
                csvWriter.WriteLine(line);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}