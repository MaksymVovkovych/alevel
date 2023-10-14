
using ContactList;
const string filePath = @"D:\ContactBook.txt";

var contactBook = new ContactBook(100);

var app = new App(
    new ContactBookServices(contactBook),
    new FileOperations(contactBook),
    new Watcher(filePath, new FileSystemWatcher(Path.GetDirectoryName(filePath))),
    filePath
    );

app.AppContactBook();