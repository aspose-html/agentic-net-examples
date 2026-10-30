// Use the Unit class to transform 1024 pixel width into centimeters for layout calculations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 1024.0;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Unit.FromPixels(widthPixels);
            double widthCentimeters = length.GetValue(Aspose.Html.Drawing.UnitType.Cm);
            System.Console.WriteLine($"Width: {widthPixels} px = {widthCentimeters:F2} cm");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}