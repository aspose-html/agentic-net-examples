// Provide a CLI option to limit the maximum number of resources extracted per page.

using System;
using System.IO;

class LimitedResourceHandler : Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler
{
    private readonly int _maxResources;
    private int _handledCount;

    public LimitedResourceHandler(string directory, int maxResources) : base(directory)
    {
        _maxResources = maxResources;
        _handledCount = 0;
    }

    public override void HandleResource(Aspose.Html.Saving.Resource resource, Aspose.Html.Saving.ResourceHandlingContext context)
    {
        if (_handledCount < _maxResources)
        {
            base.HandleResource(resource, context);
            _handledCount++;
        }
        // Else: skip handling the resource
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default values
            int maxResourcesPerPage = 5;
            string inputHtmlPath = "sample.html";
            string outputHtmlPath = "output.html";
            string resourceDirectory = "resources";

            // Parse optional CLI argument for max resources
            if (args.Length > 0 && int.TryParse(args[0], out int parsedLimit) && parsedLimit > 0)
            {
                maxResourcesPerPage = parsedLimit;
            }

            // Ensure sample input file exists
            if (!File.Exists(inputHtmlPath))
            {
                string sampleContent = "<html><body>" +
                                       "<img src='https://example.com/image1.png'/>" +
                                       "<img src='https://example.com/image2.png'/>" +
                                       "<img src='https://example.com/image3.png'/>" +
                                       "<img src='https://example.com/image4.png'/>" +
                                       "<img src='https://example.com/image5.png'/>" +
                                       "<img src='https://example.com/image6.png'/>" +
                                       "</body></html>";
                File.WriteAllText(inputHtmlPath, sampleContent);
            }

            // Create resources directory
            Directory.CreateDirectory(resourceDirectory);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Set up custom resource handler with limit
            LimitedResourceHandler resourceHandler = new LimitedResourceHandler(resourceDirectory, maxResourcesPerPage);

            // Save document with limited resources
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(resourceHandler, options);

            // Optionally save the final HTML file
            document.Save(outputHtmlPath);

            Console.WriteLine($"Conversion completed. Max resources per page: {maxResourcesPerPage}");
            Console.WriteLine($"Resources saved to: {resourceDirectory}");
            Console.WriteLine($"Output HTML saved to: {outputHtmlPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}