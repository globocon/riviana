using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Riviana.Pages.Mixing.Reports
{
    public class PhLogModel : PageModel
    {
        public List<PhLogEntry> Logs { get; set; } = new List<PhLogEntry>();

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public void OnGet()
        {
            Logs = new List<PhLogEntry>
            {
                new PhLogEntry { Id = 1, Date = DateTime.Now.Date, Type = "Calibration", Value = "Slope: 98%", CheckedBy = "Lab Tech", Status = "Pass" },
                new PhLogEntry { Id = 2, Date = DateTime.Now.Date, Type = "Check", Value = "pH 4.01", CheckedBy = "John Doe", Status = "Pass" },
                new PhLogEntry { Id = 3, Date = DateTime.Now.Date.AddDays(-1), Type = "Calibration", Value = "Slope: 99%", CheckedBy = "Lab Tech", Status = "Pass" },
                new PhLogEntry { Id = 4, Date = DateTime.Now.Date.AddDays(-1), Type = "Check", Value = "pH 7.05", CheckedBy = "Mike Jones", Status = "Pass" },
                new PhLogEntry { Id = 5, Date = DateTime.Now.Date.AddDays(-2), Type = "Calibration", Value = "Slope: 85%", CheckedBy = "Lab Tech", Status = "Fail" },
            };

            if (FilterDate.HasValue)
            {
                Logs = Logs.FindAll(l => l.Date.Date == FilterDate.Value.Date);
            }
        }

        public class PhLogEntry
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Type { get; set; } // Calibration or Check
            public string Value { get; set; }
            public string CheckedBy { get; set; }
            public string Status { get; set; }
        }
    }
}
