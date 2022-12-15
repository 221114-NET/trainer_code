"use strict";

//JS Objects

//an object is just a collection of related functionality packaged together
//Objects are used to store properties, which are key/value pairs
//and more complex entities

//JS objects are stored by reference, not by value
//the variable representing the object is not the object itself,
//it holds a memory location/address of the object on the heap

let user = new Object();//object constructor syntax

let user2 = {}; //object literal syntax

let user3 = {
    name: "Jonathan",
    age: 26
}

function makeUser(name, age)
{
    return{
        name,
        age,
        sizes:{
            height:160,
            weight:50,
            traits:{
                hair: "black"
            }
        }
    };
}

let myUser = makeUser("jon", 20);
console.log(myUser)
console.log(myUser.age)
console.log(myUser.sizes.height)
console.log(myUser.sizes.traits.hair)


//Map is a key/value data structure, like an object
//Any type of data can be used as a key, and a value
//insertion order is in the order key/value pairs are added

let myMap = new Map();

myMap.set(1, "one")
myMap.set(2, "three")
myMap.set("four", 345)
//etc

console.log(myMap.get("four"))

//Set is a data structure that stores unique values

let mySet = new Set();

mySet.add(5)
mySet.add("Jordan")
mySet.add(user3)
mySet.add(user3)

for(let item of mySet){
    console.log(item)
}

//classes - state and behavior

class Rectangle
{
    constructor(height, width)
    {
        this.height = height;
        this.width = width;
    }

    get area()
    {
        return this.calcArea() + 4;
    }

    calcArea(){
        return this.height*this.width;
    }

    //static methods
    //we call these without instantiating the an object of that class
    static multiply(a, b)
    {
        return a * b;
    }
}

let myRectangle = new Rectangle(10, 20);
console.log(myRectangle.height);
console.log(myRectangle.area)
console.log(myRectangle.calcArea())

//JSON and JSON methods
//Javascript Object Notation

// JSON.stringify(object) - converts an object to a JSON string

console.log(JSON.stringify(myRectangle))
console.log(JSON.stringify(myUser))

let json = '{"name":"Meg", "age":22}'

let obj = JSON.parse(json)
console.log(obj)


//Storage
//We can store things to either localStorage or sessionStorage.
//localStorage persists between browser closure, sessionStorage does not.
//both localStorage and SessionStorage only accept String key/value pairs.

localStorage.setItem("user", myUser);
localStorage.setItem("correctUser", JSON.stringify(myUser))

console.log(localStorage.getItem("user"))
console.log(localStorage.getItem("correctUser"))

let storedUser = JSON.parse(localStorage.getItem("correctUser"));
console.log(storedUser)
