using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace RecipeManager;

[MauiMarkup(typeof(StatusBarBehavior))]
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        builder.Services
            .AddSingleton<App>()
            .AddSingleton<AppShell>()
            .AddSingleton<info1>()
            .AddScoped<IMealService, MealService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScopedWithShellRoute<Homepage, HomepageViewmodel>(nameof(Homepage))
            .AddScopedWithShellRoute<Categorypage, CategorypageViewmodel>(nameof(Categorypage))
            .AddScopedWithShellRoute<RecipePage, RecipePageViewModel>(nameof(RecipePage))
            .AddScopedWithShellRoute<RecipeDetailsPage, RecipeDetailsPageViewModel>(nameof(RecipeDetailsPage));


        return builder.Build();
    }
}
