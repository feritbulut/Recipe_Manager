using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Utilities;

public interface IMealService
{
    Task<Meal?> GetMealDetailsById(string id);
    Task<List<Meal>?> GetMealDetailsByName(string name);
    Task<List<ShortMeal>?> GetMealsByCategory(string categoryName);
    Task<List<ShortMeal>?> GetMealsByIngredient(string ingredientName);
    Task<List<Meal>?> GetLatestMeals();
    Task<List<Meal>?> GetRandomMeals();
}
