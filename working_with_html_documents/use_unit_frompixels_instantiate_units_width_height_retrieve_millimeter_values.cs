// Use Unit.FromPixels to instantiate units for both width and height, then retrieve millimeter values.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 300;
            double heightPixels = 150;

            Length width = Unit.FromPixels(widthPixels);
            Length height = Unit.FromPixels(heightPixels);

            double widthMillimeters = width.GetValue(UnitType.Mm);
            double heightMillimeters = height.GetValue(UnitType.Mm);

            Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            Console.WriteLine($"Height: {heightMillimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}