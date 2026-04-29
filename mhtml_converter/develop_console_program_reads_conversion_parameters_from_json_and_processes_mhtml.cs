// Develop a console program that reads conversion parameters from a JSON file and processes MHTML accordingly.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MhtmlConversionApp
{
    class Program
    {
        // Model for JSON conversion parameters
        private class ConversionParams
        {
            public string SourcePath { get; set; }
            public string OutputPath { get; set; }
        }

        static void Main(string[] args)
        {
            try
            {
                // Expect the first argument to be the path to the JSON file
                if (args.Length == 0)
                {
                    Console.WriteLine("Please provide the path to the JSON configuration file as an argument.");
                    return;
                }

                string jsonConfigPath = args[0];

                // Read and deserialize JSON configuration
                string jsonContent = File.ReadAllText(jsonConfigPath);
                ConversionParams parameters = JsonSerializer.Deserialize<ConversionParams>(jsonContent);

                if (parameters == null || string.IsNullOrWhiteSpace(parameters.SourcePath) || string.IsNullOrWhiteSpace(parameters.OutputPath))
                {
                    Console.WriteLine("Invalid configuration. Ensure 'SourcePath' and 'OutputPath' are provided.");
                    return;
                }

                // Assign variables from configuration
                string sourcePath = parameters.SourcePath;
                string outputPath = parameters.OutputPath;

                // Load the HTML document from the source path
                HTMLDocument document = new HTMLDocument(sourcePath);

                // Create default MHTML save options
                MHTMLSaveOptions options = new MHTMLSaveOptions();

                // Perform the conversion to MHTML
                Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"Conversion completed successfully. MHTML saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}