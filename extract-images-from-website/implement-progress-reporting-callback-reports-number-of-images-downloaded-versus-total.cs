// Implement progress reporting callback that reports number of images downloaded versus total.

using System;

public sealed class Program
{
    public static void Main()
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string outputDir = "downloaded_images";
            if (!System.IO.Directory.Exists(outputDir)) System.IO.Directory.CreateDirectory(outputDir);
            if (!System.IO.File.Exists(inputHtmlPath))
            {
                string htmlContent = "<html><body><img src=\"https://via.placeholder.com/150\" /></body></html>";
                System.IO.File.WriteAllText(inputHtmlPath, htmlContent);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                int total = images.Length;
                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    for (int i = 0; i < total; i++)
                    {
                        Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src)) continue;
                        Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
                        string fileName = System.IO.Path.GetFileName(urlString);
                        string savePath = System.IO.Path.Combine(outputDir, fileName);
                        System.IO.File.WriteAllBytes(savePath, imageBytes);
                        ReportProgress(i + 1, total);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void ReportProgress(int downloaded, int total)
    {
        System.Console.WriteLine($"Downloaded {downloaded}/{total} images.");
    }
}