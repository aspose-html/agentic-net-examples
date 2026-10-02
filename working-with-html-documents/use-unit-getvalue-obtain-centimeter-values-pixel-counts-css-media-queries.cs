// Use Unit.GetValue to obtain centimeter values from pixel counts for CSS media queries.

using System;

public class Program
{
    public static void Main()
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

            System.Console.WriteLine($"Width: {widthPixels}px = {widthCentimeters:F2}cm");
            System.Console.WriteLine($"Height: {heightPixels}px = {heightCentimeters:F2}cm");

            string mediaQuery = $"@media (min-width: {widthCentimeters:F2}cm) and (min-height: {heightCentimeters:F2}cm) {{ /* CSS rules */ }}";
            System.Console.WriteLine(mediaQuery);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}