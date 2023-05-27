﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
    public class Book
    {
        private int _id;
        private string _title;
        private string _description;
        private int _edition;
        private string _isbn;
        private int _categoryId;
        private string _imageUrl;
        private DateTime _dateCreated;
        private decimal _price;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title 
        { 
            get { return _title; } 
            set { _title = value; } 
        }

        public string Description 
        { 
            get { return _description; } 
            set { _description = value; } 
        }

        public int Edition 
        {
            get { return _edition; } 
            set { _edition = value; } 
        }

        public string ISBN 
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        
        public int CategoryId 
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            private set { _dateCreated = DateTime.Now; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public virtual List<Category> Categories { get; set; }
    }
}