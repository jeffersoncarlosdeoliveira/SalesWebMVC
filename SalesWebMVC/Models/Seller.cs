﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome é obrigatório")]
        [StringLength(60, MinimumLength =3)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        [Display(Name="Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }
        public Seller(int id, string nome, string email,  DateTime dataAniversario, double salario, Departament departament)
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
