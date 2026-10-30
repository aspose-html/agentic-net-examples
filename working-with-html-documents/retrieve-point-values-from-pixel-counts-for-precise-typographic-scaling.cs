// Use Unit.GetValue to retrieve point values from pixel counts for precise typographic scaling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 96.0;
            var length = Aspose.Html.Drawing.Unit.FromPixels(pixels);
            double points = length.GetValue(Aspose.Html.Drawing.UnitType.Pt);
            System.Console.WriteLine($"Pixel count: {pixels} => {points:F2} points");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}