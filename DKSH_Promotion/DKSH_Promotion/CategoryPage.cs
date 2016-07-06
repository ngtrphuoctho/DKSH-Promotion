using DKSH_Promotion.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using DKSH_Promotion.PhoneNumberService;

namespace DKSH_Promotion
{
    class CategoryPage : MasterDetailPage
    {
        private static DPDatabase database;
        private List<string> cat;
        private ListView listView;
        public CategoryPage()

        {
            this.Title = "DKSH_Promotion";
            String phoneNumber = DependencyService.Get<ITGetPhoneNumber>().getPhoneNumber();

            Label header = new Label
            {
                Text = "Categories",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
            };
            Label header1 = new Label
            {
                Text = phoneNumber,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
            };
            //Creating database and pull data
            database = new DPDatabase();
            database.getRecords();
            cat = database.getCategories();



            // Create ListView for the master page.

            listView = new ListView()
            {
                ItemsSource = cat
            };

      
            //listView.SetBinding(TextCell.TextProperty, "Name");
            //listView.SetBinding(TextCell.TextColorProperty, "Color");
            /*listView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.DetailColor = Color.Black;
                textCell.TextColor = Color.Navy;
                this.SetBinding(TextCell.TextProperty, "");
                return textCell;
            });
            */
            // Create the master page with the ListView.
            this.Master = new ContentPage
            {
                Title = "Category List",       // Title required!
                Content = new StackLayout
                {
                    Children = {
                        header,
                        header1,
                        listView
                    }
                },
                BackgroundColor = Color.FromRgb(171, 16, 50),
                
                
            };

            DetailPage detailPage = new DetailPage(database);
            this.Detail = new NavigationPage(detailPage);
            // For Android & Windows Phone, provide a way to get back to the master page.
            if (Device.OS != TargetPlatform.iOS)
            {
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += (sender, args) => {
                    this.IsPresented = true;
                };

                //carouselPage.Content.BackgroundColor = Color.Transparent;
                //carouselPage.GestureRecognizers.Add(tap);
            }

            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) => {
                // Set the BindingContext of the detail page.
                if(args.SelectedItem != null)
                    this.Detail.BindingContext = new Categories(args.SelectedItem.ToString());

                // Show the detail page.
                this.IsPresented = false;
            };

            //Initialize the ListView selection.
            listView.SelectedItem = cat.FirstOrDefault();
        }
        public void updateMaster()
        {
            cat = database.getCategories();
            /*foreach(string item in cat)
            {
                categories.Add(new Categories(item));
            }
            categories.Add(new Categories("lmao"));
            */
           
            listView.ItemsSource = cat;
            //Initialize the ListView selection.

        }

    }
}
