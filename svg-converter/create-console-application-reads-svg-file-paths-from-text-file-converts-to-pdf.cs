// Create a console application that reads SVG file paths from a text file and converts each to PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define folders and list file
            string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InputSvgs");
            string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "OutputPdfs");
            string listFile = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "svglist.txt");

            // Ensure directories exist
            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample SVG file if none exist
            string sampleSvgPath = System.IO.Path.Combine(inputFolder, "sample.svg");
            if (!System.IO.File.Exists(sampleSvgPath))
            {
                string sampleSvgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                System.IO.File.WriteAllText(sampleSvgPath, sampleSvgContent);
            }

            // Write list file with SVG paths
            System.IO.File.WriteAllLines(listFile, new string[] { sampleSvgPath });

            // Read SVG file paths from the list file
            string[] svgFiles = System.IO.File.ReadAllLines(listFile);
            foreach (string svgPath in svgFiles)
            {
                if (!System.IO.File.Exists(svgPath))
                {
                    Console.WriteLine($"SVG file not found: {svgPath}");
                    continue;
                }

                string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

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