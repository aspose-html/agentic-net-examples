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
            // Sample HTML document creation using Aspose.HTML (demonstration purpose)
            string htmlContent = "<html><body><p>Sample</p></body></html>";
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Document is not used further; just ensures Aspose.HTML usage.
            }

            // Define foreground and background color pairs to test
            var colorPairs = new List<Tuple<Color, Color>>
            {
                Tuple.Create(Color.Black, Color.White),
                Tuple.Create(Color.DarkGray, Color.LightGray),
                Tuple.Create(Color.FromArgb(255, 0, 0), Color.FromArgb(255, 255, 0)), // red on yellow
                Tuple.Create(Color.FromArgb(0, 128, 0), Color.FromArgb(255, 255, 255)), // green on white
                Tuple.Create(Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255)) // white on white (failure)
            };

            const double minimumContrast = 4.5; // WCAG AA for normal text

            for (int i = 0; i < colorPairs.Count; i++)
            {
                Color fore = colorPairs[i].Item1;
                Color back = colorPairs[i].Item2;
                double ratio = ComputeContrastRatio(fore, back);
                string result = ratio >= minimumContrast ? "PASS" : "FAIL";
                Console.WriteLine($"Pair {i + 1}: Foreground={fore}, Background={back}, Contrast Ratio={ratio:F2} - {result}");
                if (result == "FAIL")
                {
                    Console.WriteLine($"  Failure: Contrast ratio {ratio:F2} is below the required {minimumContrast}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static double ComputeContrastRatio(Color fore, Color back)
    {
        double l1 = ComputeRelativeLuminance(fore);
        double l2 = ComputeRelativeLuminance(back);
        double lighter = Math.Max(l1, l2);
        double darker = Math.Min(l1, l2);
        return (lighter + 0.05) / (darker + 0.05);
    }

    static double ComputeRelativeLuminance(Color color)
    {
        double RsRGB = color.R / 255.0;
        double GsRGB = color.G / 255.0;
        double BsRGB = color.B / 255.0;

        double R = RsRGB <= 0.03928 ? RsRGB / 12.92 : Math.Pow((RsRGB + 0.055) / 1.055, 2.4);
        double G = GsRGB <= 0.03928 ? GsRGB / 12.92 : Math.Pow((GsRGB + 0.055) / 1.055, 2.4);
        double B = BsRGB <= 0.03928 ? BsRGB / 12.92 : Math.Pow((BsRGB + 0.055) / 1.055, 2.4);

        return 0.2126 * R + 0.7152 * G + 0.0722 * B;
    }
}