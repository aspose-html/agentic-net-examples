// Create a unit test that verifies conversion to DOCX fails gracefully when required fonts are missing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content that uses a non‑existent font
            string inputPath = "sample.html";
            string outputPath = "output.docx";
            string htmlContent = "<html><head><style>body{font-family:'NonExistentFont';}</style></head><body>Hello World</body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Open the input file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Set up DOCX save options
                DocSaveOptions saveOptions = new DocSaveOptions();

                bool exceptionThrown = false;
                try
                {
                    // Attempt conversion – expected to fail due to missing font
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
                }
                catch (Exception ex)
                {
                    exceptionThrown = true;
                    Console.WriteLine("Test passed: conversion failed as expected.");
                    Console.WriteLine("Exception message: " + ex.Message);
                }

                if (!exceptionThrown)
                {
                    Console.WriteLine("Test failed: conversion succeeded unexpectedly.");
                }
            }

            // Cleanup temporary files
            if (File.Exists(inputPath))
                File.Delete(inputPath);
            if (File.Exists(outputPath))
                File.Delete(outputPath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected error: " + e.Message);
        }
    }
}