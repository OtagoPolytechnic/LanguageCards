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
        LinkedList<DisplayObject> displayObjects;

        // Remove index from display objects . Not needed
        private int previousPage;
        private int currentPage;

        private LinkedListNode<DisplayObject> previousNode;
        private LinkedListNode<DisplayObject> currentNode;
        private LinkedListNode<DisplayObject> nextNode;
        //List<DisplayObject> displayObjects;
        // Create list/stack of 3 display objects?

        public CardCarouselScreenCS(LinkedList<DisplayObject> displayObjects)
        {
            //this.displayObjects = new LinkedList<DisplayObject>();
            this.displayObjects = displayObjects;

            if (displayObjects.Count == 0)
            {
                DisplayObject d = new DisplayObject(0, "No words in Database", "", "");
                this.Children.Add(new WordPageCS(d));
            }
            else
            {
                foreach (DisplayObject d in displayObjects)
                {
                    this.Children.Add(new WordPageCS(d));
                }

                //previousNode = null;
                //currentNode = displayObjects.First;
                //nextNode = currentNode.Next;


                ////LinkedListNode<DisplayObject> firstNode = displayObjects.First;
                ////LinkedListNode<DisplayObject> nextNode = firstNode.Next;

                //this.Children.Add(new WordPageCS(currentNode.Value));
                //this.Children.Add(new WordPageCS(nextNode.Value));

                //WordPageCS temp = new WordPageCS(currentNode.Value);
                //temp.Id = 2;
            }

            

            BackgroundColor = Color.Red;
            
        }

        protected override void OnPagesChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnPagesChanged(e);

            //e.Action
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            // if currentpage displayobect == next node then its swipe left
            // update nodes afterwards

            //CurrentPage.

            


        }

    }
}
