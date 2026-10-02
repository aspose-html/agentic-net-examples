// Set PixelsPerInch to 96 for default conversion, then temporarily change to 144 for specific tasks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            const double defaultPpi = 96.0;
            double pixels = 200.0;

            // Conversion using default PPI (96)
            double inchesDefault = pixels / defaultPpi;
            Aspose.Html.Drawing.Length lengthDefault = Aspose.Html.Drawing.Length.FromInches(inchesDefault);
            double millimetersDefault = (pixels / defaultPpi) * 25.4;
            Console.WriteLine($"Default PPI: {defaultPpi}");
            Console.WriteLine($"Pixels: {pixels} => Inches: {inchesDefault:F4} => Millimeters: {millimetersDefault:F2}");

            // Temporary change to higher PPI (144) for specific tasks
            double temporaryPpi = 144.0;
            double inchesTemp = pixels / temporaryPpi;
            Aspose.Html.Drawing.Length lengthTemp = Aspose.Html.Drawing.Length.FromInches(inchesTemp);
            double millimetersTemp = (pixels / temporaryPpi) * 25.4;
            Console.WriteLine($"Temporary PPI: {temporaryPpi}");
            Console.WriteLine($"Pixels: {pixels} => Inches: {inchesTemp:F4} => Millimeters: {millimetersTemp:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}