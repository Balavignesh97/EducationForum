(function () {
    BindCourseDetails();
})();

function BindCourseDetails() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetTemplateCourseDetails',
        dataType: 'json',
        success: function (response) {
            $('#CoursesData').empty();
            response.forEach(function (prop) {
                var Grade = '';
                var GroupClass = '';
                var IndividualClasses = '';
                var Topics = '';
                var OtherDescription = '';
                console.log(prop)

                if (prop['isIndividualClassAvailable']) {
                    if (prop['individualClassDesc'] === undefined || prop['individualClassDesc'] === '' || prop['individualClassDesc'] === null) {
                        IndividualClasses = '<li><i class="fa-light fa-user"></i><span><strong>Individual class available </strong></span></li>';
                    }
                    else {
                        IndividualClasses = '<li><i class="fa-light fa-user"></i><span><strong>Individual class : </strong><span>' + prop['individualClassDesc'] + ' </span></li>';
                    }
                }
                if (prop['isGroupClassAvailable']) {
                    if (prop['groupClassDesc'] === undefined || prop['groupClassDesc'] === '' || prop['groupClassDesc'] === null) {
                        GroupClass = '<li><i class="fa-light fa-user-group"></i><span><strong>Group Class : </strong><span>Max ' + prop['maxStudentForGroupClass'] + ' Students</span></span></li>';
                    }
                    else {
                        GroupClass = '<li><i class="fa-light fa-user-group"></i><span><strong>Group Class : </strong><span>' + prop['groupClassDesc'] + '</span></span></li>';
                    }
                }
                if (prop['isTopicsAvilable'] && prop['topicsDesc'] !== undefined && prop['topicsDesc'] !== '' && prop['topicsDesc'] !== null) {
                    if (prop['isTopicATemplate']) {
                        Topics = '<li><i class="fa-light fa-list-alt"></i><span><strong>Topics : </strong>' + prop['topicsDesc'] + '</span></li>';
                    }
                    else {
                        Topics = '<li><i class="fa-light fa-list-alt"></i><span><strong>Topics : </strong><span>' + prop['topicsDesc'] + '</span></span></li>';
                    }
                    
                }
                if (prop['gradeFrom'] !== null && prop['gradeFrom'] !== '' && prop['gradeFrom'] !== undefined && prop['gradeTo'] !== null && prop['gradeTo'] !== '' && prop['gradeTo'] !== undefined) {
                    Grade = '<li><i class="fa-light fa-file"></i><span><strong>Grade : </strong><span>' + prop['gradeFrom'] + 'th - ' + prop['gradeTo'] + 'th</span></span></li>';
                } else if (prop['gradeFrom'] !== null && prop['gradeFrom'] !== '' && prop['gradeFrom'] !== undefined) {
                    Grade = '<li><i class="fa-light fa-file"></i><span><strong>Grade : </strong><span>' + prop['gradeFrom'] + 'th</span></span></li>';
                }
                if (prop['otherDesc'] && prop['otherDesc'] !== undefined && prop['otherDesc'] !== '' && prop['otherDesc'] !== null) {
                    OtherDescription = '<li style="font-size: small;">' + prop['otherDesc'] + '</li>';
                }
                var Wrap =
                    `<div class="col-xl-4 col-lg-6 col-md-6">
                        <div class="course-item wow fade-in-bottom" data-wow-delay="200ms">
                            <div class="course-thumb-wrap">
                                <div class="course-thumb">
                                    <img src="/assets/img/Courses/` + prop['imagePath'] + `" alt="` + prop['courseHeading'] + `" loading="lazy">
                                </div>
                            </div>
                            <div class="course-content">
                                <h3 class="title">
                                    <a href="/Home/Contact?subjectId=` + prop['subjectID'] + `">` + prop['courseHeading'] + `</a>
                                </h3>
                                <ul class="course-list">
                                    ` + Grade + IndividualClasses + GroupClass + Topics + OtherDescription + `
                                </ul>
                            </div>
                            <div class="bottom-content">
                                <a href="/Home/Contact?subjectId=` + prop['subjectID'] + `" class="course-btn">Register Here</a>
                            </div>
                        </div>
                    </div>`;

                $('#CoursesData').append(Wrap);
            });

        },
        async: true
    });

}