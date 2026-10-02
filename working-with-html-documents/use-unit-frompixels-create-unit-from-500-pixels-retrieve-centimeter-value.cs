// Use Unit.FromPixels to create a unit from 500 pixels and retrieve its centimeter value.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 500;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Unit.FromPixels(pixels);
            double centimeters = length.GetValue(Aspose.Html.Drawing.UnitType.Cm);
            Console.WriteLine($"Pixels: {pixels} = {centimeters:F2} cm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}