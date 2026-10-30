// Retrieve contrast ratio values for specific foreground and background colors and log any failures.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define sample foreground/background color pairs
            var colorPairs = new (Color Foreground, Color Background)[]
            {
                (Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0)),       // White on Black
                (Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255)),       // Black on White
                (Color.FromArgb(120, 120, 120), Color.FromArgb(255, 255, 255)), // Gray on White
                (Color.FromArgb(255, 0, 0), Color.FromArgb(255, 255, 0)),       // Red on Yellow
                (Color.FromArgb(0, 0, 255), Color.FromArgb(0, 255, 0))          // Blue on Lime
            };

            const double MinimumContrastRatio = 4.5; // WCAG AA for normal text

            foreach (var pair in colorPairs)
            {
                double ratio = ComputeContrastRatio(pair.Foreground, pair.Background);
                string result = ratio >= MinimumContrastRatio ? "PASS" : "FAIL";
                Console.WriteLine($"Foreground: #{pair.Foreground.R:X2}{pair.Foreground.G:X2}{pair.Foreground.B:X2}, " +
                                  $"Background: #{pair.Background.R:X2}{pair.Background.G:X2}{pair.Background.B:X2}, " +
                                  $"Contrast Ratio: {ratio:F2} - {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static double ComputeContrastRatio(Color fg, Color bg)
    {
        double lum1 = ComputeRelativeLuminance(fg);
        double lum2 = ComputeRelativeLuminance(bg);
        double lighter = Math.Max(lum1, lum2);
        double darker = Math.Min(lum1, lum2);
        return (lighter + 0.05) / (darker + 0.05);
    }

    static double ComputeRelativeLuminance(Color color)
    {
        // Convert sRGB components to linear values
        double RsRGB = color.R / 255.0;
        double GsRGB = color.G / 255.0;
        double BsRGB = color.B / 255.0;

        double R = (RsRGB <= 0.03928) ? RsRGB / 12.92 : Math.Pow((RsRGB + 0.055) / 1.055, 2.4);
        double G = (GsRGB <= 0.03928) ? GsRGB / 12.92 : Math.Pow((GsRGB + 0.055) / 1.055, 2.4);
        double B = (BsRGB <= 0.03928) ? BsRGB / 12.92 : Math.Pow((BsRGB + 0.055) / 1.055, 2.4);

        // Calculate luminance
        return 0.2126 * R + 0.7152 * G + 0.0722 * B;
    }
}