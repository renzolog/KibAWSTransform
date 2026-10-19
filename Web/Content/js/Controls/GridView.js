var griglia;

function GrigliaOnInit(s, e) {
    griglia = s;
    griglia.SetFocusedRowIndex(-1);
    GrigliaAdjustSize();
    var divGriglia = document.getElementById("gridContainer"); 

    if (divGriglia != null) {
        document.getElementById("gridContainer").style.visibility = "";
    } 

}

function GrigliaOnEndCallback(s, e) {
    griglia = s;
    GrigliaAdjustSize();
}

function GrigliaAdjustSize() {

    if (griglia != undefined) {
        try {

            var height = Math.max(0, document.documentElement.clientHeight - 190);
            griglia.SetHeight(height);
        }
        catch (ex) { }
    }
}

 
 