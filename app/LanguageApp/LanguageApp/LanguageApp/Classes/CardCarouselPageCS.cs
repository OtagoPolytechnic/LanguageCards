using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class CardCarouselScreenCS : CarouselPage
    {
        public CardCarouselScreenCS(List<DisplayObject> displayObjects)
        {            
            
            if (displayObjects.Count == 0)
            {
                DisplayObject d = new DisplayObject("No words in Database", "", "");
                this.Children.Add(new WordPageCS(d));
            }
            else
            {
                foreach (DisplayObject d in displayObjects)
                {
                    this.Children.Add(new WordPageCS(d));

                }
            }

            BackgroundColor = Color.Red;
            
        }

    }
}
