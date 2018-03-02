namespace CategoriesApp.Model
{
    public interface ICategoryBase
    {
        int Id { get; set; }
        string Keywords { get; set; }
        string Name { get; set; }
        int ParentId { get; set; }
        int Level { get; set; }
    }
}