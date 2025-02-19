namespace RecipeManager;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider service)
    {
        this
        .Behaviors(
            new StatusBarBehavior().StatusBarColor(AppColors.Primary)
        )

        .FlyoutBehavior(FlyoutBehavior.Disabled)
        .ShellNavBarIsVisible(false)
        .Items(

            new TabBar()
            .Items(

                new Tab()
                .Icon("food1.png")
                .Route(nameof(Homepage))
                .Items(service.GetService<Homepage>()),

                 new Tab()
                .Icon("dinner.png")
                .Route(nameof(Categorypage))
                .Items(service.GetService<Categorypage>()),

                 new Tab()
                .Icon("information.png")
                .Route(nameof(info1))
                .Items(service.GetService<info1>())
            )
        );
    }
}
