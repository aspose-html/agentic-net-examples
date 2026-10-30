// Write unit tests to verify that SVG to PNG conversion produces files of expected dimensions.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            RunTests();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RunTests()
    {
        TestSvgToPngDimensions();
    }

    static void TestSvgToPngDimensions()
    {
        // Arrange
        string currentDir = Directory.GetCurrentDirectory();
        string inputFolder = Path.Combine(currentDir, "Input");
        string outputFolder = Path.Combine(currentDir, "Output");

        if (!Directory.Exists(inputFolder)) Directory.CreateDirectory(inputFolder);
        if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

        string svgPath = Path.Combine(inputFolder, "sample.svg");
        string pngPath = Path.Combine(outputFolder, "sample.png");

        // Create a simple SVG with known dimensions (200x100)
        string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='100'></svg>";
        File.WriteAllText(svgPath, svgContent);

        // Act
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
        Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pngPath);

        // Assert
        using (Image img = Image.FromFile(pngPath))
        {
            int expectedWidth = 200;
            int expectedHeight = 100;

            if (img.Width == expectedWidth && img.Height == expectedHeight)
            {
                Console.WriteLine("TestSvgToPngDimensions passed.");
            }
            else
            {
                Console.WriteLine($"TestSvgToPngDimensions failed. Expected {expectedWidth}x{expectedHeight}, got {img.Width}x{img.Height}.");
            }
        }
    }
}