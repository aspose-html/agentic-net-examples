// Batch process MHTML newsletters, converting each to PDF with embedded fonts for consistent appearance.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing MHTML newsletters
            string inputFolder = @"C:\Newsletters\MHTML";
            // Folder to save generated PDFs
            string outputFolder = @"C:\Newsletters\PDF";
            // Folder with custom fonts to embed
            string fontsFolder = @"C:\CustomFonts";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Prepare Aspose.HTML configuration with custom fonts
            Configuration configuration = new Configuration();
            IUserAgentService userAgent = configuration.GetService<IUserAgentService>();
            userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Process each MHTML file in the input folder
            foreach (string mhtmlPath in Directory.GetFiles(inputFolder, "*.mhtml"))
            {
                // Determine output PDF path
                string fileName = Path.GetFileNameWithoutExtension(mhtmlPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                // Open MHTML file as a read-only stream
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    // Default PDF save options (fonts will be embedded via configuration)
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();

                    // Convert MHTML to PDF
                    Converter.ConvertMHTML(stream, configuration, pdfOptions, pdfPath);
                }

                Console.WriteLine($"Converted '{mhtmlPath}' to '{pdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}