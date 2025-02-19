using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RecipeManager.ViewModels;
[QueryProperty(nameof(MealId), nameof(MealId))]
public partial class RecipeDetailsPageViewModel : ObservableObject,IQueryAttributable
{
    private readonly IMealService _mealService;

    public RecipeDetailsPageViewModel(IMealService mealService)
    {
        _mealService = mealService;
        LoadData();
    }

    [ObservableProperty]
    private string _MealId;

    [ObservableProperty]
    private Meal _myMeal;

    private async void LoadData()
    {
        MyMeal = await _mealService.GetMealDetailsById(MealId);
    }

    [RelayCommand]
    public async Task Tap(string url)
    {
        try
        {
            if (string.IsNullOrEmpty(url))
            {
                await Shell.Current.DisplayAlert("Info", "There is not videos.", "OK");
            }

            Uri uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception) { }
    }

    [RelayCommand]
    public async Task ShareTap()
    {
        var text = $@"{MyMeal.strMeal}

{MyMeal.strInstructions}

{(string.IsNullOrEmpty(MyMeal.strYoutube) ? "" : $"Youtube video link: {MyMeal.strYoutube}")}
";
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = MyMeal.strMeal
        });
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("..", true);
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        MealId = HttpUtility.UrlDecode(query[nameof(MealId)].ToString());

        LoadData();
    }
}
