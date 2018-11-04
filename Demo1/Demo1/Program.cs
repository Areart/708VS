using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dep=new CuresContext())
            {
                foreach (var d in dep.Departments.OrderBy(x=>x.SortCode).ToList())
                {
                    Console.WriteLine("编号：{0},名称：{1},说明{2}",d.SortCode,d.Name,d.Dscn);
                }
                Console.ReadKey();
            }
        }
    }
}
