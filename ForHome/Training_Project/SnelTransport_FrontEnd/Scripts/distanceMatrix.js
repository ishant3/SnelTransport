

var Addresses = [];
var JsonDataObj = [];
var new_table;
var googleMatrixJSON;
var myData;



function Calculate_Distance(value) {
    var words = value.split(" ");
    var distance = words[0];
    var distance_unit = words[1];

    if (distance_unit.includes("km")) {
        distance = distance * 1000;
    }
    else {
        distance = distance * 1;
    }
    return distance;

}

function Calculate_Time(value)
{
    var total_time;
    if (value.includes("hour") || value.includes("hours")) {
        var words = value.split(" ");
        var hour = words[0] * 60;
        var min = words[2]*1;
        total_time = hour + min;
    }
    else {
        var words = value.split(" ");
        var min = words[0];
        total_time = min;
    }
    return total_time;

}

function convertHTML_JSON() {

   var table = $('#tblGetDistance').tableToJSON();
   
     console.log(table);
     for (var i = 0; i < table.length; i++) {
         new_table = {
             Origin: table[i].Origin,
             Destination: table[i].Destination,
             Distance: Calculate_Distance(table[i].Distance),
             Duration: Calculate_Time(table[i].Duration)
         };   
        googleMatrixJSON = JSON.stringify(new_table);
        JsonDataObj.push(googleMatrixJSON);
     }  
    
     //alert(googleMatrixJSON)
    // console.log(googleMatrixJSON);
     
    // alert(JsonDataObj);
      myData = '[' + JsonDataObj + ']'
     // alert(myData);
    // console.log(JsonDataObj);
    
}


function initMap() {
    var mylength = document.getElementById("tblGetAddress").rows.length;
    for (var i = 1; i < mylength; i++) {
        Addresses.push(document.getElementById("tblGetAddress").rows[i].cells[1].innerHTML);
    }

    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix(
        {
            origins: Addresses,
            destinations: Addresses,
            travelMode: 'DRIVING',
            unitSystem: google.maps.UnitSystem.METRIC,
            avoidHighways: false,
            avoidTolls: false,
        }, callback);

    function callback(response, status) {
        // See Parsing the Results for
        // the basics of a callback function.
        if (status == 'OK') {
            var origins = response.originAddresses;
            var destinations = response.destinationAddresses;

            for (var i = 0; i < origins.length; i++) {
                var results = response.rows[i].elements;

                for (var j = 0; j < results.length; j++) {
                    var element = results[j];
                    var distance = element.distance.text;
                    var duration = element.duration.text;
                    var from = origins[i];
                    var to = destinations[j];

                    $("#tblGetDistance").append("<tr><td>" + from + "</td><td>" + to + "</td><td>" + distance + "</td><td>" + duration + "</td></tr>");
                }

            }

        }
    }

}

$(document).ready(function () {

    $("#btnInsert").click(function () {

        

        $.ajax({

            url: "http://localhost:64504/Service.svc/rest/InsertDistance_Data",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data:  myData,// googleMatrixJSON ,
            success: function (result) {
               // console.info(result);
               // alert(result);
               // alert("hehehe");

            
            }
            //error: function (e) {
            //    alert("something went wrong!");
            //}
        }).then(function (result) {
           // console.log(result);
           // alert(result);

            });


    })
});


$(document).ready(function () {

    $("#btnOptimalRoute").click(function () {

        $.ajax({

            url: "http://localhost:64504/Service.svc/rest/GetOptimal",
            type: "GET",
            Accept: "application/json",
            success: function (resultdata) {
                var total_final_time = 0;
                var final_hour;
                var final_minutes;
                $.each(resultdata, function (k, v) {

                    var id = v.Id;
                    var origin = v.Origin;
                    var destination = v.Destination;
                    var distance = v.Distance;
                    var duration = v.Duration;  

                    var time = duration;
                    total_final_time = total_final_time+ time;
                    var hour = Math.trunc(time / 60);
                    var minutes = time % 60;

                     final_hour = Math.trunc(total_final_time / 60);
                     final_minutes = total_final_time % 60;

                    $("#tblGetOptimalRoute").append("<tr><td>" + origin + "</td><td>" + destination + "</td><td>" + distance / 1000 + " km" + "</td><td>" + hour + " hours " + minutes + " mins " + "</td><td>" + " "+ final_hour + " hours " + final_minutes + " mins" + "</td></tr > ")
                   // alert(document.getElementById("tblGetOptimalRoute").rows[1].cells[1].innerHTML);
                });
            },
            error: function (e) {
                alert("something went wrong!");
            }


        });
    });


});

       

    



