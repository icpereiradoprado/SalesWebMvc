using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMvc.Models
{
    [Table("Department")]
    public class Department
    {
        [Column("Id")]
        [Display(Name = "Code")]
        public int Id { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Column("Sellers")]
        [Display(Name ="Sellers")]
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }
        public Department(string name)
        {
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(sellers => sellers.TotalSales(initial, final));
        }
    }
}
