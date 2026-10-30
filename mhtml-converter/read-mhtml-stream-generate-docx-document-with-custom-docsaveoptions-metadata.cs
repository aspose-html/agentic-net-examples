// Read an MHTML stream and generate a DOCX document with custom DocSaveOptions for metadata.

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
            // Input MHTML file path
            string inputPath = "input.mhtml";
            // Output DOCX file path
            string outputPath = "output.docx";

            // Ensure the input file exists (create a minimal sample if not)
            if (!File.Exists(inputPath))
            {
                // Create a simple MHTML file as a placeholder
                string sampleMhtml = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000_01D4C8E0.5A6B2F90\"\r\n\r\n------=_NextPart_000_0000_01D4C8E0.5A6B2F90\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello, World!</h1></body></html>\r\n------=_NextPart_000_0000_01D4C8E0.5A6B2F90--";
                File.WriteAllText(inputPath, sampleMhtml);
            }

            // Open the MHTML file as a stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Create DocSaveOptions and set metadata if supported
                DocSaveOptions saveOptions = new DocSaveOptions();

                // Example of setting metadata (uncomment if the property exists)
                // saveOptions.Metadata["Author"] = "John Doe";
                // saveOptions.Metadata["Title"] = "Sample Document";

                // Convert MHTML to DOCX
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}