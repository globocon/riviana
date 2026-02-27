using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Riviana.Pages.Admin
{
    public class DailyScheduleModel : PageModel
    {
        public List<MixingItem> MixingSchedule { get; set; } = new List<MixingItem>();
        public List<PackingItem> PackingSchedule { get; set; } = new List<PackingItem>();
        public List<GlassRoomItem> GlassRoomSchedule { get; set; } = new List<GlassRoomItem>();
        public string CurrentDate { get; set; }

        public void OnGet()
        {
            CurrentDate = System.DateTime.Now.ToString("dd/MM/yyyy");

            // Mock Data from Screenshot
            MixingSchedule = new List<MixingItem>
            {
                new MixingItem { ProductId = "5385652", ProductName = "MNA Black Swan Crispy Bacon and Onion", LoadBatch = "3 Batches", Mixer = "Big", StartTime = "6:20am", EndTime = "7:30am" },
                new MixingItem { ProductId = "5385401", ProductName = "FTA Basil Pesto 1x10kg", LoadBatch = "1 Batch", Mixer = "Big", StartTime = "7:45am", EndTime = "8:20am" },
                new MixingItem { ProductId = "4702411", ProductName = "AME Dill & Pickle 12x500g", LoadBatch = "10", Mixer = "Big", StartTime = "8:45am", EndTime = "10am" },
                new MixingItem { ProductId = "2371015", ProductName = "RGO Dill & Parsley 6x240ml", LoadBatch = "3 Batches", Mixer = "Big", StartTime = "10:30am", EndTime = "11:30am" },
                new MixingItem { ProductId = "2371011", ProductName = "RGO Mayonnaise 6x240ml", LoadBatch = "3 Batches", Mixer = "Big", StartTime = "12pm", EndTime = "1pm" },

                new MixingItem { ProductId = "4702001", ProductName = "SDE Basil Chunky 6x150g", LoadBatch = "20", Mixer = "Small", StartTime = "6:20am", EndTime = "7:45am" },
                new MixingItem { ProductId = "4702004", ProductName = "SDE Roasted Pumpkin Chunky 6x150g", LoadBatch = "15", Mixer = "Small", StartTime = "8am", EndTime = "9am" },
                new MixingItem { ProductId = "4702003", ProductName = "SDE Sundried Tomato Chunky 6x150g", LoadBatch = "12", Mixer = "Small", StartTime = "1:30pm", EndTime = "2:20pm" }
            };

            PackingSchedule = new List<PackingItem>
            {
                new PackingItem { ProductId = "5385652", ProductName = "MNA Black Swan Crispy Bacon and Onion", CtnsPlanned = "2000", PackLine = "JK", StartTime = "7:20am", EndTime = "2:30pm" },
                new PackingItem { ProductId = "4702601", ProductName = "PIC Mex Queso 12x500g", CtnsPlanned = "65", PackLine = "G", StartTime = "2:45pm", EndTime = "3:45pm" }
            };

            GlassRoomSchedule = new List<GlassRoomItem>
            {
                 new GlassRoomItem { ProductId = "2371088", ProductName = "RGO Traditional Pesto 6x200ml", CtnsPlanned = "768", GlassRoom = "Glass Room", StartTime = "7:40am", EndTime = "2:30pm" }
            };
        }
    }

    public class MixingItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string LoadBatch { get; set; }
        public string Mixer { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

    public class PackingItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CtnsPlanned { get; set; }
        public string PackLine { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

    public class GlassRoomItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CtnsPlanned { get; set; }
        public string GlassRoom { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
