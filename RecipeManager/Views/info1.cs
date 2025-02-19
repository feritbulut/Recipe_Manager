
using FmgLib.MauiMarkup;

namespace RecipeManager.Views;

public class info1 : ContentPage, IFmgLibHotReload
{
    public info1()
    {
        this.InitializeHotReload();
    }

    public void Build()
    {
        this
          .Content(
            new Grid()
                .RowDefinitions(e => e.Auto().Auto().Star())
                .Spacing(20)
                .Children(
                    new Border()
                    .BackgroundColor(AppColors.Primary)
                    .Margin(-1)
                    .StrokeShape(new RoundRectangle().CornerRadius(0, 0, 16, 16))
                    .Content(

                        new Label()
                        .BackgroundColor(AppColors.Primary)
                        
                        .FillHorizontal()
                        .HorizontalOptions(LayoutOptions.Fill)
                        .Text("Information               ")
                        .TextColor(White)
                        .MaxLines(2)
                        .LineBreakMode(LineBreakMode.TailTruncation)
                        .FontAttributes(Bold)
                        .FontSize(30)
                        .Margin(10, 5, 5, 0)
                        .AlignCenterLeft()
                    ),
                   
                    new Border()
                    .BackgroundColor (AppColors.Primary)
                    .Row(1)
                    .StrokeThickness(1)
                    .StrokeShape(new RoundRectangle().CornerRadius(20))
                    
                    .HeightRequest(570)
                    .Margin(15, 0)
                    .Content(
                         new ScrollView()
                       //.Row(1)
                       .VerticalScrollBarVisibility(Never)
                       .Content(
                       new Label()
                        .Column(1)
                        .Text("This app developed by Ferit Bulut.")
                        .TextColor(White)
                        
                        .FontAttributes(Bold)
                        .FontSize(30)
                        .Margin(10, 10, 0, 0)
                        //.AlignCenterLeft()
                    ))
                    


                    
                    


                )
          );
    }
}