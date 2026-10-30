// Load an SVG document from a stream using a MemoryStream.

public class Program
{
    public static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
            byte[] svgBytes = System.Text.Encoding.UTF8.GetBytes(svgContent);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(svgBytes))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(memoryStream, "about:blank"))
                {
                    System.Console.WriteLine("SVG document loaded successfully.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}