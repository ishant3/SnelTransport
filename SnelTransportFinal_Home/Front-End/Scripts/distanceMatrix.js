

var Addresses = [];
var JsonDataObj = [];
var new_table;
var googleMatrixJSON;
var myData;
var unload_Time;
var delivery_Address = [];
var array1 = [];
var mytempFinalAddress = [];
var origin;
var truck_Number;
var Name;

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
   
    // console.log(table);
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
     return myData = '[' + JsonDataObj + ']';
     //alert(googleMatrixJSON)
    // console.log(googleMatrixJSON);
     
    // alert(JsonDataObj);
   
     // alert(myData);
    // console.log(JsonDataObj);
    
}


//function GetUnloadTime() {
//    var num = unload_Time;
//    var firstpart = Math.trunc(num);
//    var secondpart = Math.round(100 * Math.abs(num - firstpart));
//    var total;

//    if (firstpart == 0) {
//        total = secondpart;
//        return total;
//    }
//    else {
//        total = firstpart * 60 + secondpart;
//        return total;
//    }

//}



function initMap() {

   // var start_address = "Zeugstraat 92, 2801 JD Gouda, Netherlands";
  //  Addresses.push(start_address);
    $.ajax({
        url: globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_GET_CONFIG_OPTIMAL_ROUTE,
         async:false,
        type: "GET",
        Accept: "application/json",
        success: function (resultdata) {
            for (var i = 0; i <= resultdata.length; i++) {
                var Maximum_Hour = resultdata[i].Maximum_Hour;
                 Name = resultdata[i].Name;
                unload_Time = resultdata[i].Unload_Time;
                //truck_Number= resultdata[i].Truck_Number;
                console.log(unload_Time);
            }
        },
        error: function (e) {
            alert("something went wrong!");
        }


    });

    var mylength = document.getElementById("tblGetAddress").rows.length;  
  
    for (var i = 1; i < mylength; i++) {      
        Addresses.push(document.getElementById("tblGetAddress").rows[i].cells[1].innerHTML);
      
    }
  
    Addresses.push(Name);
   // console.log(Addresses);
 
    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix(
        {
            origins: Addresses ,
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
            for (var i = 0; i <origins.length; i++) {
                mytempFinalAddress.push(origins[i]);
            }
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
            //http://localhost/Service_Database_Connection/Service.svc/rest 
            url: "http://192.168.0.109/Back-End/Service1.svc/rest/InsertDistance_Data",
            async: false,
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: convertHTML_JSON(), // googleMatrixJSON ,
            success: function (result) {
               // console.info(result);
               // alert(result);
               // alert("hehehe");

            
            },
            error: function (e) {
                alert("Success!");
            }
        }).then(function (result) {
           // console.log(result);
           // alert(result);

            });


    })
});


function fillRoute() {

    $.ajax({
        url: globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_GET_CONFIG_OPTIMAL_ROUTE,
       // async:false,
        type: "GET",
        Accept: "application/json",
        success: function (resultdata) {
            for (var i = 0; i <= resultdata.length; i++) {
                var Maximum_Hour = resultdata[i].Maximum_Hour;
                  var Name = resultdata[i].Name;
                unload_Time = resultdata[i].Unload_Time;
                //truck_Number= resultdata[i].Truck_Number;
                console.log(unload_Time);
            }
        },
        error: function (e) {
            alert("something went wrong!");
        }


    });


    $.ajax({

        url: globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_GETOPTIMAL,
        type: "GET",
        async: false,
        Accept: "application/json",
        success: function (resultdata1) {
            var total_final_time = 0;
            var final_hour;
            var final_minutes;
            // console.log(unload_Time);
            //alert(unload);
            var myunloadtime = unload_Time;
           // alert(myunloadtime);
            // console.log(myunloadtime);
            alert(myunloadtime);
            for (var i = 0; i <= resultdata1.length; i++) {

                var id = resultdata1[i].Id;
                 var origin = resultdata1[i].Origin;               
                var destination = resultdata1[i].Destination;
                var distance = resultdata1[i].Distance;
                var duration = resultdata1[i].Duration;
                truck_Number = resultdata1[i].Truck_Number;
                delivery_Address.push(origin);

                //console.log(unload_Time);
                var time = duration;

                // var myunloadtime = 30;

                if (i == (resultdata1.length - 1)) {
                    myunloadtime = 0;
                }


                total_final_time = total_final_time + time + myunloadtime;
               

                var hour = Math.trunc(time / 60);
                var minutes = time % 60;

                final_hour = Math.trunc(total_final_time / 60);
                final_minutes = total_final_time % 60;

                // alert(delivery_Address);
              //  console.log(delivery_Address);

                $("#tblGetOptimalRoute").append("<tr><td>" + origin + "</td><td>" + destination + "</td><td>" + distance / 1000 + " km" + "</td><td>" + hour + " hours " + minutes + " mins " + "</td><td>" + " " + final_hour + " hours " + final_minutes + " mins" + "</td><td>" + truck_Number + "</td></tr > ");

            }



        },
        error: function (e) {
            alert("something went wrong!");
        }


    });

}


