// Use Unit.GetValue to obtain inch measurements from pixel counts for margin calculations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double leftMarginPixels = 96.0; // 1 inch
            double topMarginPixels = 48.0;  // 0.5 inch

            Aspose.Html.Drawing.Length leftLength = Aspose.Html.Drawing.Unit.FromPixels(leftMarginPixels);
            Aspose.Html.Drawing.Length topLength = Aspose.Html.Drawing.Unit.FromPixels(topMarginPixels);

            double leftInches = leftLength.GetValue(Aspose.Html.Drawing.UnitType.In);
            double topInches = topLength.GetValue(Aspose.Html.Drawing.UnitType.In);

            Console.WriteLine($"Left margin: {leftMarginPixels} px => {leftInches:F4} inches");
            Console.WriteLine($"Top margin: {topMarginPixels} px => {topInches:F4} inches");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}