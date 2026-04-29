// Retrieve contrast ratio values for specific foreground and background colors and log any failures.

using System;
using System.Collections.Generic;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define foreground/background color pairs (hex strings)
            var colorPairs = new List<(string Foreground, string Background)>
            {
                ("#FFFFFF", "#000000"),
                ("#FF0000", "#00FF00"),
                ("#123456", "#654321")
            };

            foreach (var (fgHex, bgHex) in colorPairs)
            {
                Color fg = ColorTranslator.FromHtml(fgHex);
                Color bg = ColorTranslator.FromHtml(bgHex);
                double ratio = GetContrastRatio(fg, bg);
                // WCAG AA minimum contrast ratio for normal text is 4.5:1
                if (ratio < 4.5)
                {
                    Console.WriteLine($"FAIL: Contrast ratio between {fgHex} and {bgHex} is {ratio:F2}:1 (below 4.5)");
                }
                else
                {
                    Console.WriteLine($"PASS: Contrast ratio between {fgHex} and {bgHex} is {ratio:F2}:1");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Calculates the relative luminance of a color per WCAG definition
    static double GetLuminance(Color color)
    {
        double RsRGB = color.R / 255.0;
        double GsRGB = color.G / 255.0;
        double BsRGB = color.B / 255.0;

        double R = RsRGB <= 0.03928 ? RsRGB / 12.92 : Math.Pow((RsRGB + 0.055) / 1.055, 2.4);
        double G = GsRGB <= 0.03928 ? GsRGB / 12.92 : Math.Pow((GsRGB + 0.055) / 1.055, 2.4);
        double B = BsRGB <= 0.03928 ? BsRGB / 12.92 : Math.Pow((BsRGB + 0.055) / 1.055, 2.4);

        return 0.2126 * R + 0.7152 * G + 0.0722 * B;
    }

    // Calculates contrast ratio between two colors
    static double GetContrastRatio(Color fore, Color back)
    {
        double L1 = GetLuminance(fore);
        double L2 = GetLuminance(back);
        double lighter = Math.Max(L1, L2);
        double darker = Math.Min(L1, L2);
        return (lighter + 0.05) / (darker + 0.05);
    }
}