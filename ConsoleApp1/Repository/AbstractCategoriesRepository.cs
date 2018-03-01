using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CategoriesApp.Model;

namespace CategoriesApp
{
    public abstract class AbstractCategoriesRepository
    {
        public abstract Category GetById(int id);
        public abstract ICollection<Category> CategoryNthLevel(int nth);
    }
}