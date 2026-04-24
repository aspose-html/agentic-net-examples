// Convert EPUB to PNG and validate the output by comparing calculated hash with expected value stored in metadata.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            System.String outputPath = "output.png";
            System.IO.Stream stream = System.IO.File.OpenRead("input.epub");
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            stream.Dispose();

            using (var sha256 = SHA256.Create())
            using (var fileStream = System.IO.File.OpenRead(outputPath))
            {
                byte[] hashBytes = sha256.ComputeHash(fileStream);
                string actualHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                string expectedHash = "expectedhashvalue";

                if (actualHash == expectedHash.ToLowerInvariant())
                {
                    Console.WriteLine("Hash validation succeeded.");
                }
                else
                {
                    Console.WriteLine($"Hash validation failed. Expected: {expectedHash}, Actual: {actualHash}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}