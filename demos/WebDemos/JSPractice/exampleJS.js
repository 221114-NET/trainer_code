"use strict"; //Included to prevent any legacy code weirdness

//In JS "//" notation for comments
//In C#, if you want an int, I have to specifically request an int
//In JS, we use dynamic typing to determine the data tyoe of variables

//If we aren't careful, we can accidentally swap types
//with already declared variables.
var number = 1;
number = 'some string';

//Console output
//The console output goes to your browser, so without something 
//like node.js installed, you need to link it to an HTML file using the 
//the script tag
console.log(number);
console.log('Hello world!');

//let and var
var name = "Rich"; //var is function scoped
let pet = "Claude"; //let is block scoped

//hoisting 
//"hoisting" is a JS feature, that allows variables to be declared 
//after they are used
value = 5; //I assign a value to my variable, before I ever actually declared it
console.log(value); //I then passed that undeclared variable into a function
var value; //Only after all that, did I actually decalre it with var.

//operators
//we still have the normal arithmetic operators we are used to
// + - * / % ++ --, etc
//we still use "=" assignment
//we also have our standard logical operators
//== >= <= > < !=, etc
//we have some new behavior though
//== This compares for value
//=== 

console.log(5=='5');
console.log(5==='5');

//truthy and falsy
//false
//0 
//""
//null
//NaN
//-0
//0n

//Type Conversions
//3 common ones
//to number
//to string
//to bolean

console.log("asdf" + 123);
console.log("1" + 123);

let x;
// x = infinity;
x = 3*6;
x = 'asdf' - 5;

x = 3==3;

x = 'asdf\n"hello"'
x = "asdf\n'hello'"
console.log(typeof(x));

x = true && true;
x = true || false;
x = NaN === NaN;
x = isNaN(NaN);

console.log(x);
console.log(typeof(x));

var y = "hello";
var z = typeof(x) == typeof(y);
console.log(z);

//Control Flow
//if/else
//loops (for, while, do/while)
//conditionals

// while(true){
//     console.log("Hey guys!")
//     break;
//}

for(let i =0; i<10;i++){
    console.log(i)
}

if(5==='5'){
    console.log('Yeah it works')
}else{
    console.log('Nah something is up');
}

//Functions
//a JS function is handled like an object
//it has a name, parameters, and a body

//function + name. Parameters go inside the parenthesis
function showMessage(from, text = "no message"){
    //This is the body of my function
    if(5==5){
        var y = 'awesome';
        console.log(y);
    }
    console.log(from + ": " + y)
}

//console.log(functionScoped);
//console.log(functionScoped);
//console.log(globalScoped);
showMessage("jason");
showMessage("Jason", "Rich show us your hedgehog!")


//Callback functions
//a function that is passed to another function

try{

    function addNums(num1, num2){
        return num1 + num2;
    }

    function multiplyNums(b){
        num1 * num2;
    }

    function doMath (num1, num2, func){
        return func(num1, num2);
    }

    //assign those functions to variables
    
    console.log(doMath(5,6,addNums))

}catch(oops){
    console.log("Oh boy.")
}

//Arrow functions
//Just a way to write functions in a more concise way.
//Don't change how you call them or how they work.
let normalFunc = function(arg1, arg2){
    return arg1 + arg2;
}

let arrowFunc = (arg1,arg2) => arg1 + arg2;

console.log(normalFunc(2,3))
console.log(arrowFunc(2,3))
console.log(arrowFunc(2,3) === normalFunc(2,3))