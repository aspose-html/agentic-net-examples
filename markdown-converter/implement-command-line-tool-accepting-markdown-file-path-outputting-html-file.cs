// Implement a command‑line tool that accepts a Markdown file path and outputs an HTML file.

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath;
                string outputPath;

                if (args.Length >= 1)
                {
                    sourcePath = args[0];
                }
                else
                {
                    sourcePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.md");
                }

                if (args.Length >= 2)
                {
                    outputPath = args[1];
                }
                else
                {
                    outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.html");
                }

                if (!System.IO.File.Exists(sourcePath))
                {
                    string sampleContent = "# Sample Markdown\r\n\r\nThis is a *sample* markdown file.";
                    System.IO.File.WriteAllText(sourcePath, sampleContent);
                }

                Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);

                System.Console.WriteLine("Conversion completed. HTML saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}