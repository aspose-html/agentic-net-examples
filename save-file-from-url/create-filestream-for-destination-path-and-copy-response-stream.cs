// Create a FileStream for the destination path and copy the response stream to it.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.bin";

            // Simulate a response stream with sample data
            using (System.IO.MemoryStream responseStream = new System.IO.MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes("Sample response data");
                responseStream.Write(data, 0, data.Length);
                responseStream.Position = 0;

                // Create a FileStream for the destination path and copy the response stream to it
                using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    responseStream.CopyTo(fileStream);
                }
            }

            Console.WriteLine("Data successfully written to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}