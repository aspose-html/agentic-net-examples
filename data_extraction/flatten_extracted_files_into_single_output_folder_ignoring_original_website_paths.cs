// Flatten all extracted files into a single output folder, ignoring original website paths.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input folder containing extracted files with original website paths
            string inputFolder = "ExtractedFiles";
            // Output folder where all files will be flattened
            string outputFolder = "FlattenedOutput";

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all files from the input folder and its subfolders
            foreach (string filePath in Directory.GetFiles(inputFolder, "*.*", SearchOption.AllDirectories))
            {
                // Destination path uses only the file name, discarding subfolder structure
                string destPath = Path.Combine(outputFolder, Path.GetFileName(filePath));

                // Copy the file to the destination, overwriting if a file with the same name exists
                File.Copy(filePath, destPath, true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}