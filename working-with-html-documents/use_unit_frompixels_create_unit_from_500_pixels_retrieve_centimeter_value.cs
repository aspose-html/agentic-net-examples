// Use Unit.FromPixels to create a unit from 500 pixels and retrieve its centimeter value.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 150.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            System.Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}