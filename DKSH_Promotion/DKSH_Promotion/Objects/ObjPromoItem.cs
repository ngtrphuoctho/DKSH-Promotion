using System;
using SQLite;

namespace DKSH_Promotion.Objects
{
    [Table("PromotionItems")]
    public class ObjPromoItem
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public int Status { get; set; }
        public ObjPromoItem()
        {

        }
    }
}   