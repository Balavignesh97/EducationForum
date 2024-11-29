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

                if (prop['isGroupClassAvailable']) {
                    GroupClass = '<li><i class="fa-light fa-user-group"></i><span>Group Class : </span>Max ' + prop['maxStudentForGroupClass'] + ' Students</li>';
                }
                if (prop['isIndividualClassAvailable']) {
                    IndividualClasses = '<li><i class="fa-light fa-user"></i><span>Individual class available </span></li>';
                }
                if (prop['gradeFrom'] !== '' && prop['gradeFrom'] !== undefined && prop['gradeTo'] !== '' && prop['gradeTo'] !== undefined) {
                    Grade = '<li><i class="fa-light fa-file"></i><span>Grade : </span>' + prop['gradeFrom'] + 'th - ' + prop['gradeTo'] + 'th</li>';
                } else if (prop['gradeFrom'] !== '' && prop['gradeFrom'] !== undefined) {
                    Grade = '<li><i class="fa-light fa-file"></i><span>Grade : </span>' + prop['gradeFrom'] + 'th</li>';
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
                                    ` + Grade + GroupClass + IndividualClasses + `
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