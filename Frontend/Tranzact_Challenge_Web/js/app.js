const apiURL = "https://localhost:44360";

let GetPremium = () => {
    
    const url = new URL(apiURL + "/api/premium");
    if(document.getElementById("txtBirthDate").value == ""){
        alert("Ingrese una fecha");
    }

    var params = {
        state: document.getElementById("cboStates").value,
        dateOfBirth: document.getElementById("txtBirthDate").value,
        plan: document.getElementById("cboPlan").value,
        period: document.getElementById("cboPeriod").value
    }
    url.search = new URLSearchParams(params).toString();

    fetch(url).then(function (response) {
        if (response.status >= 200 && response.status <= 299) {
            return response.json();
        } else {
            throw Error(response.statusText);
        }
    }).then(function (Data) {
        sessionStorage.setItem('premiumCurrently', JSON.stringify(Data));

        Calculate(Data);
    }).catch((error) => {
        console.log(error);
    })
}

let Calculate = (data) => {
    $("#tblPremiumResults > tbody").empty();
    const vPeriod = document.getElementById("cboPeriod").value;
    const arrPeriod = JSON.parse(sessionStorage.getItem('periods'));
    const objM = arrPeriod.find(x => x.value === vPeriod);

    if (data) {
        var tbodyRef = document.getElementById('tblPremiumResults').getElementsByTagName('tbody')[0];

        data.forEach(function (entry) {
            var rowsValues = [
                entry.carrier,
                entry.premiumAmount,
                (entry.premiumAmount * objM.annual).toFixed(2),
                (entry.premiumAmount / objM.monthly).toFixed(2)
            ];
            var newRow = tbodyRef.insertRow();

            rowsValues.forEach(function (m) {
                var newCell = newRow.insertCell();
                var carrierTxt = document.createElement("input");
                carrierTxt.setAttribute("type", "text");
                carrierTxt.setAttribute("disabled", "true");
                carrierTxt.value = m;
                newCell.appendChild(carrierTxt);
            }, this);

        }, this);
    }
}

let CalculateAge = () => {
    var date = document.getElementById("txtBirthDate").value;
    if(date == '' || (new Date(date) === "Invalid Date") && isNaN(new Date(date))){
        document.getElementById("btnGetPremium").disabled = true;
        return;
    }else{
        document.getElementById("btnGetPremium").disabled = false;
        document.getElementById("txtAge").value = 0;
    }

    var vDateBirth = document.getElementById("txtBirthDate").value;
    var dob = new Date(vDateBirth);
    if (vDateBirth == null || vDateBirth == '') {
        return false;
    } else {
        var month_diff = Date.now() - dob.getTime();
        var age_dt = new Date(month_diff);
        var year = age_dt.getUTCFullYear();
        var age = Math.abs(year - 1970);

        document.getElementById("txtAge").value = age;
    }
}

let GetStates = () => {
    const url = new URL(apiURL + "/api/state");

    fetch(url).then(function (response) {
        if (response.status >= 200 && response.status <= 299) {
            return response.json();
        } else {
            throw Error(response.statusText);
        }
    }).then(function (Data) {
        SetSelects('cboStates', Data);
    }).catch((error) => {
        console.log(error);
    })
}

let GetPlans = () => {
    const url = new URL(apiURL + "/api/plan");

    fetch(url).then(function (response) {
        if (response.status >= 200 && response.status <= 299) {
            return response.json();
        } else {
            throw Error(response.statusText);
        }
    }).then(function (Data) {
        SetSelects('cboPlan', Data);
    }).catch((error) => {
        console.log(error);
    })
}

let GetPeriods = () => {
    const url = new URL(apiURL + "/api/period");

    fetch(url).then(function (response) {
        if (response.status >= 200 && response.status <= 299) {
            return response.json();
        } else {
            throw Error(response.statusText);
        }
    }).then(function (Data) {
        sessionStorage.setItem('periods', JSON.stringify(Data));
        SetSelects('cboPeriod', Data);
    }).catch((error) => {
        console.log(error);
    })
}

let SetSelects = (id, data) => {
    var sel = document.getElementById(id);

    data.forEach(function (m) {
        var opt = document.createElement('option');
        opt.appendChild(document.createTextNode(m.text));
        opt.value = m.value;
        sel.appendChild(opt);
    }, this);
}

$('#txtBirthDate').change(function (event) {       
    CalculateAge();
});

$('#btnGetPremium').click(function (event) {
    GetPremium();
});

$('#cboPeriod').change(function (event) {
    var data = JSON.parse(sessionStorage.getItem('premiumCurrently'));
    Calculate(data);
});

(function () {
    GetStates();
    GetPlans();
    GetPeriods();
    CalculateAge();
})();

