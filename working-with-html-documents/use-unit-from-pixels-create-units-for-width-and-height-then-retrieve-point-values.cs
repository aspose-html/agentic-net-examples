// Use Unit.FromPixels to create units for both width and height, then retrieve point values for each.

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

            double widthPoints = widthLength.GetValue(Aspose.Html.Drawing.UnitType.Pt);
            double heightPoints = heightLength.GetValue(Aspose.Html.Drawing.UnitType.Pt);

            Console.WriteLine($"Width: {widthPixels} px = {widthPoints} pt");
            Console.WriteLine($"Height: {heightPixels} px = {heightPoints} pt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}