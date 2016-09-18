using LanguageApp.Classes;
using LanguageApp.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Pages
{
    public class WordPageCS : DisplayPage
    {
        private DisplayObject display;
        public WordPageCS(DisplayObject displayObject)
            :base(displayObject)
        {
            this.display = displayObject;
            Padding = new Thickness(0, 0, 0, 0);

            // Relative layout
            var relativeLayout = new RelativeLayout();
            
            // Sound button
            Button soundButton = new Button { };
            soundButton.Image = "ic_volume_up_black_24dp";
            soundButton.BackgroundColor = Color.White;
            // Mountain Banner
            var mountainBanner = new Image { };
            mountainBanner.Source = "ira_mountain.jpg";
            // Left Arrow
            var leftArrow = new Image { };
            leftArrow.Source = "ic_chevron_left_black_24dp.png";
            // Right Arrow
            var rightArrow = new Image { };
            rightArrow.Source = "ic_chevron_right_black_24dp.png";           
            
            // SHOULD BE TRANSLATED NOT ORIGINAL . SWITCH WITH OTHER LABEL. TRANSLATED ABOVE 
            Label translatedLabel = new WordLabel
            {
                Text = displayObject.translation,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label originalLabel = new WordLabel
            {
                Text = displayObject.original,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalOptions = LayoutOptions.Center
            };

            //var wordSeparator = new BoxView
            //{
            //    Color = Color.Black,
            //    //VerticalOptions = LayoutOptions.,
            //    HeightRequest = 1,
            //    WidthRequest = mountainBanner.Width
            //};


            // Stack layout
            var cardLayout = new StackLayout();
            cardLayout.Children.Add(mountainBanner);
            cardLayout.Children.Add(translatedLabel);
            cardLayout.Children.Add(originalLabel);
            // -- Positioning for controls --

            // Mountain image
            relativeLayout.Children.Add(mountainBanner, Constraint.Constant(0), Constraint.Constant(0));
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
            //relativeLayout.Children.Add(wordSeparator,
            //    Constraint.RelativeToParent((Parent) =>
            //    {
            //        return leftArrow.Width;
            //    }),
            //    Constraint.RelativeToParent((Parent) =>
            //    {
            //        return (Parent.Height / 2) + (leftArrow.Height / 2);
            //    }),
            //    Constraint.RelativeToParent((Parent) =>
            //    {
            //        return Parent.Width - (leftArrow.Width + rightArrow.Width);
            //    }),
            //    Constraint.RelativeToParent((Parent) =>
            //    {
            //        return 1;
            //    }));
            // Original label
            relativeLayout.Children.Add(originalLabel,
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Width / 2) - (originalLabel.Width / 2);
                }),
                Constraint.RelativeToParent((Parent) =>
                {
                    return (Parent.Height / 2) + (originalLabel.Height);
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

             
            //
            soundButton.Clicked += (sender, e) =>
            {
                string soundClip = "SoundFiles/" + displayObject.original + ".mp3";

                try
                {
                    DependencyService.Get<IAudioPlayer>().PlayAudioFile(soundClip);
                }
                catch (Exception)
                {
                }
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
