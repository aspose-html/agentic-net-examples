// Generate a summary report listing each processed URL, output path, and conversion status.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com",
                "https://example.org"
            };

            string outputDirectory = "output";
            System.IO.Directory.CreateDirectory(outputDirectory);

            string csvPath = System.IO.Path.Combine(outputDirectory, "summary.csv");
            using (System.IO.StreamWriter csvWriter = new System.IO.StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("URL,OutputPath,Status");
                foreach (string url in urls)
                {
                    string fileName = "output_" + System.Guid.NewGuid().ToString("N") + ".html";
                    string outputPath = System.IO.Path.Combine(outputDirectory, fileName);
                    string status;
                    try
                    {
                        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
                        document.Save(outputPath);
                        status = "Success";
                    }
                    catch (System.Exception ex)
                    {
                        status = "Failed: " + ex.Message;
                    }
                    csvWriter.WriteLine($"{url},{outputPath},{status}");
                }
            }

            System.Console.WriteLine("Processing completed. Summary report saved to: " + csvPath);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine("Error: " + e.Message);
        }
    }
}