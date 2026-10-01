// Use Unit.FromPixels to calculate millimeter dimensions for a responsive grid layout.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                double columnWidthPixels = 200;
                double rowHeightPixels = 100;

                double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
                double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;

                System.Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
                System.Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}