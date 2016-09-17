using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Classes
{
    public class DisplayObject
    {
<<<<<<< HEAD
        public int index { get; }
        public string original { get; }
=======
        public int index { get; }  // Not needed
        public string orginal { get; }
>>>>>>> refs/remotes/origin/UI
        public string translation { get; }
        public string description { get; }
        //public string soundfile { get; }
        // Language ??
        // sound properties

        public DisplayObject(int index, string orginal, string translation, string description)
        {
            this.index = index;
            this.original = orginal;
            this.translation = translation;
            this.description = description;
        }

    }
}
