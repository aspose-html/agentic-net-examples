// Create a reusable configuration class that holds default PdfSaveOptions, DocSaveOptions, and ImageSaveOptions instances.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

namespace AsposeHtmlDemo
{
    // Holds reusable default save options for PDF, DOC, and Image conversions
    public static class DefaultSaveOptions
    {
        // Default PDF options with form fields flattened
        public static PdfSaveOptions PdfOptions { get; } = CreatePdfOptions();

        // Default DOC options
        public static DocSaveOptions DocOptions { get; } = new DocSaveOptions();

        // Default Image options
        public static ImageSaveOptions ImageOptions { get; } = new ImageSaveOptions();

        private static PdfSaveOptions CreatePdfOptions()
        {
            // Create PdfSaveOptions instance
            PdfSaveOptions options = new PdfSaveOptions();
            // Set form fields to be rendered as static content
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;
            return options;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Retrieve default options
                var pdfOpts = DefaultSaveOptions.PdfOptions;
                var docOpts = DefaultSaveOptions.DocOptions;
                var imgOpts = DefaultSaveOptions.ImageOptions;

                // Demonstrate that options are available
                Console.WriteLine($"PDF FormFieldBehaviour: {pdfOpts.FormFieldBehaviour}");
                Console.WriteLine("DOC options instance created.");
                Console.WriteLine("Image options instance created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}