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
            // Path to the source MHTML file (should reference fonts that are not installed)
            string inputPath = "sample.mhtml";

            // Path where the resulting DOCX would be saved
            string outputPath = "output.docx";

            // Open the MHTML file as a readable stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create default DOCX save options
                DocSaveOptions options = new DocSaveOptions();

                // Attempt conversion; expected to fail if required fonts are missing
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            // If conversion succeeds, the test has failed because it should not succeed without fonts
            Console.WriteLine("Test failed: conversion succeeded unexpectedly.");
        }
        catch (Exception ex)
        {
            // Expected path: conversion throws an exception due to missing fonts
            Console.WriteLine("Test passed: conversion failed gracefully.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
    }
}