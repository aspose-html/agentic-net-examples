// Add a missing DOCTYPE declaration at the beginning of the HTML file to ensure standards mode.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";

            // Path where the modified HTML will be saved
            string outputPath = "output.html";

            // Read the entire content of the HTML file
            string content = File.ReadAllText(inputPath);

            // Check if the file already starts with a DOCTYPE declaration
            if (!content.TrimStart().StartsWith("<!DOCTYPE", StringComparison.OrdinalIgnoreCase))
            {
                // Prepend a standard HTML5 DOCTYPE if missing
                content = "<!DOCTYPE html>\n" + content;
            }

            // Write the (potentially) updated content back to a new file
            File.WriteAllText(outputPath, content);

            Console.WriteLine("HTML file processed successfully. Saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}