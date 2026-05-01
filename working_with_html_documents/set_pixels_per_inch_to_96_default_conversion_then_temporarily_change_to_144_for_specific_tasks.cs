// Set PixelsPerInch to 96 for default conversion, then temporarily change to 144 for specific tasks.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 300;
            double defaultPpi = 96.0;
            double inchesDefault = pixels / defaultPpi;
            Console.WriteLine($"Pixels: {pixels} at {defaultPpi} PPI = {inchesDefault:F4} inches");

            double tempPpi = 144.0;
            double inchesTemp = pixels / tempPpi;
            Console.WriteLine($"Pixels: {pixels} at {tempPpi} PPI = {inchesTemp:F4} inches");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}