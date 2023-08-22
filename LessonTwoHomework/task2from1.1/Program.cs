var name = Console.ReadLine();
var lastName = Console.ReadLine();
var dateOfBirth = DateTime.Parse(Console.ReadLine()).Year;
var currentDate = DateTime.Now.Year;
var age = currentDate - dateOfBirth;
int yearsLeft = 40 - age;
if (yearsLeft > 0)
{
    Console.WriteLine($"{name} {lastName} до початку вашого  нового життя залишилося :{yearsLeft} років");
}
else if (yearsLeft == 0)
{
    Console.WriteLine($"{name} {lastName} вам вже  :{yearsLeft} років");
}
else
{
    Console.WriteLine($"{name} {lastName} вам вже за 40 ");
}