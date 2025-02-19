//using AVFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeManager.ViewModels;

public partial class HomepageViewmodel : ObservableObject
{
    

    private readonly IMealService _mealService;

    public HomepageViewmodel(IMealService mealService)
    {
        _mealService = mealService;
        LoadData();
    }

    [ObservableProperty]
    private List<Meal> _meals;

    [ObservableProperty]
    public string _searchText;


    private async void LoadData()
    {
        Meals = await _mealService.GetLatestMeals();
    }

       

    [RelayCommand]
    public async Task Search(string searchText)
    {
        
        Meals = await _mealService.GetMealDetailsByName(searchText);
    }




    [RelayCommand]
    public async Task Tap(string id)
    {
        await Shell.Current.GoToAsync($"{nameof(RecipeDetailsPage)}?MealId={id}", true);
    }



}
