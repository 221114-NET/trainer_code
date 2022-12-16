'use strict';

document.addEventListener('DOMContentLoaded', () =>
{
    const petContainer = document.getElementById('pet-div');

    let url = "https://localhost:7188/api/Pet";

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

})


function displayData(data, container)
{
    if(!(data instanceof Array))
    {
        data = [data];
    }
    let html = '<ul>' + data.map(x => '<li>' + x.name + '</li>').join(' ') + '</ul>';
    container.innerHTML = html;
}