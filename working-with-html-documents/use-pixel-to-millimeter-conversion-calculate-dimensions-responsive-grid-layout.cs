// Use Unit.FromPixels to calculate millimeter dimensions for a responsive grid layout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double columnWidthPixels = 200; // predefined pixel value for column width
            double rowHeightPixels = 150;   // predefined pixel value for row height

            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;

            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}