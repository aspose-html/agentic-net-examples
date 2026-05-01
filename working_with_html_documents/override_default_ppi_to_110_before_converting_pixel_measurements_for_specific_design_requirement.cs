// Override default PPI to 110 before converting pixel measurements for a specific design requirement.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 220.0;
            double ppi = 110.0;
            double inches = pixels / ppi;
            Length length = Length.FromInches(inches);
            Console.WriteLine($"Pixels: {pixels}, PPI: {ppi}, Inches: {inches:F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}