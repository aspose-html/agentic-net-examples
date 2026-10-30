// Create a unit test that verifies conversion to DOCX fails gracefully when required fonts are missing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML that references a non‑existent font
            string inputPath = "sample.html";
            string outputPath = "output.docx";
            string htmlContent = "<!DOCTYPE html><html><head><style>body{font-family:'NonExistentFont';}</style></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Attempt conversion to DOCX
            Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, saveOptions, outputPath);

            // If no exception, the test failed
            Console.WriteLine("Test failed: conversion succeeded unexpectedly.");
        }
        catch (Exception ex)
        {
            // Expected path: conversion should fail due to missing fonts
            Console.WriteLine($"Test passed: conversion failed as expected. Message: {ex.Message}");
        }
    }
}