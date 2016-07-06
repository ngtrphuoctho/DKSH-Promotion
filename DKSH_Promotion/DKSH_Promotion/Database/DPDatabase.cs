using DKSH_Promotion.Objects;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Json;

using System.Net;
using System.IO;

namespace DKSH_Promotion.Database
{
    public class DPDatabase
    {
        private SQLiteConnection _connection;
        public DPDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            //TODO: Delete later
            //_connection.DeleteAll<ObjPromoItem>();
            _connection.CreateTable<ObjPromoItem>(); 
        }

        public IEnumerable<ObjPromoItem> getRecords()
        {
            return (from t in _connection.Table<ObjPromoItem>()
                    select t).ToList().Reverse<ObjPromoItem>();
        }
        public ObjPromoItem getRecord(int id)
        {
            return _connection.Table<ObjPromoItem>().FirstOrDefault(t => t.Id == id);
        }

        public void addRecord(JsonValue json)
        {
            foreach (JsonValue jsonItem in json)
            {
                ObjPromoItem item = new ObjPromoItem();
                item.Subject = jsonItem["Subject"];
                item.Content = jsonItem["Content"];
                item.Category = jsonItem["Category"];
                _connection.Insert(item);
            }
        }
        public IEnumerable<ObjPromoItem> getRecordsByCategory(string category)
        {
            return _connection.Table<ObjPromoItem>().Where(a => a.Category == category).ToList();



        }

        public IEnumerable<string> getCategories()
        {

            var distinctCategories = getRecords().Select(p => p.Category).Distinct().ToList();
            return distinctCategories;
        }

    }
}
