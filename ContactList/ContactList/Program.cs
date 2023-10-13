
using ContactList;
const string filePath = @"D:\async1.txt";

var contactBook = new ContactBook(100);

var app = new App(new ContactBookServices(contactBook),new FileOperations(filePath, contactBook),new Watcher(filePath));

app.AppContactBook();