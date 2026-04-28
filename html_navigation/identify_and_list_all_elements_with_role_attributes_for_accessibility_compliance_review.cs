// Identify and list all elements with role attributes for accessibility compliance review.

using System;
using Aspose.Html;

namespace RoleAttributeLister
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "input.html";
                HTMLDocument document = new HTMLDocument(filePath);
                var nodeList = document.QuerySelectorAll("[role]");
                foreach (var node in nodeList)
                {
                    if (node is HTMLElement element)
                    {
                        string role = element.GetAttribute("role");
                        Console.WriteLine($"Tag: {element.TagName}, Role: {role}");
                        Console.WriteLine(element.OuterHTML);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}