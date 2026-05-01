// Convert pixel dimensions to points for typography adjustments in a responsive design workflow.

using System;

namespace PixelToPointsConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define pixel dimensions
                double widthPixels = 800;
                double heightPixels = 600;

                // Pixels per inch (standard screen DPI)
                const double ppi = 96.0;

                // Convert pixels to inches
                double widthInches = widthPixels / ppi;
                double heightInches = heightPixels / ppi;

                // Convert inches to points (1 inch = 72 points)
                double widthPoints = widthInches * 72.0;
                double heightPoints = heightInches * 72.0;

                // Output the results
                Console.WriteLine($"Width: {widthPixels}px = {widthPoints:F2}pt");
                Console.WriteLine($"Height: {heightPixels}px = {heightPoints:F2}pt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}