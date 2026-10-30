// Load an HTML file into an HTMLDocument, modify paragraph text color using inline CSS, and save.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Hello World</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p")[0];
            paragraph.Style.Color = "red";
            document.Save(outputPath);
            System.Console.WriteLine("Document saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}