using Chapter4.Models.Pages;
using System.Collections.Generic;

namespace Chapter4.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        PagedList<Category> GetCategories(QueryOptions options);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
