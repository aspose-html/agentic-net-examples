// Create a PowerShell function that wraps the .NET Converter API for SVG to JPEG conversion with quality parameter.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string script = @"
function Convert-SvgToJpeg {
    param(
        [string]$SvgPath,
        [string]$OutputPath,
        [int]$Quality
    )
    try {
        $options = New-Object Aspose.Html.Saving.ImageSaveOptions([Aspose.Html.Rendering.Image.ImageFormat]::Jpeg)
        $options.HorizontalResolution = $Quality
        $options.VerticalResolution = $Quality
        [Aspose.Html.Converters.Converter]::ConvertSVG($SvgPath, $options, $OutputPath)
        Write-Host ""Conversion succeeded.""
    } catch {
        Write-Error $_.Exception.Message
    }
}
";
            File.WriteAllText("ConvertSvgToJpeg.ps1", script);
            Console.WriteLine("PowerShell function script generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}