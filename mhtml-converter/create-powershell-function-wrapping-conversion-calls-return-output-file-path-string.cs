// Create a PowerShell function that wraps conversion calls and returns the output file path as a string.

class Program
{
    static void Main()
    {
        try
        {
            string psScript = @"function Convert-HTMLToPdf {
    param(
        [string]$htmlPath,
        [string]$pdfPath
    )
    Add-Type -Path 'Aspose.Html.dll'
    $document = New-Object Aspose.Html.HTMLDocument $htmlPath
    $options = New-Object Aspose.Html.Saving.PdfSaveOptions
    [Aspose.Html.Converters.Converter]::ConvertHTML($document, $options, $pdfPath) | Out-Null
    return $pdfPath
}";
            string scriptPath = "ConvertHtmlToPdf.ps1";
            System.IO.File.WriteAllText(scriptPath, psScript);
            System.Console.WriteLine("PowerShell function script created at: " + scriptPath);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}