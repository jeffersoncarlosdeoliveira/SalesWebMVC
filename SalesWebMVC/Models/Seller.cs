using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Departament Departament { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }
        public Seller(int id, string nome, string email, double salario, DateTime dataAniversario, Departament departament)
        {
            Id = id;
            Name = nome;
            Email = email;
            BaseSalary = salario;
            BirthDate = dataAniversario;
            Departament = departament;
        }
        public void AddSalles(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSalles(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime ini, DateTime fim)
        {
            return Sales.Where(sr => sr.Date >= ini && sr.Date <= fim).Sum(sr => sr.Amout);
        }
    }
}
