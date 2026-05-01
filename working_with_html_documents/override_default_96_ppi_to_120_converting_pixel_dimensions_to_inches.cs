// Override the default 96 PPI value to 120 before converting pixel dimensions to inches.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Example pixel value
            double pixels = 300;

            // Override default PPI (96) with 120
            double ppi = 120.0;

            // Convert pixels to inches using the overridden PPI
            double inches = pixels / ppi;

            // Create a Length object from the computed inches
            Length length = Length.FromInches(inches);

            // Output the conversion details
            Console.WriteLine($"Pixels: {pixels}, PPI: {ppi}, Inches: {inches:F4}");
            Console.WriteLine($"Length object created from inches.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}