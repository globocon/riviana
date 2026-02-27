using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Riviana.Pages.Admin
{
    public class ProductsModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            // Mock Data mimicking SAP import
            Products = new List<Product>
            {
                new Product
                {
                    Id = "SAP-1001",
                    Name = "Classic Mayonnaise for Dips",
                    Description = "Standard mayo base for dip production",
                    BatchNumber = "3 BATCHES (15 LOADS)",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "American Mustard", Quantity = "1.57 Kg / 7.84 Kg" },
                        new Ingredient { Name = "Canola Oil", Quantity = "34 L / 169 L" },
                        new Ingredient { Name = "Free Range Egg White", Quantity = "780 G / 3.92 Kg" },
                        new Ingredient { Name = "Free Range Egg Yolk Unsalted", Quantity = "3.92 Kg / 19.60 Kg" },
                        new Ingredient { Name = "Lemon Juice (Frozen)", Quantity = "290 G / 1.43 Kg" },
                        new Ingredient { Name = "Salt Olsons", Quantity = "472 G / 2.36 Kg" },
                        new Ingredient { Name = "Water", Quantity = "1.44 L / 7.2 L" },
                        new Ingredient { Name = "White Vinegar 10%", Quantity = "430 G / 2.14 Kg" }
                    }
                },
                new Product
                {
                    Id = "SAP-1002",
                    Name = "Garlic Aioli Bulk",
                    Description = "Bulk garlic aioli for food service",
                    BatchNumber = "BATCH-2024-002",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Garlic Paste", Quantity = "5 Kg" },
                        new Ingredient { Name = "Canola Oil", Quantity = "100 L" },
                        new Ingredient { Name = "Egg Yolk", Quantity = "10 Kg" },
                        new Ingredient { Name = "Vinegar", Quantity = "2 L" }
                    }
                }
            };
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BatchNumber { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
