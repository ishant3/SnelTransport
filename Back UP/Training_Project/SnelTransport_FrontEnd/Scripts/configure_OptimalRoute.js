
$(document).ready(function () {

    $("#sendConfigProperty").click(function () {


        var x = $("#startAddress").val();
        var y = $("#maximum_Hour").val();
        var z = $("#unload_Time").val();
        var a = $("#truck_Number").val();

        $.ajax({
            url: globalVariable.URL_CSHARP + globalVariable.URL_OPTIMAL_ROUTE_POST_CONFIG_OPTIMAL_ROUTE,
            type: "POST",
            async: false,
            contentType: "application/json",
            dataType: "json",
            data: '{"Maximum_Hour":"' + y + '", "Name":"' + x + '","Unload_Time":"' + z + '","Truck_Number":"' + a + '"}',

            success: function (e) {
                alert("Success");
            },
            error: function (e) {
                alert("Successsss went wrong!");
            }

        });


    });

   

}); 




