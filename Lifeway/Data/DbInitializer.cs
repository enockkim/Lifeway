//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Lifeway.Models;

//namespace Lifeway.Data
//{
//    public class DbInitializer
//    {
//        public static void Initialize(ApplicationDbContext context)
//        {
//            context.Database.EnsureCreated();

//            // Look for any students.
//            if (context.Students.Any())
//            {
//                return;   // DB has been seeded
//            }

//            var Students = new Students[]
//            {
//                new Students{Adm_no=1125,Name="Mike",Grade="3",EnrollmentDate=DateTime.Parse("2005-09-01")},
//                new Students{Adm_no=3342,Name="Memo",Grade="2",EnrollmentDate=DateTime.Parse("2005-09-01")},
//                new Students{Adm_no=1123,Name="Kim",Grade="1",EnrollmentDate=DateTime.Parse("2005-09-01")}
//            };
//            foreach (Students s in Students)
//            {
//                context.Students.Add(s);
//            }
//            context.SaveChanges();
//        }
//    }
//}
