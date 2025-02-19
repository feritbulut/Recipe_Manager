using FmgLib.MauiMarkup;

namespace RecipeManager.Views;

public class RecipeDetailsPage : ContentPage, IFmgLibHotReload
{
    private readonly RecipeDetailsPageViewModel viewModel;

    public RecipeDetailsPage(RecipeDetailsPageViewModel viewModel)
    {
        this.viewModel = viewModel;
        this.InitializeHotReload();
    }
    public RecipeDetailsPage()
    {
        this.InitializeHotReload();
    }

    public void Build()
    {
        this
        .BindingContext(viewModel)
        .BackgroundColor(AppColors.Primary)
        .Content(
             new Grid()
           .RowDefinitions(e => e.Auto().Auto().Star())
           .Spacing(10)
           .Children(
               new Grid()
                   .ColumnDefinitions(e => e.Auto().Star())

                   .Children(
                       new ImageButton()
                       .Source("abc.png")
                       .SizeRequest(40)
                       .Margin(10)
                       .AlignCenterLeft()
                       .Command(viewModel.BackCommand),

                       new Label()
                       .Column(1)
                       .Text(e => e.Path("MyMeal.strMeal"))
                       .MaxLines(2)
                       .LineBreakMode(LineBreakMode.TailTruncation)
                       .TextColor(White)
                       .FontAttributes(Bold)
                       .FontSize(30)
                       .Margin(10, 5, 0, 0)
                       .AlignCenterLeft()
                   ),

               new Border()
                .Row(1)
                .Background(Transparent)
                .Stroke(Transparent)
                .StrokeThickness(1)
                .StrokeShape(new RoundRectangle().CornerRadius(20))
                .HeightRequest(200)
                .Margin(15, 0)
                .Content(
                    new Image()
                    .Source(e => e.Path("MyMeal.strMealThumb"))
                    .Aspect(Aspect.Fill)
                ),

               new Border()
                .Row(2)
                .Background(White)
                .Stroke(White)
                .StrokeThickness(1)
                .StrokeShape(new RoundRectangle().CornerRadius(20, 20, 0, 0))
                .Content(
                   new Grid()
                   .RowDefinitions(e => e.Auto().Star())
                   .Margin(10)
                   .Children(
                       new Grid()
                       .Margin(5,0)
                       .ColumnDefinitions(e => e.Star(60).Star(20).Star(20))
                       .Children(
                           new Label()
                           .Text("Instructions:")
                           .TextColor(Black)
                           .FontSize(28)
                           .FontAttributes(Bold),

                           new ImageButton()
                           .Column(e => e.Path("MyMeal.strYoutube").Convert((string x) => ! string.IsNullOrEmpty(x) ? 1 : 2))
                           .Source("send.png")
                           .SizeRequest(35)
                           .AlignRight()
                           .Command(viewModel.ShareTapCommand),

                           new ImageButton()
                           .Column(2)
                           .Source("youtube.png")
                           .SizeRequest(40)
                           .AlignRight()
                           .IsVisible(e => e.Path("MyMeal.strYoutube").Convert((string x) => !string.IsNullOrEmpty(x)))
                           .Command(viewModel.TapCommand)
                            .CommandParameter(e => e.Path("MyMeal.strYoutube"))

                       ),

                       new ScrollView()
                       .Row(1)
                       .VerticalScrollBarVisibility(Never)
                       .Content(
                           new Label()
                           .FontSize(18)
                           .FontAttributes(Bold)
                           .Text(e => e.Path("MyMeal.strInstructions"))
                           .LineBreakMode(LineBreakMode.CharacterWrap)
                           
                       )
                       
                   )
                   
                )
           )
        );
    }
}