// Override default PPI to 100 before converting pixel values for a custom design system.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 250;
            double ppi = 100;
            double inches = pixels / ppi;
            Length length = Length.FromInches(inches);
            Console.WriteLine($"Pixels: {pixels}, PPI: {ppi}, Inches: {inches:F4}, Length: {length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}