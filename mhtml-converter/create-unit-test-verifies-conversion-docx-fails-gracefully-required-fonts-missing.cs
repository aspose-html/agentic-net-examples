// Create a unit test that verifies conversion to DOCX fails gracefully when required fonts are missing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML that references a missing font
            string inputPath = "sample.html";
            string outputPath = "output.docx";
            File.WriteAllText(inputPath,
                "<!DOCTYPE html><html><head><style>" +
                "@font-face {font-family: 'MissingFont'; src: url('missingfont.ttf');}" +
                "body {font-family: 'MissingFont';}" +
                "</style></head><body><p>Hello World</p></body></html>");

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            Console.WriteLine("Test failed: conversion succeeded unexpectedly.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Test passed: conversion failed as expected. Message: " + ex.Message);
        }
    }
}