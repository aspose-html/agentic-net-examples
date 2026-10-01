// Generate a summary report that aggregates total errors across all processed HTML documents in a batch.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input";
            if (!System.IO.Directory.Exists(inputDir))
            {
                System.IO.Directory.CreateDirectory(inputDir);
                string samplePath = System.IO.Path.Combine(inputDir, "sample1.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><p>Hello</p></body></html>");
                string invalidPath = System.IO.Path.Combine(inputDir, "invalid.html");
                System.IO.File.WriteAllText(invalidPath, "<html><body><p>Invalid");
            }

            int totalErrors = 0;

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputDir, "*.html"))
            {
                try
                {
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                    var title = document.Title;
                    document.Dispose();
                }
                catch (System.Exception ex)
                {
                    totalErrors++;
                    System.Console.WriteLine($"Error processing {htmlPath}: {ex.Message}");
                }
            }

            string missingPath = System.IO.Path.Combine(inputDir, "missing.html");
            try
            {
                Aspose.Html.HTMLDocument missingDoc = new Aspose.Html.HTMLDocument(missingPath);
                missingDoc.Dispose();
            }
            catch (System.Exception ex)
            {
                totalErrors++;
                System.Console.WriteLine($"Error processing {missingPath}: {ex.Message}");
            }

            System.Console.WriteLine($"Total errors across all processed HTML documents: {totalErrors}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}