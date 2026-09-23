// Filter extracted images by file extension, such as .png or .jpg, before download.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<img src='https://example.com/image1.png'/>" +
                                 "<img src='https://example.com/photo.jpg'/>" +
                                 "<img src='https://example.com/ignore.gif'/>" +
                                 "</body></html>";

            var document = new Aspose.Html.HTMLDocument(htmlContent);
            var images = document.GetElementsByTagName("img");
            string outputDir = "DownloadedImages";
            System.IO.Directory.CreateDirectory(outputDir);

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Use only absolute URLs; skip relative ones for this example
                    if (!System.Uri.IsWellFormedUriString(src, System.UriKind.Absolute))
                        continue;

                    string extension = System.IO.Path.GetExtension(src);
                    if (!extension.Equals(".png", System.StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", System.StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", System.StringComparison.OrdinalIgnoreCase))
                        continue;

                    byte[] imageBytes = httpClient.GetByteArrayAsync(src).GetAwaiter().GetResult();
                    string fileName = System.IO.Path.GetFileName(src);
                    string savePath = System.IO.Path.Combine(outputDir, fileName);
                    System.IO.File.WriteAllBytes(savePath, imageBytes);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}