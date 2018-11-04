using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CuresContext())
            {
                //.where .orderby  .tolist()
                foreach (var d in context.Departments.OrderBy(x => x.SortCode).ToList())
                {
                    Console.WriteLine("编号：{0},名称：{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                }
                Console.WriteLine("修改");
                //修改
                var editdep = context.Departments.SingleOrDefault(x => x.Name == "财经与物流学院");
                if (editdep != null)
                {
                    editdep.Name = "财经与物流学院";
                    editdep.SortCode = "009";
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("未找到该纪录,无法修改");
                //显示新纪录
                foreach (var d in context.Departments.OrderBy(x => x.SortCode).ToList())
                {
                    Console.WriteLine("编号：{0},名称：{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                }
                Console.ReadKey();
            }
        }
    }
}
