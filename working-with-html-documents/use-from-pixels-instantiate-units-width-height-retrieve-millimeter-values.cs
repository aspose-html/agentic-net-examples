// Use Unit.FromPixels to instantiate units for both width and height, then retrieve millimeter values.

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

            double widthMillimeters = (widthPixels / ppi) * 25.4;
            double heightMillimeters = (heightPixels / ppi) * 25.4;

            System.Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            System.Console.WriteLine($"Height: {heightMillimeters:F2} mm");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}