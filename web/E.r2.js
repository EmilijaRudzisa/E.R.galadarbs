
function dataToSentSKola() {
    var id = document.getElementById('inputID').value;
    var Na = document.getElementById('inputNA').value;
    var Ad = document.getElementById('inputAD').value;
    var Pr = document.getElementById('inputPR').value;

    var dataToSent = {
        "id": id,
        "name": Na,
        "address": Ad,
        "principal": Pr
    };

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200){
            alert(this.responseText);
        }
    };


};