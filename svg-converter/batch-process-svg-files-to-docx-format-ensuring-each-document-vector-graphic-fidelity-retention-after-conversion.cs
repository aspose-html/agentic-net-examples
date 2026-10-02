// Batch process SVG files to DOCX format, ensuring each document retains vector graphic fidelity after conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputDocs";

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample SVG if none exist
            string[] existingSvgs = System.IO.Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = System.IO.Path.Combine(inputFolder, "sample.svg");
                string sampleSvgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                System.IO.File.WriteAllText(sampleSvgPath, sampleSvgContent);
                existingSvgs = new string[] { sampleSvgPath };
            }

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".docx");

                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

                int percent = (i + 1) * 100 / total;
                System.Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {System.IO.Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}