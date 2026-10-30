// Convert EPUB to PNG and validate the output by comparing calculated hash with expected value stored in metadata.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output locations
            string dataDir = "Data";
            string outputDir = "Output";
            string inputFileName = "sample.epub";
            string outputFileName = "output.png";

            // Ensure directories exist
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(dataDir, inputFileName);
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Verify that the EPUB file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input EPUB file not found at: {inputPath}");
                Console.WriteLine("Place a valid EPUB file at the specified location and rerun the example.");
                return;
            }

            // Prepare conversion options
            ImageSaveOptions options = new ImageSaveOptions();
            options.Format = ImageFormat.Png;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Perform EPUB to PNG conversion
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            // Compute SHA256 hash of the generated PNG
            byte[] pngBytes = File.ReadAllBytes(outputPath);
            string actualHash;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(pngBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));
                actualHash = sb.ToString();
            }

            // Expected hash (in a real scenario, retrieve from EPUB metadata)
            string expectedHash = "EXPECTED_HASH_PLACEHOLDER";

            // Validate hash
            if (string.Equals(actualHash, expectedHash, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Validation succeeded: output PNG hash matches expected value.");
            }
            else
            {
                Console.WriteLine("Validation failed: output PNG hash does not match expected value.");
                Console.WriteLine($"Expected: {expectedHash}");
                Console.WriteLine($"Actual  : {actualHash}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion or validation:");
            Console.WriteLine(ex.Message);
        }
    }
}