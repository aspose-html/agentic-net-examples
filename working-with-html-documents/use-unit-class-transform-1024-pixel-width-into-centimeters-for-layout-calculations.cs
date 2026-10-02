// Use the Unit class to transform 1024 pixel width into centimeters for layout calculations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 1024;
            const double ppi = 96.0;
            double widthInches = widthPixels / ppi;
            double widthCentimeters = widthInches * 2.54;
            Console.WriteLine($"Width: {widthPixels} px = {widthCentimeters:F2} cm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}