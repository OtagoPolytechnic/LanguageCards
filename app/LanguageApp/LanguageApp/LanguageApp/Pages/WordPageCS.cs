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
            : base(displayObject)
        {
            this.display = displayObject;
            Padding = new Thickness(0, 0, 0, 0);

            // Relative layout
            var relativeLayout = new RelativeLayout();

            // Sound button
            Button soundButton = new Button
            {
                Image = "ic_volume_up_black_24dp",
                BackgroundColor = Color.White
            };
            // Mountain Banner
            var mountainBanner = new Image
            {
                Source = "ira_mountain.jpg"
            };
            // Left Arrow
            var leftArrow = new Image
            {
                Source = "ic_chevron_left_black_24dp.png"
            };
            // Right Arrow
            var rightArrow = new Image
            {
                Source = "ic_chevron_right_black_24dp.png"
            };
            // original is maori word
            Label originalLabel = new WordLabel
            {
                Text = displayObject.original,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            // translated is english word
            Label translatedLabel = new WordLabel
            {
                Text = displayObject.translation,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(WordLabel)),
                HorizontalTextAlignment = TextAlignment.Center
            };            
            // word seperator
            var wordSeparator = new BoxView
            {
                Color = Color.Black,
                //VerticalOptions = LayoutOptions.,
                HeightRequest = 1,
                WidthRequest = mountainBanner.Width
            };

            // -- Positioning for controls --

            ContentView orginial = new ContentView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Content = originalLabel
            };
            ContentView translated = new ContentView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Content = translatedLabel
            };
            ContentView sound = new ContentView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Content = soundButton
            };

            // Mountain image
            relativeLayout.Children.Add(mountainBanner, Constraint.Constant(0), Constraint.Constant(0));
            // Left arrow
            relativeLayout.Children.Add(leftArrow,
                Constraint.RelativeToParent((Parent) => 0),
                Constraint.RelativeToParent((Parent) => Parent.Height / 2));
            // Separator           
            relativeLayout.Children.Add(wordSeparator,
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Width), 
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Y + Sibling.Height / 2), 
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Parent.Width - (Sibling.Width * 2)));
            // Right arrow
            relativeLayout.Children.Add(rightArrow,
                Constraint.RelativeToView(wordSeparator, (Parent, Sibling) => Sibling.X + Sibling.Width),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Y));
            // Original label
            relativeLayout.Children.Add(orginial,
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Width),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Y - Sibling.Height),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Parent.Width - (Sibling.Width * 2)));
            //relativeLayout.Children.Add(originalLabel,
            //    Constraint.RelativeToView(wordSeparator, (Parent, Sibling) => Sibling.X + ((Sibling.Width / 2) - (originalLabel.Width / 2))),
            //    Constraint.RelativeToView(wordSeparator, (Parent, Sibling) => Sibling.Y - (originalLabel.Height * 1.5)));
            // Translated label
            relativeLayout.Children.Add(translated,
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Width),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Y + Sibling.Height),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Parent.Width - (Sibling.Width * 2)));
            //relativeLayout.Children.Add(translatedLabel,
            //    Constraint.RelativeToView(wordSeparator, (Parent, Sibling) => Sibling.X + ((Sibling.Width / 2) - (translatedLabel.Width / 2))),
            //    Constraint.RelativeToView(wordSeparator, (Parent, Sibling) => Sibling.Y + (translatedLabel.Height * 0.5)));            
            // Sound Image / button
          
            relativeLayout.Children.Add(sound,
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Width),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Y * 1.5),
                Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Parent.Width - (Sibling.Width * 2)));
            //Constraint.RelativeToView(leftArrow, (Parent, Sibling) => Sibling.Y * 2 - soundButton.Height));


            //
            soundButton.Clicked += (sender, e) =>
            {
                string soundClip = "SoundFiles/" + displayObject.pk + ".mp3";

                try
                {
                    DependencyService.Get<IAudioPlayer>().PlayAudioFile(soundClip);
                }
                catch (Exception)
                {
                }
            };


            this.Content = new Frame
            {
                Content = relativeLayout,
                OutlineColor = Color.Lime,
                HasShadow = true,
                BackgroundColor = Color.White,
                Opacity = 1

            };


        }
    }
}
