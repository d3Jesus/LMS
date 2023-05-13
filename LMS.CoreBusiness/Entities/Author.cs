﻿using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Entities
{
    public class Author : Person
    {
        private string _nationality;

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
    }
}
