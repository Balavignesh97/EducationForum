(function () {
    $('#SubjectChoiseOfClassRow').hide();
    BindGradeDD();
    BindClassTypeDD();
})();

function BindGradeDD() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetGrades',
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].gradeID + '" class="option">' + response[i].grade + '</li>';
            }
            $("#ClassDD").html(DDOptions);
        },
        async: true
    });

}
$(document).on('click', '#ClassDD .option', function () {
    $.ajax({
        type: 'POST',
        url: '/Home/GetSubjects',
        data: { gradeID: $('#ClassDD .option.selected').data('value') },
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].subjectID + '" class="option">' + response[i].subjectName + '</li>';
            }
            $("#SubjectDD").html(DDOptions);
            $('#SubjectChoiseOfClassRow').show();
        },
        async: true
    });
});
function BindClassTypeDD() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetClassTypes',
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].classTypeID + '" class="option">' + response[i].classType + '</li>';
            }
            $("#ChoiseOfClassDD").html(DDOptions);
        },
        async: true
    });

}
document.addEventListener('DOMContentLoaded', function () {

    document.querySelector('.subject').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.subject .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#subject').val(selectedValue);
        }
    });

    document.querySelector('.choiceofclass').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.choiceofclass .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#choiceofclass').val(selectedValue);
        }
    });

    document.querySelector('.Class').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.Class .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#Class').val(selectedValue);
        }
    });
});


$('#contactsubmit').click(async function (event) {
    console.log('click')
    //var validStatus = await Validatecheck();
    //console.log(validStatus)
    //if (validStatus) {
        var datastring = $(this).closest('form').serialize();
        var url = '/Home/SubmitEnquiry';

        Callservice(datastring, url);
    //}
    //else {
    //    event.preventDefault();
    //}
});

$('#fullname, #email, #Mobile, #message').on('input', function () {
    
});

async function Validatecheck() {
    var fullname = $('#fullname');
    var email = $('#email');
    var Mobile = $('#Mobile');
    var Class = $('#Class').val();
    var subject = $('#subject').val();
    var choiceofclass = $('#choiceofclass').val();
    var Class1 = $('.Class');
    var subject1 = $('.subject');
    var choiceofclass1 = $('.choiceofclass');
    var message = $('#message');

    var isValidEmail = validateEmail(email.val());
    var isValidPhone = validatePhone(Mobile.val());

    fullname.toggleClass('error', !fullname.val());
    email.toggleClass('error', !isValidEmail);
    Mobile.toggleClass('error', !isValidPhone);
    message.toggleClass('error', !message.val());
    Class1.toggleClass('error', !Class);
    subject1.toggleClass('error', !subject);
    choiceofclass1.toggleClass('error', !choiceofclass);

    fullname.toggleClass('noneerror', !!fullname.val());
    email.toggleClass('noneerror', isValidEmail);
    Mobile.toggleClass('noneerror', isValidPhone);
    message.toggleClass('noneerror', !!message.val());
    Class1.toggleClass('noneerror', !!Class);
    subject1.toggleClass('noneerror', !!subject);
    choiceofclass1.toggleClass('noneerror', !!choiceofclass);


    return fullname.val() && isValidEmail && isValidPhone && message.val() && Class && subject && choiceofclass;
}

function validateEmail(email) {
    var emailPattern = /^[a-zA-Z0-9._-]+@@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
}

function validatePhone(phone) {
    var phonePattern = /^[6-9]{1}[0-9]{9}$/;
    return phonePattern.test(phone);
}