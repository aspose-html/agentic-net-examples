// Retrieve audio source URLs from audio tags and save them to a manifest file.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body>" +
                    "<audio src='audio1.mp3'></audio>" +
                    "<audio src='audio2.ogg'></audio>" +
                    "<audio></audio>" +
                    "</body></html>";

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                Aspose.Html.Collections.HTMLCollection audioElements = document.GetElementsByTagName("audio");

                System.Collections.Generic.List<string> audioSources = new System.Collections.Generic.List<string>();

                for (int i = 0; i < audioElements.Length; i++)
                {
                    Aspose.Html.Dom.Element audioElement = (Aspose.Html.Dom.Element)audioElements[i];
                    string src = audioElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        audioSources.Add(src);
                    }
                }

                string manifestPath = "audio_manifest.txt";
                System.IO.File.WriteAllLines(manifestPath, audioSources);

                System.Console.WriteLine("Audio sources saved to " + manifestPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}