
using ContactList;

var app = new App(new ContactBookServices(new ContactBook(10)));

app.AppContactBook();