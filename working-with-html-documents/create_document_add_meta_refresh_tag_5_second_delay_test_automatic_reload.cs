// Create a document, add a meta refresh tag with 5‑second delay, and test automatic reload.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><h1>Hello</h1></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            string outputPath = "output.html";

            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "text/html"))
            {
                var meta = document.CreateElement("meta");
                meta.SetAttribute("http-equiv", "refresh");
                meta.SetAttribute("content", "5");

                var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
                head.AppendChild(meta);

                document.Save(outputPath);
                System.Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}