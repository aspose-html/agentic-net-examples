// Convert pixel dimensions to points for typography adjustments in a responsive design workflow.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 1920;
            double heightPixels = 1080;
            const double ppi = 96.0;
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;
            Console.WriteLine($"Width: {widthPixels}px = {widthPoints:F2} points");
            Console.WriteLine($"Height: {heightPixels}px = {heightPoints:F2} points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}