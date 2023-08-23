using System.Runtime.CompilerServices;
using System.Threading.Tasks;

void AddItem(string[] items)
{
   
}
void RemoveItem(string[] items)
{

}
void MarkAs(string[] items)
{

}
void Show(string[] items)
{

}


Console.WriteLine("Hello, input the command for your tasks.");
List<string> items = new List<string>() {"str","add-item","make a homework"};
while (true)
{
    Console.WriteLine(">add-item");
    Console.WriteLine(">remove-item");
    Console.WriteLine(">mark-as");
    Console.WriteLine(">show");
    Console.WriteLine(">exit");
    Console.WriteLine("Input a command:");
    var command = Console.ReadLine();
    Console.WriteLine(Environment.NewLine);
    switch (command)
    {
        case "add-item":
            {
                Console.WriteLine("Input a task:");
                var task = Console.ReadLine();

                if (task != null)
                {
                    if (!items.Any())
                    {
                        items.Add(task);break;
                    }
                    bool IsTask = true;
                    foreach(string item in items)
                    {
                        if (task.ToLower().Contains(item.ToLower()))
                        {
                            IsTask = false;
                            break;
                        }
                    }
                    if (!IsTask)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("This task is already"); break;
                    }
                    else { items.Add(task); break; }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Error.. You input anything! Try again"); break;
                }
            }
        case "remove-item":
            {
                if (!items.Any())
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("There aren`t tasks"); break;
                }
                foreach (string item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("What you want to delete?");
                var delete = Console.ReadLine();
                if (delete != null)
                {
                    if(delete == "*")
                    {
                        items.Clear();break;
                    }
                    bool IsTask = true;
                    foreach (string item in items)
                    {
                        if (delete.ToLower().Contains(item.ToLower()))
                        {
                            IsTask = false;
                            break;
                        }
                    }
                    if (!IsTask)
                    {
                        items.Remove(delete);
                        break;
                    }
                    else { items.Remove(delete);
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("This task isn`t already");
                        break; }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Error.. You input anything! Try again"); break;
                }
            }
        case "mark-as":
            {
                 break;
            }
        case "show":
            {
                 break;
            }
        case "exit":
            {
                 return;
            }
        default: {  return; }
    }
}