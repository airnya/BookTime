namespace TextSix.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string BookCover { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string IconSource { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        /*        public Category(string IconSource, string Text, string Description)
                {
                    this.IconSource = IconSource;
                    this.Text = Text;
                    this.Description = Description;
                } 
                */
    }
}

