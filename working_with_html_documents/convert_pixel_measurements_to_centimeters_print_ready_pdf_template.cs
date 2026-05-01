// Convert pixel measurements to centimeters for use in a print‑ready PDF template.

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
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;
            Console.WriteLine($"Width: {widthCentimeters:F2} cm");
            Console.WriteLine($"Height: {heightCentimeters:F2} cm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}