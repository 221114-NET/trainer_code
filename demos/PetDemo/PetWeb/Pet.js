'use strict';

const url = "http://localhost:5053/api/Pet";

document.addEventListener('DOMContentLoaded', () =>
{
    const petContainer = document.getElementById('pet-div');
    const petForm = document.getElementById('petForm');

    fetch(url)
        .then(response =>
        {
            if(!response.ok)
            {
                throw new Error(`server error: ${response.status}`);
            }
            return response.json();
        })
        .then(obj =>
        {
            displayData(obj, petContainer);
        })
        .catch(err =>
        {
            console.log(err);
            petContainer.innerHTML = `<h2>${err}</h2>`;
        })

    petForm.addEventListener('submit', submitPet);


})

function submitPet(event)
{
    event.preventDefault();

    var xhr = new XMLHttpRequest();
    xhr.open("POST", url); 
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-type", "application/json");

    var formData = new FormData(event.target);
    var formValues = Object.fromEntries(formData.entries());

    var jsonPet = JSON.stringify(formValues);

    xhr.onload = function(event)
    { 
        console.log(xhr);
        if (xhr.status == 200)
        {
            var resp = event.target.responseText
            console.log(resp);
            
            try
            {
                displayData(JSON.parse(resp), document.getElementById('pet-div'));
            }
            catch(e)
            {
                console.log(e, e.message);
            }
        }
        else
        {
            console.log(jsonPet);
            console.log(xhr.responseText);
        }
    };

    xhr.send(jsonPet);    
}


function displayData(data, container)
{

    if(!(data instanceof Array))
    {
        data = [data];
    }

    let html = '<ul>' + data.map(x => '<li>' + x.name + '</li>').join(' ') + '</ul>';
    container.innerHTML = html;
}