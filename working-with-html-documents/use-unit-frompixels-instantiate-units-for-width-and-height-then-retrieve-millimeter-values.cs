// Use Unit.FromPixels to instantiate units for both width and height, then retrieve millimeter values.

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

            double widthMillimeters = widthLength.GetValue(Aspose.Html.Drawing.UnitType.Mm);
            double heightMillimeters = heightLength.GetValue(Aspose.Html.Drawing.UnitType.Mm);

            System.Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            System.Console.WriteLine($"Height: {heightMillimeters:F2} mm");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}