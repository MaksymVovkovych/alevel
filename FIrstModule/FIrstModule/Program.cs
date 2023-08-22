void AddItem(string[,] items)
{
    Console.WriteLine("Input your item");
    string item = Console.ReadLine().ToLower();
    if (item != null)
    {

    }
    else Console.WriteLine("String is null.");
}
void RemoveItem(string[,] items)
{

}
void MarkAs(string[,] items)
{

}
void Show(string[,] items)
{

}


Console.WriteLine("Hello, input the command for your tasks.");

while (true)
{
    Console.WriteLine(">add-item");
    Console.WriteLine(">remove-item");
    Console.WriteLine(">mark-as");
    Console.WriteLine(">show");
    Console.WriteLine(">exit");

    Console.WriteLine("Input a command:");
    var command = Console.ReadLine();

    switch (command)
    {
        case "add-item":
            {
                AddItem(items);
                break;
            }
        case "remove-item":
            {
                RemoveItem(items); break;
            }
        case "mark-as":
            {
                MarkAs(item); break;
            }
        case "show":
            {
                Show(items); break;
            }
        case "exit":
            {
                 return;
            }
        default: {  return; }
    }
}