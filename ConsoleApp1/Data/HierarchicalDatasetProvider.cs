using System;
using System.Collections.Generic;
using CategoriesApp.Model;

namespace CategoriesApp
{
    /// <summary>
    /// Seed Data
    /// </summary>
    public static class HierarchicalDatasetProvider
    {
        public static ICollection<Category> Seed()
        {
            return new[]
            {
                new Category(100,"Bussiness","Money",
                    new Category(101, "Accounting", "Taxes",
                        new Category(103, "Corporate Tax" ),
                        new Category(109, "Small business Tax")),
                    new Category(102, "Taxation")),
                new Category(200,"Tutoring","Teaching",
                    new Category(201, "Computer", string.Empty,
                        new Category(202,"Operating System")))
        };


    }
}
}