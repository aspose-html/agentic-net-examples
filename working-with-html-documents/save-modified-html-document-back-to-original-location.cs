// Save the modified HTML document back to the original file location.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><meta name=\"description\" content=\"old\"></head><body>Hello World</body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                var metaElements = document.GetElementsByTagName("meta");

                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "new description");
                    }
                }

                // Save back to the original file location
                document.Save(inputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}