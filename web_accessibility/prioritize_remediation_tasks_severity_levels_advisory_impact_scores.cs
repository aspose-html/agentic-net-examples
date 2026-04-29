// Prioritize remediation tasks based on severity levels and advisory technique impact scores.

using System;
using System.Collections.Generic;
using System.Linq;

namespace PrioritizeRemediation
{
    class RemediationTask
    {
        public string Name { get; set; }
        public int Severity { get; set; }
        public double ImpactScore { get; set; }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                var tasks = new List<RemediationTask>
                {
                    new RemediationTask { Name = "Fix Alt Text", Severity = 3, ImpactScore = 8.5 },
                    new RemediationTask { Name = "Update ARIA Labels", Severity = 2, ImpactScore = 7.0 },
                    new RemediationTask { Name = "Remove Deprecated Tags", Severity = 1, ImpactScore = 5.5 }
                };

                var prioritized = tasks
                    .OrderByDescending(t => t.Severity)
                    .ThenByDescending(t => t.ImpactScore)
                    .ToList();

                foreach (var task in prioritized)
                {
                    Console.WriteLine($"{task.Name} - Severity: {task.Severity}, Impact: {task.ImpactScore}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}