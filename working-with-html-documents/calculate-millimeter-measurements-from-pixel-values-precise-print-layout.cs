// Calculate millimeter measurements from pixel values for precise print layout using Unit.GetValue.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 800;
            double heightPixels = 600;

            double widthMillimeters = Aspose.Html.Drawing.Unit.FromPixels(widthPixels).GetValue(Aspose.Html.Drawing.UnitType.Mm);
            double heightMillimeters = Aspose.Html.Drawing.Unit.FromPixels(heightPixels).GetValue(Aspose.Html.Drawing.UnitType.Mm);

            Console.WriteLine($"Width: {widthPixels} px = {widthMillimeters:F2} mm");
            Console.WriteLine($"Height: {heightPixels} px = {heightMillimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}