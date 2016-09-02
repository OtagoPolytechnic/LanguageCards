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
        public WordPageCS(DisplayObject displayObject)
        {
            Padding = new Thickness(5, Device.OnPlatform(250, 100, 0), 5, 100);

            BackgroundColor = Color.Blue;

            //BackgroundImage = "ira_mountain.jpg";
            //this.Content { };

            var mountainBanner = new Image { };
            mountainBanner.Source = "ira_mountain.jpg";



            var cardLayout = new StackLayout
            {
                Children = {
                    new Frame {
                        Content = mountainBanner,
                    },
                    new Label {
                        Text = displayObject.orginal,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        HorizontalOptions = LayoutOptions.Center
                        },
                    new Label {
                        Text = displayObject.translation,
                        Font = Font.Default,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        HorizontalOptions = LayoutOptions.Center
                        }
                }
            };

            this.Content = new Frame {
                Content = cardLayout,
                OutlineColor = Color.Lime,
                HasShadow = true,
                BackgroundColor = Color.White, Opacity = 1
                //Margin = new Thickness()
                
            };

            
        }
    }
}
