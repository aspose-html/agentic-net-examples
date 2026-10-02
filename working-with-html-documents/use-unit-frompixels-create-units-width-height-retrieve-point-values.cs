// Use Unit.FromPixels to create units for both width and height, then retrieve point values for each.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            System.Console.WriteLine($"Width in points: {widthPoints}");
            System.Console.WriteLine($"Height in points: {heightPoints}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}