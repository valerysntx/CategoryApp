namespace CategoriesApp.Model
{
    public class CategoryBase : ICategoryBase
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public string Keywords { get; set; }

        protected CategoryBase(int id, int parentId, int level, string name, string keywords)
        {
            Id = id;
            ParentId = parentId;
            Level = level;
            Name = name;
            Keywords = keywords;
        }

        protected CategoryBase()
        {
        }
    }
}