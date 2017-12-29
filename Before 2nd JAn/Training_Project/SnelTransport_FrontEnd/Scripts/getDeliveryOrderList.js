
$(document).ready(function () {

    $("#btnDeliveryAddress").click(function () {

        $.ajax({
            url: globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_GETCUSTOMER,          
            type: "GET",
            Accept: "application/json",
            success: function (resultdata) {
             
                $.each(resultdata, function (k, v) {                                  
                    var name = v.Name;
                    var street = v.Street;
                    var houseNumber = v.HouseNumber;
                    var postcode = v.PostCode;
                    var city = v.City;
                    var address = street+" " + houseNumber+", " + postcode+", " + city;                  

                    $("#tblGetAddress").append("<tr><td>" + name + "</td><td>" + street + " " + houseNumber + ", " + postcode + ", " + city + "</td></tr>");

                });     
            },
            error: function (e) { 
                alert("something went wrong!");
            }            

        });
    });
});