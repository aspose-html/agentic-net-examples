// Load HTML from a file path into an HTMLDocument for further processing.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Hello World</p></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                string htmlContent = document.DocumentElement.OuterHTML;
                System.Console.WriteLine(htmlContent);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}