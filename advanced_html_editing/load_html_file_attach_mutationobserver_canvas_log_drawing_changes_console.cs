// Load an HTML file, attach a MutationObserver to the canvas, and log drawing changes to console.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Mutations;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];
            MutationObserver observer = new MutationObserver((mutations, mo) =>
            {
                foreach (var record in mutations)
                {
                    Console.WriteLine($"Mutation type: {record.Type}");
                    if (record.AddedNodes != null && record.AddedNodes.Length > 0)
                    {
                        foreach (var node in record.AddedNodes)
                        {
                            Console.WriteLine($"Added node: {node.NodeName}");
                        }
                    }
                }
            });
            MutationObserverInit config = new MutationObserverInit { ChildList = true, Subtree = true, CharacterData = true };
            observer.Observe(canvas, config);
            ICanvasRenderingContext2D ctx = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            ctx.FillStyle = "#00FF00";
            ctx.FillRect(20, 20, 50, 50);
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}