// Override the default 96 PPI value to 120 before converting pixel dimensions to inches.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            double pixels = 300.0;
            double ppi = 120.0;
            double inches = pixels / ppi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            System.Console.WriteLine($"Pixels: {pixels}, PPI: {ppi}, Inches: {inches:F4}");
            System.Console.WriteLine($"Length object: {length}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}