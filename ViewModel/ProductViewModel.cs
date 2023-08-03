using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Project.ViewModel
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; }
        public int Prod_Id { get; set; }
        [Required]
        public string Prod_Name { get; set; }
        [Required]
        public string Prod_Type { get; set; }
        [Required]
        public double Prod_Price { get; set; }
        [Required]
        public string Prod_Desc { get; set; }
    }
}