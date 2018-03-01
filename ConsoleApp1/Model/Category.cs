using System;
using System.Collections.Generic;

namespace CategoriesApp.Model
{
    /// <summary>
    ///  Category Node
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public int ParentId
        {
            get
            {
                if (Parent != null) return Parent.Id;
                return -1;
            }
        }

        public string Name { get; set; }
        public string Keywords { get; set; }

        public virtual Category Parent { get; set; }
        public virtual IList<Category> Child { get; }

        public int Level
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Level + 1;
                }
                return 1;
            }
        }

        public Category(int id, 
                        string name = null, 
                        string keywords = null,
                        params Category[] child)
        {
            Id = id;
            Name = string.IsNullOrEmpty(name) ? Guid.NewGuid().ToString("N") : name;
            Keywords = keywords;
            
            Child = child == null ? null : new List<Category>(child);

            FixRecursively(child, this);
        }


        void FixRecursively(ICollection<Category> categories, Category parent)
        {
            if (categories != null)
                foreach (var category in categories)
                {
                    category.Parent = parent;
                    FixRecursively(category.Child, category);
                }
        }

    }
}