using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Riviana.Pages.Mixing.Reports
{
    public class PreStartLogModel : PageModel
    {
        public List<PreStartLogEntry> Logs { get; set; } = new List<PreStartLogEntry>();

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public void OnGet()
        {
            // Dummy Data Generation
            // In a real app, this would come from a database based on FilterDate
            
            Logs = new List<PreStartLogEntry>
            {
                new PreStartLogEntry { Id = 1, Date = DateTime.Now.Date, Time = "06:00 AM", TeamLeader = "John Doe", OverallStatus = "Pass", Notes = "All checks passed." },
                new PreStartLogEntry { Id = 2, Date = DateTime.Now.Date.AddDays(-1), Time = "05:55 AM", TeamLeader = "Sarah Smith", OverallStatus = "Pass", Notes = "Minor extensive cleaning required on Mixer 2." },
                new PreStartLogEntry { Id = 3, Date = DateTime.Now.Date.AddDays(-2), Time = "06:10 AM", TeamLeader = "Mike Jones", OverallStatus = "Fail", Notes = "Scales calibration failed. Maintenance called." },
                new PreStartLogEntry { Id = 4, Date = DateTime.Now.Date.AddDays(-3), Time = "06:00 AM", TeamLeader = "John Doe", OverallStatus = "Pass", Notes = "Standard start." },
                new PreStartLogEntry { Id = 5, Date = DateTime.Now.Date.AddDays(-4), Time = "06:05 AM", TeamLeader = "Emma Wilson", OverallStatus = "Pass", Notes = "" }
            };

            if (FilterDate.HasValue)
            {
                Logs = Logs.FindAll(l => l.Date.Date == FilterDate.Value.Date);
            }
        }

        public class PreStartLogEntry
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Time { get; set; }
            public string TeamLeader { get; set; }
            public string OverallStatus { get; set; } // Pass/Fail
            public string Notes { get; set; }
        }
    }
}
