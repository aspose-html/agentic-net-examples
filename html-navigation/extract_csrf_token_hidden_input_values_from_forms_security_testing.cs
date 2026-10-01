// Extract CSRF token hidden input values from forms for security testing purposes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"
<!DOCTYPE html>
<html>
<head><title>Sample Form</title></head>
<body>
    <form action='/submit' method='post'>
        <input type='hidden' name='csrf_token' value='abc123xyz' />
        <input type='text' name='username' />
        <input type='password' name='password' />
        <button type='submit'>Login</button>
    </form>
    <form action='/update' method='post'>
        <input type='hidden' name='csrfmiddlewaretoken' value='def456uvw' />
        <input type='text' name='email' />
        <button type='submit'>Update</button>
    </form>
</body>
</html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            var csrfInputs = document.QuerySelectorAll("input[type=hidden][name*='csrf']");

            foreach (var node in csrfInputs)
            {
                Aspose.Html.HTMLElement element = node as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    string name = element.GetAttribute("name");
                    string value = element.GetAttribute("value");
                    Console.WriteLine($"{name}: {value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}