// Use Unit.FromPixels to create a unit from 500 pixels and retrieve its centimeter value.

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 500;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Unit.FromPixels(pixels);
            double centimeters = length.GetValue(Aspose.Html.Drawing.UnitType.Cm);
            System.Console.WriteLine($"Pixels: {pixels} = {centimeters:F2} cm");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}