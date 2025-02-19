using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Utilities;

public class CategoryService : ICategoryService
{
    public async Task<List<Category>?> GetCategories()
    {
        var categories = await Client.Generate.GetFromJsonAsync<CategoryRoot>("categories.php");

        return categories?.categories;
    }
}
