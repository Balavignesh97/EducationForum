(function () {
    $('#ClassChoiseOfClassRow').hide();
    $('#InstructiveLanguageDIV').hide();
    $('#BoardsDIV').hide();
    BindClassTypeDD();
    //BindInstructiveLanguageDD();
    BindSubject();
})();
var subjecttype=''
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
            $('#ClassChoiseOfClassRow').show();
        },
        async: true
    });

}
function BindSubject() {
    $.ajax({
        type: 'POST',
        url: '/Home/GetSubjects',
        //data: { gradeID: $('#ClassDD .option.selected').data('value') },
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].subjectID + '" class="option">' + response[i].subjectName + '</li>';
            }
            $("#SubjectDD").html(DDOptions);
        },
        async: true
    });
}
$(document).on('click', '#SubjectDD .option', function () {
    $.ajax({
        type: 'POST',
        url: '/Home/GetBaseForSubject',
        data: { SubjectID: $('#SubjectDD .option.selected').data('value') },
        dataType: 'json',
        success: function (response) {
            subjecttype = response.toLowerCase();
            if (response.toLowerCase() === "classbased") {
                $('#Topics').hide();
                $('#Classes').show();
                BindGradeDD();
                $('#InstructiveLanguageDIV').show();
                BindInstructiveLanguageDD();
                $('#BoardsDIV').show();
                BindBoards();
            }
            else if (response.toLowerCase() === "topicbased") {
                $('#Classes').hide();
                $('#Topics').show();
                $('#InstructiveLanguageDIV').hide();
                $('#BoardsDIV').hide();
                BindTopics();
            }
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
function BindInstructiveLanguageDD() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetInstructiveLanguage',
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].instructiveLanguageID + '" class="option">' + response[i].language + '</li>';
            }
            $("#InstructiveLanguageDD").html(DDOptions);
        },
        async: true
    });

}
function BindTopics() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetTopics',
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].topicsID + '" class="option">' + response[i].topics + '</li>';
            }
            $("#TopicsDD").html(DDOptions);
            $('#ClassChoiseOfClassRow').show();
        },
        async: true
    });

}
function BindBoards() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetBoards',
        dataType: 'json',
        success: function (response) {
            var DDOptions = ''
            for (var i = 0; i < response.length; i++) {
                DDOptions += '<li data-value="' + response[i].boardID + '" class="option">' + response[i].board + '</li>';
            }
            $("#BoardDD").html(DDOptions);
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
            Validatecheck('subject');
        }
    });

    document.querySelector('.choiceofclass').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.choiceofclass .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#choiceofclass').val(selectedValue);
            Validatecheck('choiceofclass');
        }
    });

    document.querySelector('.Class').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.Class .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#Class').val(selectedValue);
            Validatecheck('Class');
        }
    });
    document.querySelector('.Topic').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.Topic .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#Topic').val(selectedValue);
            Validatecheck('Topic');
        }
    });
    document.querySelector('.Board').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.Board .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#Board').val(selectedValue);
            Validatecheck('Board');
        }
    });

    document.querySelector('.instructiveLanguage').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('option')) {
            const options = document.querySelectorAll('.instructiveLanguage .option');
            options.forEach(option => option.classList.remove('selected', 'focus'));
            event.target.classList.add('selected', 'focus');

            const selectedValue = event.target.getAttribute('data-value');
            $('#instructiveLanguage').val(selectedValue);
            Validatecheck('instructiveLanguage');
        }
    });
});


$('#smspin').removeClass('show').addClass('hide');
$('#contactsubmit').click(async function (event) {
    //console.log('click')
    var validStatus = await Validatecheck();
    console.log(validStatus)
    if (validStatus) {
        $('#smspin').removeClass('hide').addClass('show');
        var datastring = $(this).closest('form').serialize();
        var url = '/Home/SubmitEnquiry';

        Callservice(datastring, url);
    }
    else {
        event.preventDefault();
    }
});

$('#fullname, #email, #Mobile, #message').on('input', function (event) {
    //console.log(event.currentTarget.id);
    var Id = event.currentTarget.id;
    Validatecheck(Id);
});

