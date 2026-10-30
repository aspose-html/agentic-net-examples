// Save a single webpage to a local folder with default HTMLSaveOptions and verify file creation.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            string outputPath = "saved_page.html";
            document.Save(outputPath, options);
            bool exists = System.IO.File.Exists(outputPath);
            if (exists)
            {
                System.Console.WriteLine("Webpage saved successfully to: " + System.IO.Path.GetFullPath(outputPath));
            }
            else
            {
                System.Console.WriteLine("Failed to save the webpage.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}