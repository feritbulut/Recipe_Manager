using CommunityToolkit.Maui.Extensions;
using FmgLib.MauiMarkup;
using Microsoft.Maui.Graphics.Text;


namespace RecipeManager.Views;

public class Homepage : ContentPage, IFmgLibHotReload
{
    private readonly HomepageViewmodel viewmodel;
    private readonly IMealService _mealService;


    private View CreateSearchBar()
    {
        var searchBar = new SearchBar()
            .Margin(-10, 0, 0, 0)
            .CancelButtonColor(Colors.Red)
            .Placeholder("Search")
            .PlaceholderColor(White)
            .TextColor(White)
            .BackgroundColor(Color.FromArgb("#6F4F3C"))
            .SearchCommand(viewmodel.SearchCommand);

        // Binding ayrý bir satýrda tanýmlanmalý
        searchBar.SetBinding(SearchBar.SearchCommandParameterProperty,
            new Binding("Text", source: new RelativeBindingSource(RelativeBindingSourceMode.Self)));

        return searchBar;
    }

    public Homepage(HomepageViewmodel viewmodel, IMealService mealService)
    {
        this.viewmodel = viewmodel;
        this._mealService = mealService;
        this.InitializeHotReload();


        
    }


    
    public void Build()
    {
        this
        .BindingContext(viewmodel)
        //.BackgroundColor(AppColors.Primary)
        .Content(
           new Grid()
           .RowDefinitions(e => e.Auto().Star())
           .Margin(-1, -5)
           .Children(
               new Grid()
               .ColumnDefinitions(e => e.Auto().Star())
               .Children(

                   new Border()
                   .BackgroundColor(AppColors.Primary)
                   .Stroke(AppColors.Primary)
                   .StrokeShape(new RoundRectangle().CornerRadius(0, 0, 16, 16))
                   .StrokeThickness(1)
                   .Content(
                       new Label()
                       .Text("Latest Recipes")
                       .TextColor(White)
                       .FontAttributes(Bold)
                       .FontSize(35)
                       .Margin(5, 5, 5, 0)
                       .AlignCenterLeft()

                   ),

                   new Border()
                   .Column(1)

                   .FillHorizontal()
                   .BackgroundColor(Color.FromArgb("#6F4F3C"))
                   .Stroke(Color.FromArgb("#6F4F3C"))
                   .StrokeShape(new RoundRectangle().CornerRadius(0, 0, 16, 16))
                   .StrokeThickness(1)
                   .Content(
                       CreateSearchBar()

                   )
               ),
               new CollectionView()
               .Row(1)
               .ItemsLayout(new LinearItemsLayout(ItemsLayoutOrientation.Vertical).ItemSpacing(5))
               .ItemsSource(e => e.Path("Meals"))
               .ItemTemplate(new DataTemplate(() =>

                   new Border()
                   .Background(Transparent)
                   .Stroke(Transparent)
                   .StrokeThickness(1)
                   .StrokeShape(new RoundRectangle().CornerRadius(20))
                   .HeightRequest(250)
                   .Content(
                       new Grid()
                       .RowDefinitions(e => e.Star(8).Star(2))
                       .BackgroundColor(White)
                       .FillHorizontal()
                       .GestureRecognizers(
                           new TapGestureRecognizer().Command(viewmodel.TapCommand).CommandParameter(e => e.Path("idMeal"))
                       )
                       .Children(
                           new Image()
                           .Row(0)
                           .RowSpan(2)
                           .Source(e => e.Path("strMealThumb"))
                           .Aspect(Aspect.AspectFill),

                           new Border()
                           .Row(1)
                           .BackgroundColor(AppColors.Primary)
                           .Stroke(AppColors.Primary)
                           //.StrokeShape(new RoundRectangle().CornerRadius(0))
                           .Padding(10, 0)
                           .Content(
                               new Label()
                               .MaxLines(1)
                               .LineBreakMode(LineBreakMode.TailTruncation)
                               .FontSize(20)
                               .AlignCenterLeft()
                               .TextColor(White)
                               .FontAttributes(Bold)
                               .Text(e => e.Path("strMeal"))


                           )
                       )


                   )
               ))




           )
           

        );
    }



}