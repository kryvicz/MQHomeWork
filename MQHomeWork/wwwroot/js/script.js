// загрузить экран поиска по ip
function LoadIPSearch() {
    var main = document.querySelector("main");
    var template = document.querySelector("#ipTemplate");
    main.replaceChildren(template.content.cloneNode(true));
}

// загрузить экран поиска по городу
function LoadCitySearch() {
    var main = document.querySelector("main");
    var template = document.querySelector("#cityTemplate");
    main.replaceChildren(template.content.cloneNode(true));
}

let resultTable = "<table id='restbl'><tr><th>Country</th><th>Region</th><th>City</th><th>Postal</th><th>Organization</th><th>Lat</th><th>Lon</th><tr></table>";

// найти по ip
function FindByIP() {
    document.querySelector("#results").innerHTML = ""
    var ip = document.querySelector("#ipText").value;
    var err = document.querySelector("#error");
    if (!ip.match(/^[12]*\d*\d\.[12]*\d*\d\.[12]*\d*\d\.[12]*\d*\d$/)) {
        err.innerHTML = "Некорректный IP";
        err.className = "show";
    }
    else {
        err.innerHTML = "";
        err.className = "";
        const xhttp = new XMLHttpRequest();
        xhttp.onload = function () {
            if (this.responseText.length > 2) {
                document.querySelector("#results").innerHTML = resultTable;
                json2loc(this.responseText)
            }
        }
        xhttp.open("GET", "/ip/location?ip=" + ip);
        xhttp.send();
    }
}

// найти по городу
function FindByCity() {
    document.querySelector("#results").innerHTML = ""
    var city = document.querySelector("#cityText").value;
    var err = document.querySelector("#error");
    if (!city.startsWith("cit_")) { // проверить корректность ввода
        err.innerHTML = "Название города должно начинаться с cit_";
        err.className = "show";
    }
    else if (city.length < 5) { // проверить корректность ввода
        err.innerHTML = "Название города должно начинаться с cit_ и содержать значимую часть";
        err.className = "show";
    }
    else {
        err.innerHTML = "";
        err.className = "";
        const xhttp = new XMLHttpRequest();
        xhttp.onload = function () {
            if (this.responseText.length > 2) {
                document.querySelector("#results").innerHTML = resultTable;
                json2loc(this.responseText)
            }
        }
        xhttp.open("GET", "/city/locations?city=" + city);
        xhttp.send();
    }
}

function json2loc(json) {
    var jo = JSON.parse(json);
    if (Array.isArray(jo)) {//если массив
        for (var i = 0; i < jo.length; i++) {
            tblAddRow(jo[i]);
        }
    }
    else {
        tblAddRow(jo);
    }
}

function tblAddRow(jo) {
    var tbl = document.querySelector("#restbl tbody");
    var row = tbl.insertRow();
    var cellCountry = row.insertCell();
    cellCountry.appendChild(document.createTextNode(jo.country));
    var cellRegion = row.insertCell();
    cellRegion.appendChild(document.createTextNode(jo.region));
    var cellCity = row.insertCell();
    cellCity.appendChild(document.createTextNode(jo.city));
    var cellPostal = row.insertCell();
    cellPostal.appendChild(document.createTextNode(jo.postal));
    var cellOrganization = row.insertCell();
    cellOrganization.appendChild(document.createTextNode(jo.organization));
    var cellLatitude = row.insertCell();
    cellLatitude.appendChild(document.createTextNode(jo.latitude));
    var cellLongitude = row.insertCell();
    cellLongitude.appendChild(document.createTextNode(jo.longitude));
}