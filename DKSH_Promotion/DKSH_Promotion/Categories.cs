using System;
using Xamarin.Forms;

namespace DKSH_Promotion
{
    // Used in TabbedPageDemoPage & CarouselPageDemoPage.
    class Categories
    {
        public Categories(string name)
        {
            this.Name = name;
            this.Color = Color.White;
        }

        public string Name { private set; get; }
        public Color Color
        {
            private set;get;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
