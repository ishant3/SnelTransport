$(document).ready(function () {

    $("#btnGetCustomer").click(function () {

        $.ajax({
            url: globalVariable.URL_JAVA + globalVariable.URL_ALL_CUSTOMERS,           
            type: "GET",
            Accept: "application/json",
            success: function (resultdata) {

                $.each(resultdata, function (k, v) {

                    var id = v.customer_id;
                    var name = v.customer_name;
                    var street = v.customer_street;
                    var houseNumber = v.customer_housenumber;
                    var postcode = v.customer_postcode;
                    var city = v.customer_city;                    
                    var telephone = v.customer_tel_number;
                    var fax = v.customer_fax_number;

                    $("#tbl").append("<tr><td>" + id + "</td><td>" + name + "</td><td>" + street + "</td><td>" + houseNumber + "</td><td>" + postcode + "</td><td>" + city + "</td><td>" + telephone + "</td><td>" + fax + "</td></tr>")
                 
                });
            },
            error: function (e) {
                alert("something went wrong!");
            }


        });
    });


});

