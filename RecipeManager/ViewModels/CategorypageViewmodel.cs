using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.ViewModels;

public partial class CategorypageViewmodel : ObservableObject
{
    private readonly ICategoryService _categoryService;

    public CategorypageViewmodel(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        LoadData();
    }

    [ObservableProperty]
    private List<Category> _categories;

    private async void LoadData()
    {
        Categories = await _categoryService.GetCategories();
    }

    [RelayCommand]
    public async Task Tap(string name)
    {
        await Shell.Current.GoToAsync($"{nameof(RecipePage)}?CategoryName={name}",true);
    }
}

