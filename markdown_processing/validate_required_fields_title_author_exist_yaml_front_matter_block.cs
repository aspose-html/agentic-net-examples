// Validate that required fields like title and author exist in the YAML front‑matter block.

using System;
using System.IO;

namespace FrontMatterValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please provide the path to the markdown file.");
                    return;
                }

                string path = args[0];
                string content = File.ReadAllText(path);
                if (!content.StartsWith("---"))
                {
                    Console.WriteLine("No YAML front-matter found.");
                    return;
                }

                int start = 3;
                int endIdx = content.IndexOf("\n---", start);
                if (endIdx == -1)
                {
                    Console.WriteLine("Invalid front-matter block.");
                    return;
                }

                string yaml = content.Substring(start, endIdx - start);
                bool hasTitle = false;
                bool hasAuthor = false;
                using (StringReader sr = new StringReader(yaml))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.StartsWith("title:"))
                            hasTitle = true;
                        else if (line.StartsWith("author:"))
                            hasAuthor = true;
                    }
                }

                if (hasTitle && hasAuthor)
                    Console.WriteLine("Front-matter validation passed: title and author are present.");
                else
                {
                    if (!hasTitle) Console.WriteLine("Missing required field: title");
                    if (!hasAuthor) Console.WriteLine("Missing required field: author");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}