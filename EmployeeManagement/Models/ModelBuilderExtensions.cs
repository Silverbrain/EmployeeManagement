using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new List<Employee>() {
                new Employee() { Id = 1, Name = "Sina Ataei", Department = Departments.RD, Email = "sina@sinaataei.ml" },
                new Employee() { Id = 2, Name = "Arash Rastegar", Department = Departments.IT, Email = "arash@sinaataei.ml" },
                new Employee() { Id = 3, Name = "Ali Rastegar", Department = Departments.MG, Email = "ali@sinaataei.ml" }
            });
        }
	}
}

