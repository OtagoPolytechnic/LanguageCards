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
        private double lineWidth;

        public WordPageCS(DisplayObject displayObject)
            :base(displayObject)
        {
            this.display = displayObject;
            Padding = new Thickness(0, 0, 0, 0);

            // Relative layout
            var r = new RelativeLayout()
            {
                //HeightRequest = 300
            };
            var layout = new AbsoluteLayout();
            
            // Sound button
            Button soundButton = new Button { };
            soundButton.Image = "ic_volume_up_black_24dp";
            soundButton.BackgroundColor = Color.White;
            // Mountain Banner
            var mountainBanner = new Image { };
            mountainBanner.Source = "ira_mountain.jpg";
            lineWidth = mountainBanner.Width;
            // Left Arrow
            var leftArrow = new Image { };
            leftArrow.Source = "ic_chevron_left_black_24dp.png";
            // Right Arrow
            var rightArrow = new Image { };
            rightArrow.Source = "ic_chevron_right_black_24dp.png";
            
            // Moari word
            Label originalLabel = new WordLabel
            {
                Text = displayObject.original,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            // English word
            Label translatedLabel = new WordLabel
            {
                Text = displayObject.translation,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalTextAlignment = TextAlignment.Center
            };

            var wordSeparator = new BoxView
            {
                Color = Color.Black,
                HeightRequest = 1,
                WidthRequest = Width
            };

            r.Children.Add(leftArrow, Constraint.Constant(0), Constraint.Constant(0));
            r.Children.Add(wordSeparator, Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Width), Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Height / 2), Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Parent.Width - (Sibling.Width * 2)));
            r.Children.Add(rightArrow, Constraint.RelativeToView(wordSeparator, (Parent, Sibling) => Sibling.X + Sibling.Width), Constraint.Constant(0));

            // Stack layout
            var cardLayout = new StackLayout();
            cardLayout.Children.Add(mountainBanner);
            cardLayout.Children.Add(originalLabel);
            cardLayout.Children.Add(r);
            cardLayout.Children.Add(translatedLabel);
            cardLayout.Children.Add(soundButton);
            
            
             
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
            Content = cardLayout,
            OutlineColor = Color.Lime,
            HasShadow = true,
            BackgroundColor = Color.White, Opacity = 1
                
            };

            
        }
    }
}
