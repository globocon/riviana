using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Riviana.Pages.Mixing.Reports
{
    public class ToolsRegisterLogModel : PageModel
    {
        public List<ToolsLogEntry> Logs { get; set; } = new List<ToolsLogEntry>();

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public void OnGet()
        {
            Logs = new List<ToolsLogEntry>
            {
                new ToolsLogEntry { Id = 1, Date = DateTime.Now.Date, Product = "Product A", BatchLoad = "B123", ToolCount = 5, Operator = "John Doe" },
                new ToolsLogEntry { Id = 2, Date = DateTime.Now.Date, Product = "Product B", BatchLoad = "B124", ToolCount = 4, Operator = "John Doe" },
                new ToolsLogEntry { Id = 3, Date = DateTime.Now.Date.AddDays(-1), Product = "Product C", BatchLoad = "B120", ToolCount = 6, Operator = "Sarah Smith" },
            };

            if (FilterDate.HasValue)
            {
                Logs = Logs.FindAll(l => l.Date.Date == FilterDate.Value.Date);
            }
        }

        public class ToolsLogEntry
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Product { get; set; }
            public string BatchLoad { get; set; }
            public int ToolCount { get; set; }
            public string Operator { get; set; }
        }
    }
}
