const person = {

    firstName : "John",
    lastName : "Doe",
    age : 53,
    Hobby : function myHobby() {
        return this.age * 2;
    }

}
const person1 = {
     age :5
}
document.getElementById("demo").innerHTML = person.Hobby.call(person1);