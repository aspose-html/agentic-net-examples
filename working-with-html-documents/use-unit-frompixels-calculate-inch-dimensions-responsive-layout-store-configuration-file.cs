// Use Unit.FromPixels to calculate inch dimensions for a responsive layout and store them in a configuration file.

public class Program
{
    public static void Main()
    {
        try
        {
            double widthPixels = 800;
            double heightPixels = 600;

            var widthLength = Aspose.Html.Drawing.Unit.FromPixels(widthPixels);
            var heightLength = Aspose.Html.Drawing.Unit.FromPixels(heightPixels);

            double widthInches = widthLength.GetValue(Aspose.Html.Drawing.UnitType.In);
            double heightInches = heightLength.GetValue(Aspose.Html.Drawing.UnitType.In);

            var config = new System.Collections.Generic.Dictionary<string, double>
            {
                { "WidthInches", widthInches },
                { "HeightInches", heightInches }
            };
            string json = System.Text.Json.JsonSerializer.Serialize(config);
            System.IO.File.WriteAllText("layoutConfig.json", json);

            System.Console.WriteLine($"Width in inches: {widthInches}");
            System.Console.WriteLine($"Height in inches: {heightInches}");
            System.Console.WriteLine("Configuration saved to layoutConfig.json");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}