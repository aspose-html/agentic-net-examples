// Use Unit.FromPixels to calculate millimeter dimensions for a responsive grid layout.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double columnWidthPixels = 200.0;
            double rowHeightPixels = 100.0;

            // Convert pixels to millimeters (96 DPI, 25.4 mm per inch)
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;

            // Optionally create Length objects using Unit.FromPixels
            Length columnWidthLength = Unit.FromPixels(columnWidthPixels);
            Length rowHeightLength = Unit.FromPixels(rowHeightPixels);

            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}