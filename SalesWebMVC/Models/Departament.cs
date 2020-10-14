using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        public Departament()
        {

        }
        
        public Departament(int id, string nome)
        {
            Id = id;
            Name = nome;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime ini, DateTime fim)
        {
            return Sellers.Sum(seller => seller.TotalSales(ini, fim));
        }
    }
}
