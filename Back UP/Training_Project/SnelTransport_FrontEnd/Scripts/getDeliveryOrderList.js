var order_Customer_id;
var name;
var customer_Info = [];
var Order_customer_Info = [];
var array4 = [];
var eecustomer_Info = [];
var myCounter;
var qcustomer_id;

function Undeliver() {

    $.ajax({
        url: globalVariable.URL_JAVA + globalVariable.URL_UNDELIVERED_ORDERS,
        type: "GET",
        async: false,
        Accept: "application/json",
        success: function (resultdata) {

            $.each(resultdata, function (k, v) {

                qcustomer_id = v.customer_id;

                Order_customer_Info.push({ qcustomer_id });

                //$("#tblundeliveredAddress").append("<tr><td>" + qcustomer_id + "</td></tr>")

            });


        },
        error: function (e) {
            alert("something went wrong!");
        }


    });


    $.ajax({
        url: globalVariable.URL_JAVA + globalVariable.URL_ALL_CUSTOMERS,
        type: "GET",
        async: false,
        Accept: "application/json",
        success: function (resultdata) {

            $.each(resultdata, function (k, v) {

                customer_id = v.customer_id;
                name = v.customer_name;

                var street = v.customer_street;
                var houseNumber = v.customer_housenumber;
                var postcode = v.customer_postcode;
                var city = v.customer_city;
                var telephone = v.customer_tel_number;
                var fax = v.customer_fax_number;

                eecustomer_Info.push({ customer_id, name, street, houseNumber, postcode, city, telephone, fax });


            });

            for (var i = 0; i < Order_customer_Info.length; i++) {
                //console.log(Order_customer_Info[i].qcustomer_id);           
                var obj = eecustomer_Info.find(function (obj) { return obj.customer_id == Order_customer_Info[i].qcustomer_id; });
                // console.log(obj);
                // $("#tblundeliveredAddress").append("<tr><td>" + obj.city + "</td></tr>");
                $("#tblGetAddress").append("<tr><td>" + obj.name + "</td><td>" + obj.street + " " + obj.houseNumber + ", " + obj.postcode + ", " + obj.city + "</td></tr>");
            }

            //var obj = eecustomer_Info.find(function (obj) { return obj.customer_id == Order_customer_Info[2].qcustomer_id; });
            //console.log(obj);


        },
        error: function (e) {
            alert("something went wrong!");
        }


    });

    // console.log(Order_customer_Info);    
    // console.log(eecustomer_Info);





}




