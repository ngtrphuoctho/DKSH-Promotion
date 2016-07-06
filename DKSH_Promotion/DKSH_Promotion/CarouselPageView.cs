using DKSH_Promotion.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DKSH_Promotion
{
    class CarouselPageView : CarouselPage
    {
        public CarouselPageView()
        {
            this.Title = "CarouselPage";

            this.ItemsSource = new Message[]
            {
                new Message("Text1", "1111111111111"),
                new Message("Text2", "22222222222"),
                new Message("Text3", "333333333333333"),
                new Message("Text4", "44444444444444444444"),
                new Message("Text5", "55555555555555"),
                new Message("Text6", "667666666666666")
            };

            this.ItemTemplate = new DataTemplate(() =>
            {
                DPDatabase database = new DPDatabase();
                return new DetailPage(database);
            });
        }
    }
}
