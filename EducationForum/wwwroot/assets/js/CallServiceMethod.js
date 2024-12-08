
function Callservice(object1, object2) {
    console.log('callservice')
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: 'POST',
            url: object2,
            data: object1,
            dataType: 'json',
            /* timeout: 1000,*/
            success: function (data) {
                //console.log(data)
                var ArrayofMessage = data.returnMessage.split(':')
                if (data.iscreatedSucessfully == true) {
                    //alert("sucess")
                    if (data.errorDisplayType == 'ErrorStrip') {
                        var Sucessstrip = `<div class="alert alert-success alert-dismissible fade show" role="alert">
                                        <strong>`+ ArrayofMessage[0] + ` !</strong> ` + ArrayofMessage[1] + `.
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>`;
                        $("#ReturnMessageStrip").show();
                        $('#ReturnMessageStrip').html(Sucessstrip);

                        $('html').animate({ scrollTop: 0 }, 'slow');//IE, FF
                        $('body').animate({ scrollTop: 0 }, 'slow');//chrome, don't know if Safari works

                        setTimeout(function () {
                            window.location.href = data.redirectTo;
                        }, 1000);

                    }
                    else if (data.errorDisplayType == 'toaster') {
                        toastr.options = {
                            "closeButton": true,
                            "debug": true,
                            "newestOnTop": false,
                            "progressBar": true,
                            "positionClass": "toast-top-right",
                            "preventDuplicates": false,
                            //"showDuration": "300",
                            //"hideDuration": "1000000",
                            "timeOut": "1000",
                            //"extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut",
                            onHidden: function () {
                                window.location.href = data.redirectTo;
                            }
                        }
                        toastr["success"](ArrayofMessage[1], ArrayofMessage[0] + '!');
                    }


                }

                else if (data.iscreatedSucessfully == false) {
                    //alert("failed")
                    if (data.errorDisplayType == 'ErrorStrip') {
                        var Errortrip = `<div class="alert alert-danger alert-dismissible fade show" role="alert">
                                     <strong>`+ ArrayofMessage[0] + ` !</strong> ` + ArrayofMessage[1] + `.
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>`;
                        $("#ReturnMessageStrip").show();
                        $('#ReturnMessageStrip').html(Errortrip);
                        //console.log('errat : ' + ArrayofMessage[2])
                        $('html').animate({ scrollTop: 0 }, 'slow');//IE, FF
                        $('body').animate({ scrollTop: 0 }, 'slow');//chrome, don't know if Safari works
                    }
                    else if (data.errorDisplayType == 'toaster') {
                        toastr.options = {
                            "closeButton": true,
                            "debug": true,
                            "newestOnTop": false,
                            "progressBar": true,
                            "positionClass": "toast-top-right",
                            "preventDuplicates": false,
                            //"showDuration": "300",
                            //"hideDuration": "1000000",
                            "timeOut": "1000",
                            //"extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut",
                            onHidden: function () {
                                window.location.href = data.redirectTo;
                            }
                        }
                        toastr["error"](ArrayofMessage[1], ArrayofMessage[0] + '!');
                    }

                }
                else
                {

                    //if (data.Result == 'Error') {
                    //    $('html').animate({ scrollTop: 0 }, 'slow');//IE, FF
                    //    $('body').animate({ scrollTop: 0 }, 'slow');//chrome, don't know if Safari works
                    //    $("#Errstrip").show();
                    //    $("#Errtxt").text(data.value);

                    //}

                }
                //alert('hi')
                $('#' + data.spinnerID).hide();
                $("#" + data.buttonSubmited).prop("disabled", false);
            }


        });
    });
}
//$.ajaxSetup({
//    cache: false
//}); 