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
            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
            using(var context=new CuresContext())
            {
                //.where .orderby  .tolist()
                foreach (var d in context.Departments.OrderBy(x=>x.SortCode).ToList())
                {
                    Console.WriteLine("编号：{0},名称：{1},说明{2}",d.SortCode,d.Name,d.Dscn);
                }
                Console.WriteLine("添加一条新纪录后");

                var newDep = new Departments
                {
                    ID = Guid.NewGuid(),
                    Name = "财经与物流学院",
                    Dscn = "财经与物流学院",
                    SortCode = "009"
                };

                // 添加
                //把新对象添加到上下文中
                context.Departments.Add(newDep);
                //保存到数据库中
                  context.SaveChanges();


             
                //显示新纪录
                foreach (var d in context.Departments.OrderBy(x => x.SortCode).ToList())
                {
                    Console.WriteLine("编号：{0},名称：{1},说明：{2}", d.SortCode, d.Name, d.Dscn);
                }
                Console.ReadKey();
            }
        }
    }
}
