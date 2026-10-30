// Use Unit.GetValue to obtain millimeter values from pixel counts for precise cut‑line placement.

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

            System.Console.WriteLine($"Width: {widthPixels} px = {widthMillimeters:F2} mm");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightMillimeters:F2} mm");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}