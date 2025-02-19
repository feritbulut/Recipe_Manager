using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Utilities;

public interface ICategoryService
{
    Task<List<Category>?> GetCategories();
}
