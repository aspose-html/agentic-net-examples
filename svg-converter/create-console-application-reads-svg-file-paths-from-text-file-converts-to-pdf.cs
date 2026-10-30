// Create a console application that reads SVG file paths from a text file and converts each to PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFile = "svglist.txt";
            string outputFolder = "output";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            if (!System.IO.File.Exists(inputFile))
            {
                string sampleSvgPath = "sample.svg";
                string sampleSvgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
                System.IO.File.WriteAllText(sampleSvgPath, sampleSvgContent);
                System.IO.File.WriteAllLines(inputFile, new string[] { sampleSvgPath });
            }

            string[] svgFiles = System.IO.File.ReadAllLines(inputFile);
            foreach (string svgPath in svgFiles)
            {
                if (string.IsNullOrWhiteSpace(svgPath))
                    continue;

                string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileName + ".pdf");

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);

                Console.WriteLine($"Converted '{svgPath}' to '{pdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}