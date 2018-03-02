using System;
using System.Linq;
using CategoriesApp.Model;
using CategoriesApp.Repository;
using Newtonsoft.Json;

namespace CategoriesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                MaxDepth = 3,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };


            var categories = HierarchicalDatasetProvider.Seed();
            var repository = new CategoriesRepository(categories);


            ProcessCategoryId(201);
            ProcessCategoryId(202);

            ProcessCategoryLevel(2);
            ProcessCategoryLevel(3);


            void ProcessCategoryId(int id)
            {
                var result = repository.GetById(201);
                Console.WriteLine($"by category id: {id} >>>");
                Console.WriteLine(JsonConvert.SerializeObject(new {result.ParentId, result.Name, result.Keywords }));

                Console.ReadLine();
            }

            void ProcessCategoryLevel(int level)
            {
                var result = repository.CategoryNthLevel(level).Select(x=> new { x.Id, x.Level });
                Console.WriteLine($"by level: {level} >>>");
                Console.WriteLine(JsonConvert.SerializeObject(result));

                Console.ReadLine();
            }


        }
    }
}

