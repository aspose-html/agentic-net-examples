// Use Unit.GetValue to obtain centimeter values from pixel counts for CSS media queries.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            // Convert pixels to centimeters using Unit.GetValue
            double widthCentimeters = Aspose.Html.Drawing.Unit.FromPixels(widthPixels)
                .GetValue(Aspose.Html.Drawing.UnitType.Cm);
            double heightCentimeters = Aspose.Html.Drawing.Unit.FromPixels(heightPixels)
                .GetValue(Aspose.Html.Drawing.UnitType.Cm);

            // Output results
            System.Console.WriteLine($"Width: {widthPixels} px = {widthCentimeters:F2} cm");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightCentimeters:F2} cm");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}