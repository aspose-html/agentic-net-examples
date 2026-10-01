// Allow user to cancel batch extraction via a CancellationToken source.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample input files
            List<string> inputFiles = new List<string>();
            inputFiles.Add("input1.html");
            inputFiles.Add("input2.html");

            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllText(file, "<html><body><h1>Sample " + file + "</h1></body></html>");
                }
            }

            // Create a cancellation token source
            CancellationTokenSource cts = new CancellationTokenSource();

            int index = 0;
            foreach (string inputPath in inputFiles)
            {
                index++;

                // Simulate cancellation after the first file
                if (index > 1)
                {
                    cts.Cancel();
                }

                // Configure Aspose.HTML
                Configuration configuration = new Configuration();

                // Create request with cancellation token
                RequestMessage request = new RequestMessage(inputPath);
                request.CancellationToken = cts.Token;

                // Load the document
                using (HTMLDocument document = new HTMLDocument(request, configuration))
                {
                    // Save as MHTML
                    MHTMLSaveOptions options = new MHTMLSaveOptions();
                    string outputPath = Path.ChangeExtension(inputPath, ".mhtml");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}