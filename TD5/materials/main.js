var stationsList = [];

var apiKeyDOM = document.getElementById("apiKey");
var chosenContractDOM = document.getElementById("chosenContract");
var apiKeyDOM = document.getElementById("apiKey");
var contractsListDOM = document.getElementById("contractsList");
var chooseContractDivDOM = document.getElementById("chooseContractDiv");
var chooseStationDivDOM = document.getElementById("chooseStationDiv");
var latitudeDOM = document.getElementById("latitude");
var longitudeDOM = document.getElementById("longitude");
var foundStationDOM = document.getElementById("foundStation");
var foundStationDivDOM = document.getElementById("foundStationDiv");

function callJCDecaux(url, requestParams, callback) {
    let URLToCall = url;

    if (requestParams) {
        URLToCall += "?" + requestParams.join("&");
    }

    let jcdecauxRequest = new XMLHttpRequest();
    jcdecauxRequest.open("GET", URLToCall, true);
    jcdecauxRequest.setRequestHeader ("Accept", "application/json");
    jcdecauxRequest.onload=callback;

    jcdecauxRequest.send();
}

function retrieveAllContracts() {
    const APIUrl = "https://api.jcdecaux.com/vls/v3/contracts";
    const params = ["apiKey=" + apiKeyDOM.value];

    callJCDecaux(APIUrl, params, function() {
        if (this.status !== 200) {
            alert("Erreur lors de la requete HTTP");
        } else {
            const JSONResponse = JSON.parse(this.responseText);
            const contracts = JSONResponse.map(function(contract) {
                return contract.name;
            });
            contractsListDOM.innerHTML = "";
            for (let i=0; i<contracts.length; i++) {
                const currentContract = contracts[i];
                const option = document.createElement("option");
                option.setAttribute("value", currentContract);
                contractsListDOM.appendChild(option);
            }
            chooseContractDivDOM.style.display = "block";
        }
    });
}

function retrieveContractStations() {
    const selectedContract = chosenContractDOM.value;
    const APIUrl = "https://api.jcdecaux.com/vls/v3/stations";
    const params = ["apiKey=" + apiKeyDOM.value, "contract=" + selectedContract];

    callJCDecaux(APIUrl, params, function() {
        if (this.status !== 200) {
            console.log("Stations not retrieved. Check the error in the Network or Console tab.");
        } else {
            stationsList = JSON.parse(this.responseText);
            chooseStationDivDOM.style.display = "block";
        }
    });
}

function findClosestStation() {
    const latitude = latitudeDOM.value;
    const longitude = longitudeDOM.value;

    let minDistance = -1;
    let closestStation = null;

    for (let i=0; i<stationsList.length; i++) {
        const currentStation = stationsList[i];
        const distance = getDistanceFrom2GpsCoordinates(latitude, longitude, currentStation.position.latitude, currentStation.position.longitude);
        if (minDistance === -1 || minDistance > distance) {
            minDistance = distance;
            closestStation = currentStation.name;
        }
    }
    foundStationDivDOM.style.display = "block";
    foundStationDOM.innerHTML = closestStation;
}

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    const earthRadius = 6371;
    const dLat = deg2rad(lat2-lat1);
    const dLon = deg2rad(lon2-lon1);
    const a =
        Math.sin(dLat/2) * Math.sin(dLat/2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon/2) * Math.sin(dLon/2)
    ;
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
    const d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI/180)
}