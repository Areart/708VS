using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3
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
                //删除
                Console.WriteLine("删除纪录");
                var deldep = context.Departments.Find(Guid.Parse("c35ac4c5-0a86-4df1-a4f7-565bf0e642bd"));
                if (deldep != null)
                {
                    context.Departments.Remove(deldep);
                    context.SaveChanges();
                    Console.WriteLine("删除成功");
                }
                else
                    Console.WriteLine("未找到该纪录，无法删除");
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
