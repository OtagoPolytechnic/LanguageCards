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
                //this.Children.Add(new NoCardsAvailablePage);
            }
            else
            {
                foreach (DisplayObject d in displayObjects)
                {
                    this.Children.Add(new WordPageCS(d));

                }
            }
            
            BackgroundImage = "icon.png";
            
        }

    }
}
