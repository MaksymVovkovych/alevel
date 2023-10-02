﻿using LINQ;

var users = new List<User>()
{
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@google.com",
                DateOfBirth = new DateTime(1985, 5, 15)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@gmail.com",
                DateOfBirth = new DateTime(1990, 3, 22)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Bob",
                LastName = "Johnson",
                Email = "bob.johnson@mail.com",
                DateOfBirth = new DateTime(1982, 8, 10)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Emily",
                LastName = "Brown",
                Email = "emily.brown@example.com",
                DateOfBirth = new DateTime(1988, 7, 5)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Michael",
                LastName = "Wilson",
                Email = "michael.wilson@google.com",
                DateOfBirth = new DateTime(1979, 12, 18)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Sophia",
                LastName = "Martinez",
                Email = "sophia.martinez@gmail.com",
                DateOfBirth = new DateTime(2020, 2, 9)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Taylor",
                Email = "david.taylor@example.com",
                DateOfBirth = new DateTime(1987, 9, 27)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Olivia",
                LastName = "Anderson",
                Email = "olivia.anderson@example.com",
                DateOfBirth = new DateTime(1992, 6, 14)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "William",
                LastName = "Moore",
                Email = "william.moore@gmail.com",
                DateOfBirth = new DateTime(2010, 4, 3)
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Ava",
                LastName = "Clark",
                Email = "ava.clark@ukrnet.com",
                DateOfBirth = new DateTime(2015, 10, 30)
            }
};

//1
var first = users.Where(user => 18 < DateTime.Now.Year - user.DateOfBirth.Year).
    Select(user => new { firstName = user.FirstName, lastName = user.LastName, dateOfBirth = user.DateOfBirth, age = DateTime.Now.Year - user.DateOfBirth.Year });
foreach (var user in first)
{
    Console.WriteLine($"User : {user.firstName} {user.lastName} date: {user.dateOfBirth} , now he is {user.age} old");
}

//2
var second = users
           .Select(user => user.Email!.Split('@').LastOrDefault())
           .GroupBy(domain => domain)
           .Select(group => new
           {
               domain = group.Key,
               count = group.Count()
           })
           .OrderByDescending(group => group.count)
           .FirstOrDefault();

Console.WriteLine($"{second.domain}, {second.count}");

//3
Dictionary<Guid, User> third = users.ToDictionary(user => user.Id);
foreach (KeyValuePair<Guid, User> user in third)
{
    Console.WriteLine(
            "Key {0}: {1}, {2} pounds",
            user.Key,
            user.Value.FirstName,
            user.Value.LastName,
            user.Value.Email,
            user.Value.DateOfBirth);
}

//4
var forth = users
           .GroupBy(user => user.LastName)
           .ToDictionary(
               group => group.Key,
               group => group
                   .OrderBy(user => user.DateOfBirth)
                   .Select(user => new
                   {
                       user.FirstName,
                       user.DateOfBirth
                   })
                   .ToList()
           );

foreach (var group in forth)
{
    Console.WriteLine($"Last Name: {group.Key}");
    foreach (var user in group.Value)
    {
        Console.WriteLine($"{user.FirstName}, Date of Birth: {user.DateOfBirth}");
    }
}
//FirstOrDefault2
var user2 = users.FirstOrDefault2(user => user.FirstName == "");
//SkipWhile2
var user3 = users.SkipWhile2(user => user.FirstName != "William");
Console.WriteLine();
foreach (var user in user3)
{
    Console.WriteLine(user.FirstName);
}
Console.WriteLine();

