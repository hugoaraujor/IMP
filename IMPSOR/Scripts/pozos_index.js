$(document).ready(function () {

     $("#campo").change(function (data) {
        $("#yacimiento").val(0);
         $("#forma").submit();
            
    });
    $("#yacimiento").change(function (data) {
        $("#forma").submit();
        
    });
    $("#procesados").change(function () {
                $("#forma").submit();
    });


    $("form-check-input").change(function () {
        $("#forma").submit();
    });
    $("#envia").click(function () {
       
       $("#flow").val(5);
        $("#forma").submit();
    });
    setTimeout(onComplete(), 5000);
   
    function onComplete() {
        $("#divLoading").toggle();
       
    }



});


