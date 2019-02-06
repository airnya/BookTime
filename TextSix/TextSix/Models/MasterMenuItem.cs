using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TextSix.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public string BookContent{ get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string Title, string IconSource, String BookContent, Color color, Type target)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BookContent = BookContent;
            this.TargetType = target;
        }

    }
}
