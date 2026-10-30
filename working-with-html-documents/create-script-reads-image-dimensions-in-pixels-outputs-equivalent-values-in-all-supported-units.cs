// Create a script that reads image dimensions in pixels and outputs equivalent values in all supported units.

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

            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            System.Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}