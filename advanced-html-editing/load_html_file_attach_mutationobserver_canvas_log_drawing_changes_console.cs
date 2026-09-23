// Load an HTML file, attach a MutationObserver to the canvas, and log drawing changes to console.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Dom.Mutations;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file with a canvas element
            string inputPath = "sample.html";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                string htmlContent = @"<!DOCTYPE html><html><body><canvas id='myCanvas' width='200' height='200'></canvas></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];

            // Attach a MutationObserver to the canvas
            Aspose.Html.Dom.Mutations.MutationObserver observer = new Aspose.Html.Dom.Mutations.MutationObserver(
                (mutations, mutationObserver) =>
                {
                    foreach (var mutation in mutations)
                    {
                        Console.WriteLine($"Mutation observed: Type={mutation.Type}");
                    }
                });

            Aspose.Html.Dom.Mutations.MutationObserverInit config = new Aspose.Html.Dom.Mutations.MutationObserverInit
            {
                ChildList = true,
                Subtree = true,
                CharacterData = true,
                Attributes = true
            };

            observer.Observe(canvas, config);

            // Perform drawing operations on the canvas
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "#FF0000";
            context.FillRect(10, 10, 100, 100);

            // Modify an attribute to trigger a mutation
            canvas.SetAttribute("data-drawn", "true");

            // Render the document (including the canvas) to a JPEG image
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}