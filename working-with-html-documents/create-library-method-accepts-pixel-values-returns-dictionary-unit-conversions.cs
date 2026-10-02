// Create a library method that accepts pixel values and returns a dictionary of all unit conversions.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            double samplePixels = 150.0;
            var conversions = ConvertPixels(samplePixels);
            foreach (var kvp in conversions)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value:F4}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, double> ConvertPixels(double pixels)
    {
        const double ppi = 96.0;
        var dict = new Dictionary<string, double>();

        double inches = pixels / ppi;
        double centimeters = inches * 2.54;
        double millimeters = centimeters * 10.0;
        double points = pixels * 72.0 / ppi;
        double picas = inches * 6.0;

        dict["Inches"] = inches;
        dict["Centimeters"] = centimeters;
        dict["Millimeters"] = millimeters;
        dict["Points"] = points;
        dict["Picas"] = picas;

        return dict;
    }
}