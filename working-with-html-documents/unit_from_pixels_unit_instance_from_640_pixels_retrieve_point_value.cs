// Use Unit.FromPixels to create a unit instance from 640 pixels and retrieve its point value.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 96.0;
            double points = pixels * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixels} }} => {{ {points:F2} }} points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}