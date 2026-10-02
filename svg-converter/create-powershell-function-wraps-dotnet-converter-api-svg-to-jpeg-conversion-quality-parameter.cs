// Create a PowerShell function that wraps the .NET Converter API for SVG to JPEG conversion with quality parameter.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string psScript = @"function Convert-SvgToJpeg {
    param(
        [string]$svgPath,
        [string]$outputPath,
        [int]$quality
    )
    # Load Aspose.Html assembly (adjust the path if necessary)
    Add-Type -Path ""Aspose.Html.dll""
    $options = New-Object Aspose.Html.Saving.ImageSaveOptions([Aspose.Html.Rendering.Image.ImageFormat]::Jpeg)
    # Quality is not directly supported; using it to adjust resolution as an example
    $options.HorizontalResolution = $quality * 10
    $options.VerticalResolution = $quality * 10
    [Aspose.Html.Converters.Converter]::ConvertSVG($svgPath, $options, $outputPath)
    Write-Host ""SVG converted to JPEG: $outputPath""
}";
            System.IO.File.WriteAllText("ConvertSvgToJpeg.ps1", psScript);
            System.Console.WriteLine("PowerShell script 'ConvertSvgToJpeg.ps1' has been created.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}