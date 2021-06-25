using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PersonContext();
            foreach (People item in db.People)
                Console.WriteLine(p.Firstname +" "+ p.Secondname);

            var p = new People();
            p.id = 10;
            p.Firstname = "11";
            p.Secondname = "ssd";
            db.People.Add(p);
            db.SaveChanges();
            //var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Notebook;Integrated Security=True;";
            //using (var cn = new SqlConnection(cs))
            //{
            //    cn.Open();
            //    var cmd = new SqlCommand("select * from People", cn);
            //    //Console.Write("id=");
            //    //var id = Console.ReadLine();
            //    //var cmd = new SqlCommand($"select * from People where id=@id", cn);
            //    //cmd.Parameters.AddWithValue("@id", id);
            //    //               var cmd = new SqlCommand(@"insert into People (Id, Firstname, Secondname)
            //    //values (4,'Aaa','Bbbb')", cn);
            //    //               cmd.ExecuteNonQuery();
            //    using (var dr = cmd.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            Console.WriteLine($"{ dr["Firstname"]} {dr["Secondname"]}");
            //        }
            //    }
            //}



        }
    }
}
