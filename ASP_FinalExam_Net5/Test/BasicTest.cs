using ASP_FinalExam_Net5.Data;
using ASP_FinalExam_Net5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_FinalExam_Net5.Test
{
    public class BasicTest
    {
        protected readonly DbContextOptions<ApplicationDbContext> _opts;

        public BasicTest()
        {
            DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _opts = dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "Server=(localdb)\\mssqllocaldb;Database=aspnet-ASP_FinalExam_Net5-2AE641C6-29B7-4BE6-9494-EEED9ED043C7;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
        }
        protected List<Employee> MakeFakeJobs(int i)
        {
            var employees = new List<Employee>();
            for (int j = 0; j < i; j++)
            {
                employees.Add(new Employee
                {
                    Name = $"teststart{j}",
                    IsManager = true

                }) ;
            }
            return employees;
        }

    }
}
