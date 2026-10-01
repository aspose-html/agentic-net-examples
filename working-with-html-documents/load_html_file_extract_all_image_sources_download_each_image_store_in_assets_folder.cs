// Load an HTML file, extract all image sources, download each image, and store in assets folder.

namespace AsposeHtmlImageDownloader
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths for input HTML and output assets folder
                string inputHtmlPath = "sample.html";
                string assetsFolder = "assets";

                // Ensure the assets folder exists
                System.IO.Directory.CreateDirectory(assetsFolder);

                // Create a minimal sample HTML file if it does not exist
                if (!System.IO.File.Exists(inputHtmlPath))
                {
                    string sampleHtml = "<html><body>" +
                                        "<img src=\"https://via.placeholder.com/150.png\" />" +
                                        "<img src=\"https://via.placeholder.com/200.jpg\" />" +
                                        "<img src=\"https://example.com/image.gif\" />" +
                                        "</body></html>";
                    System.IO.File.WriteAllText(inputHtmlPath, sampleHtml);
                }

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

                // Get all <img> elements
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

                // Use HttpClient to download images
                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        // Cast collection item to Element
                        Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];

                        // Retrieve the src attribute
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                            continue;

                        // Resolve to an absolute URL
                        Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();

                        // Filter by supported image extensions
                        string extension = System.IO.Path.GetExtension(urlString);
                        if (!extension.Equals(".png", System.StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".jpg", System.StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".jpeg", System.StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        // Download image data
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                        // Determine file name and save path
                        string fileName = System.IO.Path.GetFileName(urlString);
                        string savePath = System.IO.Path.Combine(assetsFolder, fileName);

                        // Save the image to the assets folder
                        System.IO.File.WriteAllBytes(savePath, imageBytes);
                    }
                }

                System.Console.WriteLine("Image extraction and download completed.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}