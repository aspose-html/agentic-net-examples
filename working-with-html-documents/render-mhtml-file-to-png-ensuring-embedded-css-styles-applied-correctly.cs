// Render an MHTML file to PNG, ensuring embedded CSS styles are applied correctly.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            // Create a minimal MHTML file with embedded CSS if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = 
@"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 +0000
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000_01D6C0A0.12345678""

------=_NextPart_000_0000_01D6C0A0.12345678
Content-Type: text/html; charset=""utf-8""

<html>
<head>
    <style>
        body { background-color: lightblue; font-family: Arial; }
        h1 { color: darkblue; }
    </style>
</head>
<body>
    <h1>Hello, MHTML!</h1>
</body>
</html>

------=_NextPart_000_0000_01D6C0A0.12345678--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Set up image save options for PNG format
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                // Optional: configure rendering properties if needed
                // options.UseAntialiasing = true;
                // options.HorizontalResolution = 96;
                // options.VerticalResolution = 96;

                // Convert MHTML to PNG
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"MHTML has been successfully rendered to PNG: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}