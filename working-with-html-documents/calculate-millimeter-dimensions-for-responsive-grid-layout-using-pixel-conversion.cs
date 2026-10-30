// Use Unit.FromPixels to calculate millimeter dimensions for a responsive grid layout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double columnWidthPixels = 200;
            double rowHeightPixels = 100;

            Aspose.Html.Drawing.Length columnLength = Aspose.Html.Drawing.Unit.FromPixels(columnWidthPixels);
            Aspose.Html.Drawing.Length rowLength = Aspose.Html.Drawing.Unit.FromPixels(rowHeightPixels);

            double columnWidthMillimeters = columnLength.GetValue(Aspose.Html.Drawing.UnitType.Mm);
            double rowHeightMillimeters = rowLength.GetValue(Aspose.Html.Drawing.UnitType.Mm);

            System.Console.WriteLine($"Column width: {{ {columnWidthPixels} }}px = {{ {columnWidthMillimeters:F2} }} mm");
            System.Console.WriteLine($"Row height: {{ {rowHeightPixels} }}px = {{ {rowHeightMillimeters:F2} }} mm");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}