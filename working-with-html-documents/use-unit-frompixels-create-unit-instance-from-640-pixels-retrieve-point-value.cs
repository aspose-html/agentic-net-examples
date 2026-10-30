// Use Unit.FromPixels to create a unit instance from 640 pixels and retrieve its point value.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 640;
            var length = Aspose.Html.Drawing.Unit.FromPixels(pixels);
            double points = length.GetValue(Aspose.Html.Drawing.UnitType.Pt);
            Console.WriteLine($"Pixel count: {pixels} => {points:F2} points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}