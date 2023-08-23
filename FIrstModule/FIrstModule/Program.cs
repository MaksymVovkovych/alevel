
Console.WriteLine("Hello, input the command for your tasks.");
List<string> items = new List<string>() { "str", "add-item", "make a homework" };
while (true)
{
    Console.WriteLine(Environment.NewLine);
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

                if (!string.IsNullOrEmpty(task))
                {
                    if (!items.Any())
                    {
                        items.Add(task); break;
                    }
                    bool IsTask = true;
                    foreach (string item in items)
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
                if (!string.IsNullOrEmpty(delete))
                {
                    if (delete == "*")
                    {
                        items.Clear(); break;
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
                    else
                    {
                        items.Remove(delete);
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("This task isn`t already");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Error.. You input anything! Try again"); break;
                }
            }
        case "mark-as":
            {
                Console.WriteLine("Input a staus:");
                string? status = Console.ReadLine();

                if (status == "1" || status == "0")
                {
                    Console.WriteLine("Input a task:");
                    var task = Console.ReadLine();
                    if (!string.IsNullOrEmpty(task))
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (task.ToLower().Contains(items[i].ToLower()))
                            {
                                items[i] = string.Join(" ", status, items[i]);
                                if (status == "0")
                                {
                                    int indexOfComma = items[i].IndexOf(',');
                                    if (indexOfComma != -1)
                                    {
                                        items[i] = items[i].Substring(0, indexOfComma).Trim(); break;
                                    }
                                }
                                if (status == "1")
                                {
                                    var date = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(date))
                                    {
                                        if (DateTime.TryParse(date, out DateTime executionTime))
                                        {
                                            items[i] = string.Join(", ", items[i], executionTime.ToString("yyyy-MM-dd")); break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid time format. Using current time."); break;
                                        }
                                    }
                                    else
                                    {
                                        items[i] = string.Join(", ", items[i], DateTime.Now.ToString("yyyy-MM-dd")); break;
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input error task.Try again.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Input error status.Try again.");
                    break;
                }
                break;
            }
        case "show":
            {
                Console.WriteLine("Input a staus:");
                string? status = Console.ReadLine();
                if (status == "1" || status == "0" || status == "")
                {
                    if (status == "1")
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            int indexOfStatus = items[i].IndexOf('1');
                            if (indexOfStatus != -1)
                                if (indexOfStatus != -1)
                                {
                                    Console.WriteLine(items[i]);
                                }
                        }
                        break;
                    }
                    else if (status == "0")
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            int indexOfStatus = items[i].IndexOf('0');
                            if (indexOfStatus != -1)
                            {
                                Console.WriteLine(items[i]);
                            }
                        }
                        break;
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Input error status.Try again.");
                    break;
                }
            }
        case "exit":
            {
                return;
            }
        default: { return; }
    }
}