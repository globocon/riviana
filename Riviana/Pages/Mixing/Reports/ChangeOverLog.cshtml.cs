using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Riviana.Pages.Mixing.Reports
{
    public class ChangeOverLogModel : PageModel
    {
        public List<ChangeOverLogEntry> Logs { get; set; } = new List<ChangeOverLogEntry>();

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public void OnGet()
        {
            Logs = new List<ChangeOverLogEntry>
            {
                new ChangeOverLogEntry { Id = 1, Date = DateTime.Now.Date, Product = "Product A", Mixer = "Mixer 1", StartTime = "07:00 AM", EndTime = "07:30 AM", Status = "Approved", Operator = "John Doe" },
                new ChangeOverLogEntry { Id = 2, Date = DateTime.Now.Date, Product = "Product B", Mixer = "Mixer 1", StartTime = "10:00 AM", EndTime = "10:45 AM", Status = "Approved", Operator = "Mike Jones" },
                new ChangeOverLogEntry { Id = 3, Date = DateTime.Now.Date.AddDays(-1), Product = "Product C", Mixer = "Mixer 2", StartTime = "08:15 AM", EndTime = "09:00 AM", Status = "Approved", Operator = "Sarah Smith" },
                new ChangeOverLogEntry { Id = 4, Date = DateTime.Now.Date.AddDays(-1), Product = "Product A", Mixer = "Mixer 1", StartTime = "02:00 PM", EndTime = "02:30 PM", Status = "Pending", Operator = "John Doe" },
            };

            if (FilterDate.HasValue)
            {
                Logs = Logs.FindAll(l => l.Date.Date == FilterDate.Value.Date);
            }
        }

        public class ChangeOverLogEntry
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Product { get; set; }
            public string Mixer { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string Status { get; set; }
            public string Operator { get; set; }
        }
    }
}
