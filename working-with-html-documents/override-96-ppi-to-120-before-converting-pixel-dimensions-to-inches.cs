// Override the default 96 PPI value to 120 before converting pixel dimensions to inches.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 300.0;
            double ppi = 120.0;
            double inches = pixels / ppi;
            Length length = Length.FromInches(inches);
            Console.WriteLine($"Pixels: {pixels}, PPI: {ppi}, Inches: {inches:F4}");
            Console.WriteLine($"Length (in inches): {length.GetValue(UnitType.In):F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}