using DKSH_Promotion.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DKSH_Promotion
{
    class CategoryPage : MasterDetailPage
    {
        private static DPDatabase database;
        private static List<Categories> categories = new List<Categories>();
        private ListView listView;
        public CategoryPage()

        {
            this.Title = "DKSH_Promotion";

            Label header = new Label
            {
                Text = "Categories",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            //Creating database
            database = new DPDatabase();
            database.getRecords();
            // Assemble an array of NamedColor objects.
            /*Categories[] namedColors = {
                new Categories ("Target"),
                new Categories ("Daily"),
                new Categories ("Monthly"),
                new Categories ("Promotion"),
                new Categories ("Last Week"),
            };
            */
            // Create ListView for the master page.
            listView = new ListView
            {
                ItemsSource = categories,
            };
            // Create the master page with the ListView.
            this.Master = new ContentPage
            {
                Title = "Category List",       // Title required!
                Content = new StackLayout
                {
                    Children = {
                        header,
                        listView
                    }
                },
                //BackgroundColor = Color.Maroon

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
                this.Detail.BindingContext = new Categories(args.SelectedItem.ToString());

                // Show the detail page.
                this.IsPresented = false;
            };

            //Initialize the ListView selection.
            //listView.SelectedItem = categories;
        }
        public void updateMaster()
        {
            var cat = database.getCategories();

            listView.ItemsSource = cat;
            //Initialize the ListView selection.

        }

    }
}