// Create a library method that accepts pixel values and returns a dictionary of all unit conversions.

using System;
using System.Collections.Generic;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 150;
            var conversions = ConvertPixelsToUnits(pixels);
            foreach (var kvp in conversions)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, double> ConvertPixelsToUnits(double pixelValue)
    {
        var length = Unit.FromPixels(pixelValue);
        var dict = new Dictionary<string, double>();
        dict["Pixels"] = length.GetValue(UnitType.Px);
        dict["Inches"] = length.GetValue(UnitType.In);
        dict["Centimeters"] = length.GetValue(UnitType.Cm);
        dict["Millimeters"] = length.GetValue(UnitType.Mm);
        dict["Points"] = length.GetValue(UnitType.Pt);
        dict["Picas"] = length.GetValue(UnitType.Pc);
        return dict;
    }
}