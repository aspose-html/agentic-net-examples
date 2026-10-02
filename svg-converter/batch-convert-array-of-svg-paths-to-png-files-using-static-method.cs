// Use Converter.ConvertSVG static method to batch convert an array of SVG paths into PNG files.

public class Program
{
    public static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPngs";

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] sampleNames = new string[] { "sample1.svg", "sample2.svg" };
            foreach (string name in sampleNames)
            {
                string path = System.IO.Path.Combine(inputFolder, name);
                if (!System.IO.File.Exists(path))
                {
                    string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
                    System.IO.File.WriteAllText(path, svgContent);
                }
            }

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".png");

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

                int percent = (i + 1) * 100 / total;
                System.Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {System.IO.Path.GetFileName(outputPath)}");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}