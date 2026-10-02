// Load an HTML document, replace all external script src attributes with local copies, and save.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Create a minimal sample HTML file if it does not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><script src=\"https://example.com/script.js\"></script></head><body><h1>Hello World</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                // Load the HTML document
                var document = new Aspose.Html.HTMLDocument(inputPath);

                // Get all <script> elements
                var scriptElements = document.GetElementsByTagName("script");

                // Ensure a folder for local script copies
                string scriptsFolder = "scripts";
                if (!System.IO.Directory.Exists(scriptsFolder))
                {
                    System.IO.Directory.CreateDirectory(scriptsFolder);
                }

                // Download external scripts and replace src attributes
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    for (int i = 0; i < scriptElements.Length; i++)
                    {
                        var scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                        string src = scriptElement.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src) && (src.StartsWith("http://") || src.StartsWith("https://")))
                        {
                            // Download script content
                            byte[] data = httpClient.GetByteArrayAsync(src).Result;

                            // Determine a file name for the local copy
                            string fileName;
                            try
                            {
                                var uri = new System.Uri(src);
                                fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
                                if (string.IsNullOrEmpty(fileName))
                                {
                                    fileName = System.Guid.NewGuid().ToString() + ".js";
                                }
                            }
                            catch
                            {
                                fileName = System.Guid.NewGuid().ToString() + ".js";
                            }

                            // Save the script locally
                            string localPath = System.IO.Path.Combine(scriptsFolder, fileName);
                            System.IO.File.WriteAllBytes(localPath, data);

                            // Update the src attribute to point to the local copy (use forward slashes)
                            string relativePath = System.IO.Path.Combine(scriptsFolder, fileName).Replace(System.IO.Path.DirectorySeparatorChar, '/');
                            scriptElement.SetAttribute("src", relativePath);
                        }
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}