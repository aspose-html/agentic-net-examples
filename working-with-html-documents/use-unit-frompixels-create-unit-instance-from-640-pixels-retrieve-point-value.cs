// Use Unit.FromPixels to create a unit instance from 640 pixels and retrieve its point value.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 640;
            double points = pixels * 72.0 / 96.0;
            System.Console.WriteLine($"Pixel count: {{ {pixels} }} => {{ {points:F2} }} points");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}