using System;
using Xamarin.Forms;

namespace DKSH_Promotion
{
    // Used in TabbedPageDemoPage & CarouselPageDemoPage.
    class Message
    {
        public Message(string subject, String content)
        {
            this.Subject = subject;
            this.Content = content;
        }

        public string Subject { private set; get; }

        public string Content  { private set; get; }

        public override string ToString()
        {
            return Content;
        }
    }

}
