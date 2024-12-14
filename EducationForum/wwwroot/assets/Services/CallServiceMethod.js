$.ajaxSetup({
    cache: false
});
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
                console.log(data)
                var payload = data;
                if (payload && payload?.errorType == 'toster') {
                    toastr.options = {
                        "closeButton": true,
                        "debug": true,
                        "newestOnTop": false,
                        "progressBar": true,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "timeOut": "3000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut",
                        onHidden: function () {
                            if (payload.redirectTo) {
                                window.location.href = payload.redirectTo;
                            }
                        }
                    };
                    if (payload.status === "success") {
                        toastr.success(payload.returnMessage);
                        window.location.href = payload.redirectTo;
                    } else if (payload.status === "error") {
                        toastr.error(payload.returnMessage);
                    } else if (payload.status === "info") {
                        toastr.info(payload.returnMessage);
                    } else if (payload.status === "warning") {
                        toastr.warning(payload.returnMessage);
                    }
                }
                else if (payload && payload?.errorType == 'sweet') {
                    Swal.fire({
                        position: "center",
                        icon: "success",
                        title: payload.title,
                        text: payload.returnMessage,
                        showConfirmButton: false,
                        timer: 2000
                    });
                }
                $(payload.spinnerID).hide();
                $(payload.buttonID).prop("disabled", false);
            }

        });
    });
}
