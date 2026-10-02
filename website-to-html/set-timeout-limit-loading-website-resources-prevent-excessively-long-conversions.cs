// Set a timeout limit for loading website resources to prevent excessively long conversions.

public sealed class Program
{
    public static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.MaxHandlingDepth = 5;
                document.Save(outputPath, options);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}