//$(document).ready(function () {

//    $("#btnOptimalRoute").click(function () {            
        
                
//        $.ajax({
//            url:globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_GET_CONFIG_OPTIMAL_ROUTE,
//            type: "GET",
//            Accept: "application/json",
//            success: function (resultdata) {
//                for (var i = 0; i <= resultdata.length; i++)
//                {
//                    var Maximum_Hour = resultdata[i].Maximum_Hour;
//                    var Name = resultdata[i].Name;
//                     unload_Time = resultdata[i].Unload_Time;  
//                     console.log(unload_Time);
//                }              
//            },
//            error: function (e) {
//                alert("something went wrong!");
//            }


//        });                
       
       
//        $.ajax({

//            url: globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_GETOPTIMAL,
//            type: "GET",
//            Accept: "application/json",
//            success: function (resultdata1) {
//                var total_final_time = 0;
//                var final_hour;
//                var final_minutes;   
//               // console.log(unload_Time);
//                //alert(unload);
//                var myunloadtime = GetUnloadTime();
//                alert(myunloadtime);
//               // console.log(myunloadtime);

//                for (var i = 0; i <= resultdata1.length; i++) {                 

//                        var id = resultdata1[i].Id;
//                        var origin = resultdata1[i].Origin;
//                        var destination = resultdata1[i].Destination;
//                        var distance = resultdata1[i].Distance;
//                        var duration = resultdata1[i].Duration;
//                        delivery_Address.push(origin);

//                        //console.log(unload_Time);
//                        var time = duration;
                      
//                       // var myunloadtime = 30;

//                        if (i == (resultdata1.length - 1) ) {
//                            myunloadtime = 0;
//                        }

                        
//                        total_final_time = total_final_time + time+ myunloadtime;
                       
//                        var hour = Math.trunc(time / 60);
//                        var minutes = time % 60;

//                        final_hour = Math.trunc(total_final_time / 60);
//                        final_minutes = total_final_time % 60;

//                       // alert(delivery_Address);
//                        console.log(delivery_Address);

//                        $("#tblGetOptimalRoute").append("<tr><td>" + origin + "</td><td>" + destination + "</td><td>" + distance / 1000 + " km" + "</td><td>" + hour + " hours " + minutes + " mins " + "</td><td>" + " " + final_hour + " hours " + final_minutes + " mins" + "</td></tr > ");
                       
//                }

              

//            },
//            error: function (e) {
//                alert("something went wrong!");
//            }
                      

//        });
//    });



//});

$(document).ready(function () {

    $("#btnDeliveryOptimalAddress").click(function () {

        for (var i = 1; i <= delivery_Address.length -1; i++)
        {
            var address = delivery_Address[i];
            $("#tblOptimalAddress").append("<tr><td>" + address + "</td></tr>");


        }        
    });


});

$(document).ready(function () {

    $("#btnNonDeliveryOptimalAddress").click(function () {

        //var array1 = new Array("a", "b", "c", "d", "e", "f");
        //var array2 = new Array("c", "e");



       //var trytestADDRESS= ["Zeugstraat 92, 2801 JD, Gouda", "Jacob van Lennepstraat 46, 1053 HL, Amsterdam",  "Lambertus Buddestraat 70, 7521 SB, Enschede", "Groningerweg 45/2, 9738 AB, Groningen"];
       // console.log(Addresses);
       // console.log(delivery_Address);

       // var array3 = array1.filter(val => !array2.includes(val));
       // console.log(array3);

       // console.log(Addresses);
       // console.log(delivery_Address);

        var array4;
        array4 = mytempFinalAddress.filter(val => !delivery_Address.includes(val));
        console.log(array4);
        $("#tblNonDeliveryAddress").append("<tr><td>" + array4 + "</td></tr>");
    });


});

//for office accessing value outside the ajax

//$.getJSON('check-location.php?onload=true', function (result) {
//    $.each(result, function (i) {
//        MainArray[i] = result[i].CountryName;
//    });
//    $(".drop-down").append("<div>" + MainArray[0] + "</div>");
//});

    



