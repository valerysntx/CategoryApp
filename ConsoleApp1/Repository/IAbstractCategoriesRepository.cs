using System.Collections.Generic;
using CategoriesApp.Model;

namespace CategoriesApp.Repository
{
    public interface ICategoriesRepository<TCategory>
    {
        ICollection<TCategory> CategoryNthLevel(int nth);
        TCategory GetById(int id);
    }
}