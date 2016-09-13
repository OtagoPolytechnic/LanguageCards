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
            Padding = new Thickness(0, 0, 0, 0);

            BackgroundColor = Color.Blue;

            // Relative layout
            var relativeLayout = new RelativeLayout();
            
                        
            Button soundButton = new Button { };
            soundButton.Image = "ic_volume_up_black_24dp";
            soundButton.BackgroundColor = Color.White;

            var mountainBanner = new Image { };
            mountainBanner.Source = "ira_mountain.jpg";

            var leftArrow = new Image { };
            leftArrow.Source = "ic_chevron_left_black_24dp.png";

            var rightArrow = new Image { };
            rightArrow.Source = "ic_chevron_right_black_24dp.png";           

            Frame image = new Frame
            {
                Content = mountainBanner
            };
            // SHOULD BE TRANSLATED NOT ORIGINAL . SWITCH WITH OTHER LABEL. TRANSLATED ABOVE 
            Label translatedLabel = new WordLabel
            {
                Text = displayObject.orginal,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label orginalLabel = new WordLabel
            {
                Text = displayObject.translation,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalOptions = LayoutOptions.Center
            };

            var wordSeparator = new BoxView
            {
                Color = Color.Black,
                //VerticalOptions = LayoutOptions.,
                HeightRequest = 1,
                WidthRequest = image.Width
            };

            // Stack layout
            var cardLayout = new StackLayout();
            cardLayout.Children.Add(image);
            cardLayout.Children.Add(translatedLabel);
            cardLayout.Children.Add(orginalLabel);

            
            // -- Positioning for controls --

            // Mountain image
            relativeLayout.Children.Add(image, Constraint.Constant(0), Constraint.Constant(0));
            // Translated label
            relativeLayout.Children.Add(translatedLabel,
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Width / 2) - (translatedLabel.Width / 2);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Height / 2) - (translatedLabel.Height);
                }));
            // Separator
           
            relativeLayout.Children.Add(wordSeparator,
                Constraint.RelativeToParent((Parent) =>
                {
                    return leftArrow.Width;
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Height / 2) + (leftArrow.Height / 2);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return Parent.Width - (leftArrow.Width + rightArrow.Width);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return 1;
                }));
            // Original label
            relativeLayout.Children.Add(orginalLabel,
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Width / 2) - (orginalLabel.Width / 2);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Height / 2) + (orginalLabel.Height);
                }));
            // Left arrow
            relativeLayout.Children.Add(leftArrow,
                Constraint.RelativeToParent((Parent) =>
                {
                    return 0;
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Height / 2);
                }));
            // Right arrow
            relativeLayout.Children.Add(rightArrow,
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Width - rightArrow.Width);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Height / 2);
                }));
            // Sound Image / button
            relativeLayout.Children.Add(soundButton,
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Width / 2) - (soundButton.Width / 2);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return Parent.Height - (soundButton.Height * 1.5);
                }));

            // Sound button click handler
            soundButton.Clicked += (sender, e) =>
            {
                //soundButton.Image = "ira_mountain.jpg";
            };


            this.Content = new Frame {
            Content = relativeLayout,
            OutlineColor = Color.Lime,
            HasShadow = true,
            BackgroundColor = Color.White, Opacity = 1
                
            };

            
        }
    }
}
