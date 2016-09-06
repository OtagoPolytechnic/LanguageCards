using LanguageApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Classes
{
    public class DisplayObjectMaker
    {
        public DisplayObjectMaker()
        {

        }

        public LinkedList<DisplayObject> CreateDisplayObjects(List<WordPair> wordPairs, List<WordRecord> wordRecords)
        {
            LinkedList<DisplayObject> displayObjectList = new LinkedList<DisplayObject>();
            int index = 0;
            foreach (WordPair wp in wordPairs)
            {
                string original = wordRecords.Find(word => word.id == wp.original).word;
                string translation = wordRecords.Find(word => word.id == wp.translation).word;
                string description = wordRecords.Find(word => word.id == wp.original).description;
                displayObjectList.AddLast(new DisplayObject(index, original, translation, description));
                index++;
            }

            return displayObjectList;
        }

    }
}
