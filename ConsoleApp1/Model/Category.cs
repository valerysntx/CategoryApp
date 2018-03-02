using System;
using System.Collections.Generic;
using System.Linq;

namespace CategoriesApp.Model
{
    /// <summary>
    ///  Category Node
    /// </summary>
    public sealed class Category : CategoryBase
    {
        public Category Parent { get; set; }
        public IEnumerable<Category> Child { get; }

        public Category(int id, 
                        string name = null, 
                        string keywords = null,
                        params Category[] child)
        {
            Id = id;
            Name = string.IsNullOrEmpty(name) ? Guid.NewGuid().ToString("N") : name;
            base.Keywords = keywords;
            
            Child =  new List<Category>(child).Select(x=> x);

            FixRecursively(Child, this);
        }

        public int ParentId
        {
            get {
                if (Parent != null) return Parent.Id;
                return -1;
            }
        }

        public int Level
        {
            get {
                if (Parent != null)
                {
                    return Parent.Level + 1;
                }
                return 1;
            }
        }

        /// <exception cref="ArgumentNullException">
        ///     <paramref name="category"/> is <see langword="null"/>
        /// </exception>
        public string GetKeywords(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            var keywords = ((category)as CategoryBase).Keywords;
            if (string.IsNullOrEmpty(keywords)) keywords = GetKeywords(category.Parent);
            return keywords;
        }

        public new string Keywords => string.IsNullOrEmpty(base.Keywords) ? GetKeywords(this) : base.Keywords;

        void FixRecursively(IEnumerable<Category> categories, Category parent)
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