async function Validatecheck(Id = null) {
    if (Id) {
        if (Id === 'fullname') {
            var fullname = $('#fullname');
            fullname.toggleClass('error', !fullname.val());
            fullname.toggleClass('noneerror', !!fullname.val());
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
        else if (Id === 'message') {
            var message = $('#message');
            message.toggleClass('error', !message.val());
            message.toggleClass('noneerror', !!message.val());
        }
        else if (Id === 'Class') {
            var Class = $('#Class').val();
            var Class1 = $('.Class');
            Class1.toggleClass('error', !Class);
            Class1.toggleClass('noneerror', !!Class);
        }
        else if (Id === 'Topic') {
            var Class = $('#Topic').val();
            var Class1 = $('.Topic');
            Class1.toggleClass('error', !Class);
            Class1.toggleClass('noneerror', !!Class);
        }
        else if (Id === 'Board') {
            var Class = $('#Board').val();
            var Class1 = $('.Board');
            Class1.toggleClass('error', !Class);
            Class1.toggleClass('noneerror', !!Class);
        }
        else if (Id === 'subject') {
            var subject = $('#subject').val();
            var subject1 = $('.subject');
            subject1.toggleClass('error', !subject);
            subject1.toggleClass('noneerror', !!subject);
        }
        else if (Id === 'choiceofclass') {
            var choiceofclass = $('#choiceofclass').val();
            var choiceofclass1 = $('.choiceofclass');
            choiceofclass1.toggleClass('error', !choiceofclass);
            choiceofclass1.toggleClass('noneerror', !!choiceofclass);
        }
        else if (Id === 'instructiveLanguage') {
            var instructiveLanguage = $('#instructiveLanguage').val();
            var instructiveLanguage1 = $('.instructiveLanguage');
            instructiveLanguage1.toggleClass('error', !instructiveLanguage);
            instructiveLanguage1.toggleClass('noneerror', !!instructiveLanguage);
        }
        return false;
    }
    var fullname = $('#fullname');
    var email = $('#email');
    var Mobile = $('#Mobile');
    var Class = $('#Class').val();
    var Topic = $('#Topic').val();
    var Board = $('#Board').val();
    var subject = $('#subject').val();
    var choiceofclass = $('#choiceofclass').val();
    var instructiveLanguage = $('#instructiveLanguage').val();
    var Class1 = $('.Class');
    var Topic1 = $('.Topic');
    var Board1 = $('.Board');
    var subject1 = $('.subject');
    var choiceofclass1 = $('.choiceofclass');
    var instructiveLanguage1 = $('.instructiveLanguage');
    var message = $('#message');

    var isValidEmail = validateEmail(email.val());
    var isValidPhone = validatePhone(Mobile.val());

    fullname.toggleClass('error', !fullname.val());
    email.toggleClass('error', !isValidEmail);
    Mobile.toggleClass('error', !isValidPhone);
    message.toggleClass('error', !message.val());
    Class1.toggleClass('error', !Class);
    Topic1.toggleClass('error', !Topic);
    Board1.toggleClass('error', !Board);
    subject1.toggleClass('error', !subject);
    choiceofclass1.toggleClass('error', !choiceofclass);
    instructiveLanguage1.toggleClass('error', !instructiveLanguage);

    fullname.toggleClass('noneerror', !!fullname.val());
    email.toggleClass('noneerror', isValidEmail);
    Mobile.toggleClass('noneerror', isValidPhone);
    message.toggleClass('noneerror', !!message.val());
    Class1.toggleClass('noneerror', !!Class);
    Topic1.toggleClass('noneerror', !!Topic);
    Board1.toggleClass('noneerror', !!Board);
    subject1.toggleClass('noneerror', !!subject);
    choiceofclass1.toggleClass('noneerror', !!choiceofclass);
    instructiveLanguage1.toggleClass('noneerror', !!instructiveLanguage);

    if (subjecttype ==='classbased') {
        return fullname.val() && isValidEmail && isValidPhone && message.val() && subject && choiceofclass && instructiveLanguage && Class && Board;
    }
    else if (subjecttype ==='topicbased') {
        return fullname.val() && isValidEmail && isValidPhone && message.val() && subject && choiceofclass && Topic;
    }
    return fullname.val() && isValidEmail && isValidPhone && message.val() && subject && choiceofclass && instructiveLanguage;
}

function validateEmail(email) {
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
}

function validatePhone(phone) {
    var phonePattern = /^[6-9]{1}[0-9]{9}$/;
    return phonePattern.test(phone);
}