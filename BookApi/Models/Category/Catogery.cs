using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryImage { get; set; }
        public string Status { get; set; }
        public int Position { get; set; }
        public string CreatedAt { get; set; }

        public Category() { }
        public Category(int catogeryId,string categoryName,string description, string categoryImage,string status,int position,string createdat)
        {
            CategoryId = catogeryId;
            CategoryName = categoryName;
            Description = description;
            CategoryImage = categoryImage;
            Status = status;
            Position = position;
            CreatedAt = createdat;
        }

    }
}