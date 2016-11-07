using LanguageApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Pages
{
    public class CardCarouselScreenCS : CarouselPage
    {
        private List<DisplayObject> displayObjects;
        
        private int previous;
        private int current;
        private int next;

        //ContentPage C; // debug purposes

        private bool load;

        public CardCarouselScreenCS(List<DisplayObject> displayObjects)
        {
            previous = -1;
            current = 0;
            next = 1;

            load = false;
            //C = CurrentPage;  // debug purposes

            this.displayObjects = displayObjects;            
            
            // Add first 2 items
            this.Children.Add(new WordPageCS(displayObjects[0]));
            this.Children.Add(new WordPageCS(displayObjects[1]));

            load = true;
        }
        // Whenever a swipe occurs
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            //C = CurrentPage; // debug purposes
            if (load)
            {                
                if (CurrentPage.Equals(Children[Children.Count - 1]))
                {
                    SwipeLeft();    // Call to deal with a left swipe
                }
                else
                {
                    SwipeRight();   // Call to deal with a right swipe
                }
                // Garbage collection to remove any objects from memory that don't have a pointer associated to it
                GC.Collect();
            }            
        }
        // Method to be called whenever a left swipe has occured
        public void SwipeLeft()
        {
            previous += 1;
            current += 1;
            next += 1;
            if (current != displayObjects.Count - 1)
            {
                Children.Add((new WordPageCS(displayObjects[next])));       // Adding a new child in the next position           
            }
            if (previous > 0)
            {
                Children.RemoveAt(0);   // Removes first child
            }
        }
        // Method to be called whenever a right swipe has occured
        public void SwipeRight()
        {
            previous -= 1;
            current -= 1;
            next -= 1;
            if (current != 0)
            {
                Children.Insert(0, new WordPageCS(displayObjects[previous]));   // Adding a new child in the prevouis position 
            }
            if (next < displayObjects.Count - 1)
            {
                Children.RemoveAt(Children.Count - 1);  // Removes last child
            }
        }


    }
}
