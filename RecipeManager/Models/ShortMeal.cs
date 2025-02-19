using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Models;

public class ShortMealRoot
{
    public List<ShortMeal> meals { get; set; }
}

public class ShortMeal
{
    public string strMeal { get; set; }
    public string strMealThumb { get; set; }
    public string idMeal { get; set; }
}
