// Compare two MarkdownSyntaxTree objects for structural equality to detect unintended modifications during version control.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string path1 = "doc1.md";
                string path2 = "doc2.md";
                string md1 = System.IO.File.ReadAllText(path1);
                string md2 = System.IO.File.ReadAllText(path2);
                bool areEqual = md1 == md2;
                System.Console.WriteLine(areEqual ? "Markdown documents are identical." : "Markdown documents differ.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}