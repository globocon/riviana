using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Riviana.Pages.Mixing.Reports
{
    public class CleaningLogModel : PageModel
    {
        public List<CleaningLogEntry> Logs { get; set; } = new List<CleaningLogEntry>();

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public void OnGet()
        {
            Logs = new List<CleaningLogEntry>
            {
                new CleaningLogEntry { Id = 1, Date = DateTime.Now.Date, Equipment = "Mixer 1", Frequency = "Daily", Level = "3", Operator = "John Doe" },
                new CleaningLogEntry { Id = 2, Date = DateTime.Now.Date, Equipment = "Table 1", Frequency = "Daily", Level = "1", Operator = "John Doe" },
                new CleaningLogEntry { Id = 3, Date = DateTime.Now.Date, Equipment = "Floor Area", Frequency = "Daily", Level = "2", Operator = "Mike Jones" },
                new CleaningLogEntry { Id = 4, Date = DateTime.Now.Date.AddDays(-1), Equipment = "Mixer 1", Frequency = "Daily", Level = "3", Operator = "Sarah Smith" },
            };

            if (FilterDate.HasValue)
            {
                Logs = Logs.FindAll(l => l.Date.Date == FilterDate.Value.Date);
            }
        }

        public class CleaningLogEntry
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Equipment { get; set; }
            public string Frequency { get; set; }
            public string Level { get; set; }
            public string Operator { get; set; }
        }
    }
}
