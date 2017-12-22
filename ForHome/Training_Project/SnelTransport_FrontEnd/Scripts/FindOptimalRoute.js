
var originlist = [];
var destinationlist = [];

$(document).ready(function () {

    $("#btnDeliveryAddress").click(function () {

        $.ajax({

            url: "http://localhost:64504/Service.svc/rest/GetCustomer",
            type: "GET",
            Accept: "application/json",
            success: function (resultdata) {
               // console.log(resultdata);
                $.each(resultdata, function (k, v) {

                   // var id = v.Id;
                    var name = v.Name;
                    var street = v.Street;
                    var houseNumber = v.HouseNumber;
                    var postcode = v.PostCode;
                    var city = v.City;
                    var address = street+" " + houseNumber+", " + postcode+", " + city;
                   // var telephone = v.Telephone;
                   // var fax = v.Fax;

                    $("#tblGetAddress").append("<tr><td>" + name + "</td><td>" + street + " " + houseNumber + ", " + postcode + ", " + city + "</td></tr>");
                   // console.log(document.getElementById("tblGetAddress").rows[2].cells[1].innerHTML);   

                });

               // var deliverlist_data = [];
                // deliverlist_data = resultdata
                for (var i = 0; i < resultdata.length; i++) {
                   // console.log(resultdata[i].city);
                    originlist[i] = resultdata[i].Street + " " + resultdata[i].HouseNumber + ", " + resultdata[i].PostCode + ", " + resultdata[i].City;
                    destinationlist[i] = originlist[i] ;
                }

               // console.log(originlist);
               // console.log(destinationlist);


                for (var i = 0; i < originlist.length; i++)
                    for (var j = i; j < destinationlist.length; j++) {
                        console.log("Origin Address: " + originlist[i] + "  and Destination Address:" + destinationlist[j]);
                       // console.log(document.getElementById("tblGetAddress").rows[2].cells[1].innerHTML);
                    }
                
            },
            error: function (e) { 
                alert("something went wrong!");
            }


            

        });
    });

   


   


});