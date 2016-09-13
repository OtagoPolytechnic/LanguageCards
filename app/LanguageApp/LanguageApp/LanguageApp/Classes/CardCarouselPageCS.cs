using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class CardCarouselScreenCS : CarouselPage
    {
        private List<DisplayObject> displayObjects;
        List<WordPageCS> currentPages;
        
        private int previous;
        private int current;
        private int next;

        private bool load;
        private bool started;
        // Create list/stack of 3 display objects?

        public CardCarouselScreenCS(List<DisplayObject> displayObjects)
        {
            previous = -1;
            current = 0;
            next = 1;
            load = false;
            started = false;

            this.displayObjects = displayObjects;

            currentPages = new List<WordPageCS>();

            
            
            
            this.Children.Add(new WordPageCS(displayObjects[0]));
            this.Children.Add(new WordPageCS(displayObjects[1]));

            load = true;
            //CurrentPageChanged += HandleCurrentPageChanged;

        }

        //protected override void OnPagesChanged(NotifyCollectionChangedEventArgs e)
        //{
        //    base.OnPagesChanged(e);

        //    e.Action
        //}

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if (load)
            {
                if (CurrentPage.Equals(Children[Children.Count - 1]))
                {
                    SwipeLeft();
                }
                else
                {
                    SwipeRight();
                }
            }
        }

        public void SwipeLeft()
        {
            previous += 1;
            current += 1;
            next += 1;
            if (next <= displayObjects.Count - 1)
            {
                Children.Add((new WordPageCS(displayObjects[next])));
                if (previous > 0)
                {
                    Children.RemoveAt(0);
                }
            }
        }

        public void SwipeRight()
        {
            previous -= 1;
            current -= 1;
            next -= 1;
            if (previous > 0)
            {
                Children.Add((new WordPageCS(displayObjects[previous])));
                if (next <= displayObjects.Count - 1)
                {
                    Children.RemoveAt(3);
                }
            }
        }
        
            //public void HandleCurrentPageChanged(object sender, EventArgs e)
            //{
            //    // if swiped left --->

            //    // swiped right <-----

            //}


        }
    }
