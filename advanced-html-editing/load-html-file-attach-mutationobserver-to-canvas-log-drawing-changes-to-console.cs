// Load an HTML file, attach a MutationObserver to the canvas, and log drawing changes to console.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Dom.Mutations;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file with a canvas if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><canvas id='myCanvas' width='200' height='200'></canvas></body></html>");
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get the canvas element and its 2D context
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Perform a simple drawing operation
            context.FillStyle = "#FF0000";
            context.FillRect(10, 10, 100, 100);

            // Attach a MutationObserver to the canvas
            MutationObserver observer = new MutationObserver((mutations, mutationObserver) =>
            {
                foreach (var mutation in mutations)
                {
                    Console.WriteLine("Mutation observed: " + mutation.Type);
                }
            });

            MutationObserverInit config = new MutationObserverInit
            {
                ChildList = true,
                Subtree = true,
                CharacterData = true
            };

            observer.Observe(canvas, config);

            // Trigger a mutation (e.g., change an attribute)
            canvas.SetAttribute("data-drawn", "true");

            // Render the document (including the canvas) to a JPEG image
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("Rendering completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}