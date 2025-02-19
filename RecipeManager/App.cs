namespace RecipeManager;

public partial class App : Application
{
    public App(IServiceProvider service)
    {
        this
        .Resources(new ResourceDictionary().MergedDictionaries(AppStyles.Default))
        .MainPage(service.GetService<AppShell>());
    }
}
