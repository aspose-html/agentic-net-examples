// Log a summary of all extracted resources, including type and file path, after extraction.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;

class MyResourceHandler : Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler
{
    public List<Aspose.Html.Saving.Resource> Resources = new List<Aspose.Html.Saving.Resource>();
    public MyResourceHandler(string directory) : base(directory) { }
    public override void HandleResource(Aspose.Html.Saving.Resource resource, Aspose.Html.Saving.ResourceHandlingContext context)
    {
        Resources.Add(resource);
        base.HandleResource(resource, context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputHtmlPath = "output.html";
            string resourceDirectory = "extracted_resources";
            string logPath = "extraction_log.txt";

            // Ensure clean environment
            if (File.Exists(inputHtmlPath)) File.Delete(inputHtmlPath);
            if (File.Exists(outputHtmlPath)) File.Delete(outputHtmlPath);
            if (File.Exists(logPath)) File.Delete(logPath);
            if (Directory.Exists(resourceDirectory)) Directory.Delete(resourceDirectory, true);
            Directory.CreateDirectory(resourceDirectory);

            // Create a dummy image file
            string imageFileName = "sample.png";
            File.WriteAllBytes(imageFileName, new byte[0]);

            // Write sample HTML referencing the image
            string htmlContent = "<html><body><img src=\"" + imageFileName + "\" /></body></html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Set up resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save document with resources extraction
            document.Save(resourceHandler, saveOptions);

            // Log summary of extracted resources
            File.AppendAllText(logPath, "Extracted Resources Summary:" + Environment.NewLine);
            foreach (Aspose.Html.Saving.Resource res in resourceHandler.Resources)
            {
                string type = res.MimeType != null ? res.MimeType.ToString() : "unknown";
                string url = res.OriginalUrl != null ? res.OriginalUrl.ToString() : string.Empty;
                string localPath = res.OutputUrl != null ? res.OutputUrl.ToString() : string.Empty;
                string line = $"Type: {type}, URL: {url}, LocalPath: {localPath}";
                File.AppendAllText(logPath, line + Environment.NewLine);
            }

            // Save the final HTML (optional)
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}