// Implement try‑catch error handling when loading an HTML file that may not exist.

public sealed class Program
{
    public static void Main()
    {
        try
        {
            string url = "file:///nonexistent.html";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request);
            string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            System.Console.WriteLine(html);
        }
        catch (System.Exception ex)
        {
            if (ex.Message.Contains("not found"))
            {
                System.Console.WriteLine("HTML file not found.");
            }
            else
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}