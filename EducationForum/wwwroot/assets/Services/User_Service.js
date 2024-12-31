

(function () {
    $('#usersubmitSpinner').hide();
    BindUserTypeDD();
})();
$('#smspin').removeClass('show').addClass('hide');
$('#usersubmit').click(async function (event) {
    var validStatus = await Validatecheck();
    console.log(validStatus);
    if (validStatus) {
        $('#usersubmit').prop("disabled", true);
        $('#usersubmitSpinner').show();
        $('#smspin').removeClass('hide').addClass('show');
        var datastring = $(this).closest('form').serialize();
        //console.log(datastring);
        var url = '/Admin/UserCreate';
        Callservice(datastring, url);
    }
    else {
        event.preventDefault();
    }
});

$('#FirstName, #email, #Mobile,#Password,#ConfirmPassword,#UserTypeDD').on('input', function (event) {
    //console.log(event.currentTarget.id);
    var Id = event.currentTarget.id;
    Validatecheck(Id);
});
function BindUserTypeDD() {
    $.ajax({
        type: 'GET',
        url: '/Admin/GetUserType',
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<option value="' + response[i].userTypeID + '">' + response[i].userType + '</option>';
            }
            $("#UserTypeDD").html(DDOptions);
        },
        async: true
    });

}
async function Validatecheck(Id = null) {
    if (Id) {
        if (Id === 'FirstName') {
            var firstname = $('#FirstName');
            firstname.toggleClass('error', !firstname.val());
            firstname.toggleClass('noneerror', !!firstname.val());
        }
        else if (Id === 'Password' || Id === 'ConfirmPassword') {
            var password = $('#' + Id);
            password.toggleClass('error', !password.val());
            password.toggleClass('noneerror', !!password.val());
            validatePassword();
        }
        else if (Id === 'email') {
            var email = $('#email');
            var isValidEmail = validateEmail(email.val());
            email.toggleClass('error', !isValidEmail);
            email.toggleClass('noneerror', isValidEmail);
        }
        else if (Id === 'Mobile') {
            var Mobile = $('#Mobile');
            var isValidPhone = validatePhone(Mobile.val());
            Mobile.toggleClass('error', !isValidPhone);
            Mobile.toggleClass('noneerror', isValidPhone);
        }
        else if (Id === 'UserTypeDD') {
            var Mobile = $('#UserTypeDD');
            var isValidPhone = validatePhone(UserTypeDD.val());
            Mobile.toggleClass('error', !isValidPhone);
            Mobile.toggleClass('noneerror', isValidPhone);
        }
        return false;
    }
    var firstname = $('#FirstName');
    var email = $('#email');
    var Mobile = $('#Mobile');
    var password = $('#Password');
    var confirmpassword = $('#ConfirmPassword');
    var UserTypeDD = $('#UserTypeDD');

    var isValidEmail = validateEmail(email.val());
    var isValidPhone = validatePhone(Mobile.val());

    firstname.toggleClass('error', !firstname.val());
    email.toggleClass('error', !isValidEmail);
    Mobile.toggleClass('error', !isValidPhone);
    password.toggleClass('error', !password.val());
    confirmpassword.toggleClass('error', !confirmpassword.val());
    UserTypeDD.toggleClass('error', !UserTypeDD.val());

    firstname.toggleClass('noneerror', !!firstname.val());
    email.toggleClass('noneerror', isValidEmail);
    Mobile.toggleClass('noneerror', isValidPhone);
    password.toggleClass('noneerror', !!password.val());
    confirmpassword.toggleClass('noneerror', !!confirmpassword.val());
    UserTypeDD.toggleClass('noneerror', !!UserTypeDD.val());

    return firstname.val() && isValidEmail && isValidPhone && password && confirmpassword && UserTypeDD && validatePassword();
}

function validateEmail(email) {
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
}

function validatePhone(phone) {
    var phonePattern = /^[6-9]{1}[0-9]{9}$/;
    return phonePattern.test(phone);
}


function checkPasswordStrength(password) {
    const strengthCriteria = [
        /[A-Z]/,          // At least one uppercase letter
        /[a-z]/,          // At least one lowercase letter
        /\d/,             // At least one number
        /[!@#$%^&*(),.?":{}|<>]/,  // At least one special character
        /.{8,}/           // Minimum length of 8 characters
    ];

    let strengthMessage = "";
    if (!strengthCriteria[0].test(password)) {
        strengthMessage += "◘ Password must contain at least one uppercase letter.\n";
    }
    else if (!strengthCriteria[1].test(password)) {
        strengthMessage += "◘ Password must contain at least one lowercase letter.\n";
    }
    else if (!strengthCriteria[2].test(password)) {
        strengthMessage += "◘ Password must contain at least one number.\n";
    }
    else if (!strengthCriteria[3].test(password)) {
        strengthMessage += "◘ Password must contain at least one special character.\n";
    }
    else if (!strengthCriteria[4].test(password)) {
        strengthMessage += "◘ Password must be at least 8 characters long.\n";
    }
    else {
        strengthMessage = "";
    }

    return strengthMessage;
}

function validatePassword() {
    const password = document.getElementById("Password").value;
    const confirmPassword = document.getElementById("ConfirmPassword").value;


    if (password !== confirmPassword) {
        document.getElementById("match-error").innerText = "Passwords do not match!";
        return false;
    } else {
        document.getElementById("match-error").innerText = "";
    }

    const strengthMessage = checkPasswordStrength(password);
    if (strengthMessage) {
        document.getElementById("strength-error").innerText = strengthMessage;
        return false;
    } else {
        document.getElementById("strength-error").innerText = "";
    }

    return true;
}


//var fileInput = document.getElementById('Image');
//var ImageName = document.getElementById('ImageName');
//var Imagebase64 = document.getElementById('UserImage');
//var preview = document.getElementById("Document-preview");
//fileInput.addEventListener("change", function (event) {

//    const file = event.target.files[0];
//    const fileName = file?.name;
//    const fileExtension = fileName.split(".").pop().toLowerCase();
//    const validTypes = ["jpeg", "jpg", "png", "gif"];
//    if (validTypes.includes(fileExtension)) {
//        if (file) {
//            var src = URL.createObjectURL(event.target.files[0]);
//            const reader = new FileReader();
//            reader.onload = function (e) {
//                const base64String = e.target.result;
//                ImageName.value = fileName;
//                Imagebase64.value = base64String;
//            };
//            reader.readAsDataURL(file);
//            preview.src = src;
//            preview.style.display = "block";

//        }
//    } else {
//        alert("Please select a valid image file (jpeg, jpg, png, gif)");
//        ImageEmpty();
//    }


//    function ImageEmpty() {
//        fileInput.value = '';
//        ImageName.value = "";
//        Imagebase64.value = "";
//        preview.style.display = "none";
//    }
//});