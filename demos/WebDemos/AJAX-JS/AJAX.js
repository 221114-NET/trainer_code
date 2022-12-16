"use strict";

//AJAX Asynchronous JS and XML
//This is an "older" way to make our page reactive


//Unless we wait for the DOM to load (itself its own event we can
//listen for), we need to load the script at the end of the HTML doc.
//To avoid this, we can use the DOMContentLoaded eventListener.
document.addEventListener('DOMContentLoaded', () =>{

        const textField = document.getElementById('data-input');
        const button = document.getElementById('load-users');
        const output = document.getElementById('list-container');

        //button.addEventListener("click", () => {
        //    let html =  "<p>Here's some sample text</p>";
        //    output.innerHTML = html;
        //    return;
        //});

        
        button.addEventListener("click", () =>{
            
            //Fetch, replaces AJAX process. Much cleaner.
            //We still use our url string.
            let url = "https://jsonplaceholder.typicode.com/users/";
            
            //We call fetch and pass in the URL. Fetch is implied async by default.
            fetch(url)//Once the response comes back, we decide what to do.
                .then(response =>
                    {   //If the response is bad for whatever reason, we log it
                        if(!response.ok)
                        {
                            throw new Error(`server response: ${response.status}`);
                        }
                        return response.json();
                    })//We can just keep chaining .then items.
                .then(obj => {
                    let html = "<ul>";

                    //We need to iterate through this array
                    for(let user in obj){
                        //For a template literal, you need to use a back-tick `my string with {stuff}`
                        html += `<li> ${obj[user].name} </li>`; 
                    }
                    html += '</ul>';

                    output.innerHTML = html;
                })
                .catch(err =>{
                    console.log(err);
                    output.innerHTML = `<h3>${err}</h3>`;
                });

            
        
        /* const req = new XMLHttpRequest();
        //XHR - XMLHttpRequest
        //Ready-state
        //XHR's have readyStates 0-4.
        //State 0: We are still working on the request.
        //State 1: We have called open()
        //State 2: We've sent the request. We've got headers and status.
        //State 3: Loading. We're actively downloading the result data from the request.
        //State 4: Done. The request has completed
        console.log(req.readyState);

        req.open("GET", "https://jsonplaceholder.typicode.com/users/", true);

        //Telling the server what data we will accept
        req.setRequestHeader("Accept", "application/json");

        console.log(req.readyState);

        req.onload = function(){
            if (req.status == 200){
                //Right now, this gets an array of User objects
                let obj = JSON.parse(req.responseText);
                let html = "<ul>";

                //We need to iterate through this array
                for(let user in obj){
                    //For a template literal, you need to use a back-tick `my string with {stuff}`
                    html += `<li> ${obj[user].name} </li>`; 
                }
                
                html += '</ul>';
                
                
                output.innerHTML = html;
            }
            else{
                output.innerHTML = "*sad trombone*"
            }
        }

        try{
            req.send()
        }catch(e){
            console.log(e)
        } */
    })
})





