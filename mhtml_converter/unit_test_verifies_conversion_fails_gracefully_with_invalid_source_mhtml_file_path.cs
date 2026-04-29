// Create a unit test that verifies conversion fails gracefully when the source MHTML file path is invalid.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        // Define an invalid source MHTML file path and a target output path
        string sourcePath = "nonexistent.mhtml";
        string outputPath = "output.pdf";

        try
        {
            // Attempt to open the invalid source file (this will throw)
            Stream stream = File.OpenRead(sourcePath);

            // Create PDF save options (default settings)
            PdfSaveOptions pdfOptions = new PdfSaveOptions();

            // Perform the conversion from MHTML stream to PDF
            Converter.ConvertMHTML(stream, pdfOptions, outputPath);

            // If conversion succeeds, the test has failed
            Console.WriteLine("Conversion succeeded unexpectedly.");
        }
        catch (Exception ex)
        {
            // Expected path: conversion fails gracefully due to invalid source path
            Console.WriteLine("Conversion failed as expected: " + ex.Message);
        }
    }
}