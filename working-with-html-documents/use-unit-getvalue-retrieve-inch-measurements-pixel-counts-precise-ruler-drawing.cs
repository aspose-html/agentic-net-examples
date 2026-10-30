// Use Unit.GetValue to retrieve inch measurements from pixel counts for precise ruler drawing.

class Program
{
    static void Main()
    {
        try
        {
            double pixelCount = 192.0;
            double inches = Aspose.Html.Drawing.Unit.FromPixels(pixelCount).GetValue(Aspose.Html.Drawing.UnitType.In);
            System.Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            double widthPixels = 800;
            double heightPixels = 600;
            double widthInches = Aspose.Html.Drawing.Unit.FromPixels(widthPixels).GetValue(Aspose.Html.Drawing.UnitType.In);
            double heightInches = Aspose.Html.Drawing.Unit.FromPixels(heightPixels).GetValue(Aspose.Html.Drawing.UnitType.In);
            System.Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in, Height: {heightPixels} px = {heightInches:F4} in");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}