using Xamarin.Forms;
using SQLite;
using DKSH_Promotion.Database;
using DKSH_Promotion.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DKSH_Promotion
{

    class DetailPage : ContentPage
    {

        private ListView _recordList;
        private DPDatabase database;
        private string query;


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext == null)
                return;

            var item = BindingContext as Categories;
            query = item.ToString();
            var records = database.getRecordsByCategory(query);
            _recordList.ItemsSource = records;


        }

        public DetailPage(DPDatabase databaseInput)
        {



            this.database = databaseInput;
            this.SetBinding(ContentPage.TitleProperty, "Name");
            var records = database.getRecordsByCategory(query);
            BackgroundColor = Color.White;

            _recordList = new ListView();
            _recordList.ItemsSource = records;
            _recordList.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.DetailColor = Color.Black;
                textCell.TextColor = Color.Navy;
                return textCell;
            });
            _recordList.ItemTemplate.SetBinding(TextCell.TextProperty, "Subject");
            _recordList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Content");
            _recordList.IsPullToRefreshEnabled = true;
            _recordList.IsRefreshing = IsBusy;
            _recordList.RefreshCommand = new Command(() =>
            {
                //database.refresh();
                records = database.getRecordsByCategory(query);
                _recordList.ItemsSource = records;

                App app = Application.Current as App;
                CategoryPage md = (CategoryPage)app.MainPage;
                md.updateMaster();


                _recordList.IsRefreshing = false;
            });



            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                   
                    
                    //contentView,
                    _recordList
                }
            };


        }

    }
}