// Override default PPI to 100 before converting pixel values for a custom design system.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 250.0;
            double customPpi = 100.0;
            double inches = pixels / customPpi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            System.Console.WriteLine($"Pixels: {pixels}, Custom PPI: {customPpi}, Inches: {inches:F4}");
            System.Console.WriteLine($"Length object: {length}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}