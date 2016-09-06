using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class WordPageCS : ContentPage
    {
        public DisplayObject Display { get; }

        public WordPageCS(DisplayObject displayObject)
        {
            this.Display = displayObject;

            Padding = new Thickness(0, 0, 0, 0);

            BackgroundColor = Color.Blue;

            //BackgroundImage = "ira_mountain.jpg";
            //this.Content { };

            Button soundButton = new Button { };
            //soundButton.Image = "ic_volume_up_black_24dp.png";

            var mountainBanner = new Image { };
            mountainBanner.Source = "ira_mountain.jpg";
            
            Frame image = new Frame
            {
                Content = mountainBanner
            };
            
            Label translatedLabel = new Label
            {
                Text = displayObject.orginal,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label orginalLabel = new Label
            {
                Text = displayObject.translation,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Stack layout
            var cardLayout = new StackLayout();
            cardLayout.Children.Add(image);
            cardLayout.Children.Add(translatedLabel);
            cardLayout.Children.Add(orginalLabel);

            // Relative layout
            var relativeLayout = new RelativeLayout();

            //relativeLayout.Children.Add(image, Constraint.Constant(0), Constraint.Constant(0));
            relativeLayout.Children.Add(translatedLabel,
                Constraint.RelativeToParent((Parent) =>
                {
                    return Parent.Width / 2;
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return Parent.Height / 2;
                }));

            //relativeLayout.Children.Add(orginalLabel, Constraint.RelativeToView(translatedLabel), Constraint.Constant(0));


            this.Content = new Frame {
                Content = cardLayout,
                OutlineColor = Color.Lime,
                HasShadow = true,
                BackgroundColor = Color.White, Opacity = 1
                
            };

            
        }
    }
}
