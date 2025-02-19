using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RecipeManager.ViewModels;
[QueryProperty(nameof(CategoryName), nameof(CategoryName))]
public partial class RecipePageViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMealService _mealService;

    public RecipePageViewModel(IMealService mealService)
    {
        _mealService = mealService;
        LoadData();
    }

    [ObservableProperty]
    private string _categoryName;

    [ObservableProperty]
    private List<ShortMeal> _meals;

    private async void LoadData()
    {
        Meals = await _mealService.GetMealsByCategory(CategoryName);
    }

    [RelayCommand]
    public async Task Tap(string id)
    {
        await Shell.Current.GoToAsync($"{nameof(RecipeDetailsPage)}?MealId={id}",true);
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("..", true);
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        CategoryName = HttpUtility.UrlDecode(query[nameof(CategoryName)].ToString());

        LoadData();
    }
}
