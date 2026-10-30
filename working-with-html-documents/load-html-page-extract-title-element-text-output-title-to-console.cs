// Load an HTML page, extract its title element text, and output the title to console.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            string title = document.Title;
            System.Console.WriteLine(title);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}