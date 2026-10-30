// Use Unit.FromPixels to create units for both width and height, then retrieve their inch equivalents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 800;
            double heightPixels = 600;

            var widthLength = Aspose.Html.Drawing.Unit.FromPixels(widthPixels);
            var heightLength = Aspose.Html.Drawing.Unit.FromPixels(heightPixels);

            double widthInches = widthLength.GetValue(Aspose.Html.Drawing.UnitType.In);
            double heightInches = heightLength.GetValue(Aspose.Html.Drawing.UnitType.In);

            Console.WriteLine($"Width in inches: {widthInches:F4}");
            Console.WriteLine($"Height in inches: {heightInches:F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}