// Convert pixel dimensions to points for typography adjustments in a responsive design workflow.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            double widthPixels = 800;
            double heightPixels = 600;

            // Convert to points (1 point = 1/72 inch, 1 inch = 96 pixels)
            double widthPoints = widthPixels * 72.0 / 96.0;
            double heightPoints = heightPixels * 72.0 / 96.0;

            System.Console.WriteLine($"Width in points: {widthPoints:F2}");
            System.Console.WriteLine($"Height in points: {heightPoints:F2}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}