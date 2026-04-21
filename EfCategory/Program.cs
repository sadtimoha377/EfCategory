using System;
using System.Linq;
using EfCategory;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 - All categories");
            Console.WriteLine("2 - Add");
            Console.WriteLine("3 - Delete");
            Console.WriteLine("4 - Find");
            Console.WriteLine("5 - Update");
            Console.WriteLine("0 - Exit");

            var choice = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                switch (choice)
                {
                    case "1":
                        foreach (var c in db.Categories.ToList())
                            Console.WriteLine($"{c.Id} {c.Name}");
                        break;

                    case "2":
                        Console.Write("Name: ");
                        db.Categories.Add(new Category { Name = Console.ReadLine() });
                        db.SaveChanges();
                        break;

                    case "3":
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());

                        var cat = db.Categories.Find(id);
                        if (cat != null)
                        {
                            db.Categories.Remove(cat);
                            db.SaveChanges();
                        }
                        break;

                    case "4":
                        Console.WriteLine("1 - Id, 2 - Name");
                        var type = Console.ReadLine();

                        if (type == "1")
                        {
                            int findId = int.Parse(Console.ReadLine());
                            var c = db.Categories.Find(findId);
                            if (c != null)
                                Console.WriteLine(c.Name);
                        }
                        else
                        {
                            var n = Console.ReadLine();
                            var c = db.Categories.FirstOrDefault(x => x.Name.Contains(n));
                            if (c != null)
                                Console.WriteLine(c.Id);
                        }
                        break;

                    case "5":
                        Console.Write("Id: ");
                        int updId = int.Parse(Console.ReadLine());

                        var upd = db.Categories.Find(updId);
                        if (upd != null)
                        {
                            Console.Write("New name: ");
                            upd.Name = Console.ReadLine();
                            db.SaveChanges();
                        }
                        break;

                    case "0":
                        return;
                }
            }
        }
    }
}

