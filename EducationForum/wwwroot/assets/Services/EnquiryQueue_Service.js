// $('#LoaderTable').show();
// $('#myTable').hide();
$('#IsRequestCallBack').on('change', function () {
    if (this.checked) {
        $('#divRequestCallBackdate').removeClass('texthide').addClass('textshow');
    }
    else {
        $('#divRequestCallBackdate').addClass('texthide').removeClass('textshow');
        $('#RequestCallBackDate').val('');
    }
});

$('#EnquiryResponeSubmitSpinner').hide();
var totalCount = 0;
var CurrentpageIndex = 1;
var Searchstartdate = '';
var SearchEnddate = '';
var DashboardDatatable = $('#myTable').DataTable({
    "scrollY": '400px',
    "scrollX": false,
    "scrollCollapse": true,
    "paging": true,
    "order": [],
    "layout": {
        "topStart": null,
        "topEnd": null,
        "bottomStart": null,
        "bottomEnd": null,
    },
    "columnDefs": [
        { "target": 0, "visible": false, },
        { "targets": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10], "searchable": false, "orderable": false }
    ],
    "columns": [
        { "data": "enquiryID", "name": "EnquiryID", "autoWidth": true },
        { "data": "name", "name": "Name", "autoWidth": true },
        { "data": "email", "name": "Email", "autoWidth": true },
        { "data": "phone", "name": "Phone", "autoWidth": true },
        { "data": "classType", "name": "ClassType", "autoWidth": true },
        {
            "data": "dateAdded", "name": "DateAdded", "autoWidth": true,
            "render": function (data, type, full, meta) {
                return moment(data).format('DD/MM/YYYY');

            }
        },
        {
            "data": "isResponded", "name": "IsResponded", "autoWidth": false,
            "render": function (data, type, full, meta) {
                if (data === true) {
                    return '<div class="btn btn-sm btn-outline-success"><i class="fa-solid fa-headset"></i><span class="custommargin">Yes</span></div>';
                }
                else if (data === false) {
                    return '<div class="btn btn-sm btn-outline-danger"><i class="fa-solid fa-headset"></i><span class="custommargin">No</span></div>';
                }
                return '';

            }
        },
        {
            "data": "isOnHold", "name": "IsOnHold", "autoWidth": true,
            "render": function (data, type, full, meta) {
                if (data === true) {
                    return '<div class="btn btn-sm btn-outline-success"><i class="fa-regular fa-circle-pause"></i><span class="custommargin">Yes</span></div>';
                }
                else if (data === false) {
                    return '<div class="btn btn-sm btn-outline-danger"><i class="fa-regular fa-circle-pause"></i><span class="custommargin">No</span></div>';
                }
                return '';

            }
        },
        {
            "data": "isRequestCallBack", "name": "IsRequestCallBack", "autoWidth": true,
            "render": function (data, type, full, meta) {
                if (data === true) {
                    return '<div class="btn btn-sm btn-outline-success"><i class="fa-solid fa-phone"></i> <span class="custommargin">Yes</span></div>';
                }
                else if (data === false) {
                    return '<div class="btn btn-sm btn-outline-danger"><i class="fa-solid fa-phone"></i><span class="custommargin">No</span></div>';
                }
                return '';

            }
        },
        {
            "data": "isCallAttemptFailed", "name": "IsCallAttemptFailed", "autoWidth": true,
            "render": function (data, type, full, meta) {
                if (data === true) {
                    return '<div class="btn btn-sm btn-outline-success"><i class="fa-solid fa-ban"></i> <span class="custommargin">Yes</span> </div>';
                }
                else if (data === false) {
                    return '<div class="btn btn-sm btn-outline-danger"><i class="fa-solid fa-ban"></i><span class="custommargin">No</span> </div>';
                }
                return '';

            }
        },
        {
            "render": function (data, type, full, meta) {
                return '<span onclick="EditEnquiry(' + full["enquiryID"] + ')" style="cursor: pointer;"><i class="fas fa-edit"></i></span>';
            }
            // "targets": 9
        }
    ],
    "data": [], // Initially, no data is bound
    "initComplete": function () {

    }
});
const today = new Date();
$(function () {
    $('#OrderedDate').daterangepicker({
        opens: 'center',
        autoUpdateInput: false,
        showDropdowns: true,
        maxDate: today,
        drops: 'up',
    });
    // , function (start, end, label) {
    //     //console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
    //     Searchstartdate = start.format('YYYY-MM-DD');
    //     SearchEnddate = end.format('YYYY-MM-DD');
    // });
});
$('#OrderedDate').on('apply.daterangepicker', function (ev, picker) {
    Searchstartdate = picker.startDate.format('DD/MM/YYYY');
    SearchEnddate = picker.endDate.format('DD/MM/YYYY');
    $(this).val(picker.startDate.format('DD/MM/YYYY') + ' - ' + picker.endDate.format('DD/MM/YYYY'));
});

$('#OrderedDate').on('cancel.daterangepicker', function (ev, picker) {
    Searchstartdate = '';
    SearchEnddate = '';
    $(this).val('');
});
$(document).ready(function () {

    DataTableBindData(1)


});
function CustomPagination(totalCount, currentPage) {
    var totalPages = Math.ceil(totalCount / 10);
    var pagination = '';

    if (currentPage > 1) {
        pagination += '<li class="page-item"><a class="page-link" onclick="PaginationClick(' + (currentPage - 1) + ')">Previous</a></li>';
    }
    else {
        pagination += '<li class="page-item"><a class="page-link" >Previous</a></li>';
    }
    var i = 1;
    if (totalPages > 2) {
        if (currentPage === totalPages && totalPages > 1) {
            i = currentPage - 2;
        }
        else if (currentPage === 1) {
            totalPages = 3
        }
        else {
            i = currentPage - 1;
            totalPages = currentPage + 1
        }
    }

    for (i; i <= totalPages; i++) {
        pagination += '<li class="page-item ' + (i === currentPage ? 'active' : '') + '">';
        pagination += '<a class="page-link" href="#" onclick="PaginationClick(' + i + ')">' + i + '</a>';
        pagination += '</li>';
    }

    if (currentPage < totalPages) {
        pagination += '<li class="page-item"><a class="page-link" onclick="PaginationClick(' + (currentPage + 1) + ')">Next</a></li>';
    }
    else {
        pagination += '<li class="page-item"><a class="page-link">Next</a></li>';
    }

    $("#CustomPagination").html(pagination);
}
function BindDatatableInfo(TotalCount, pageno) {
    var startcount = pageno >= 1 ? ((pageno - 1) + '1') : '0';
    var endcount = pageno + '0';
    let toolbar = `<b>Showing ${startcount} to ${endcount} of ${TotalCount} entries</b>`;
    // $('.dt-info').html(toolbar);
    $('#table-info').html(toolbar);
}
// function OnSortclick() {
//     var ordering = DashboardDatatable.order();
//     if (ordering.length === 0) return;
//     let [columnid, sortorder] = ordering[0]
//     var sortcolumn = columnid == 1 ? 'Name' : columnid == 2 ? 'Email' : columnid == 3 ? 'Phone' : '';
//     //console.log('Table ordering changed: ' + JSON.stringify(ordering));
//     DataTableBindData(1, '', '', '', sortcolumn, (sortorder == 'asc' ? 'ASC' : sortorder == 'desc' ? 'DESC':'ASC'));
// }

// function handlePageClick(index) {
//     let pageCount = Math.ceil(totalCount / 10)
//     if (index === 'first' || index === 'previous' || index === 'next' || index === 'last') {
//         // Get all buttons in the pagination
//         const buttons = document.querySelectorAll('.pgbtn');
//         // Find the previously active button (if any)
//         const previousActiveButton = document.querySelector('.dt-paging-button.current.pgbtn');

//         // if (previousActiveButton) {
//         //     previousActiveButton.classList.remove('current');
//         //     previousActiveButton.removeAttribute('aria-current');
//         // }
//         var NextButton = '';
//         if (index === 'next') {
//             NextButton = buttons[parseInt(previousActiveButton.innerText)]
//             if (parseInt(previousActiveButton.innerText) === totalCount) return;
//         }
//         else if (index === 'previous') {
//             NextButton = buttons[(parseInt(previousActiveButton.innerText) - 2)]
//             if (parseInt(previousActiveButton.innerText) === 1) return;
//         }
//         else if (index === 'first') {
//             NextButton = buttons[0]
//             if (parseInt(previousActiveButton.innerText) === 1) return;
//         }
//         else if (index === 'last') {
//             NextButton = buttons[pageCount - 1]
//             if (parseInt(previousActiveButton.innerText) === totalCount) return;
//         }

//         // if (NextButton) {
//         //     NextButton.classList.add('current');
//         //     NextButton.setAttribute('aria-current', 'page');
//         // }
//         index = parseInt(NextButton.innerText)
//     }
//     index = index - 1;


//     const btnfirst = document.querySelector('.dt-paging-button.first');
//     const btnprevious = document.querySelector('.dt-paging-button.previous');
//     const btnnext = document.querySelector('.dt-paging-button.next');
//     const btnlast = document.querySelector('.dt-paging-button.last');
//     // Get all buttons in the pagination
//     const buttons = document.querySelectorAll('.pgbtn');

//     // Find the previously active button (if any)
//     const previousActiveButton = document.querySelector('.dt-paging-button.current.pgbtn');

//     // Remove the 'current' class from the previous active button (if it exists)
//     if (previousActiveButton) {
//         previousActiveButton.classList.remove('current');
//         previousActiveButton.removeAttribute('aria-current');
//     }

//     // Find the clicked button based on the index and add 'current' class
//     const clickedButton = buttons[index];
//     if (clickedButton) {
//         clickedButton.classList.add('current');
//         clickedButton.setAttribute('aria-current', 'page');
//     }

//     // Call any method to handle the page change (e.g., load data for the new page)
//     // Replace this with your data update logic
//     if (index === pageCount - 1) {
//         btnlast.classList.add('disabled');
//         btnlast.setAttribute('aria-disabled', 'true');
//         btnnext.classList.add('disabled');
//         btnnext.setAttribute('aria-disabled', 'true');

//         btnfirst.classList.remove('disabled');
//         btnfirst.removeAttribute('aria-disabled');
//         btnprevious.classList.remove('disabled');
//         btnprevious.removeAttribute('aria-disabled');
//     }
//     else if (index === 0) {
//         btnfirst.classList.add('disabled');
//         btnfirst.setAttribute('aria-disabled', 'true');
//         btnprevious.classList.add('disabled');
//         btnprevious.setAttribute('aria-disabled', 'true');

//         btnlast.classList.remove('disabled');
//         btnlast.removeAttribute('aria-disabled');
//         btnnext.classList.remove('disabled');
//         btnnext.removeAttribute('aria-disabled');
//     }
//     else {
//         btnfirst.classList.remove('disabled');
//         btnfirst.removeAttribute('aria-disabled');
//         btnprevious.classList.remove('disabled');
//         btnprevious.removeAttribute('aria-disabled');
//         btnlast.classList.remove('disabled');
//         btnlast.removeAttribute('aria-disabled');
//         btnnext.classList.remove('disabled');
//         btnnext.removeAttribute('aria-disabled');
//     }
//     // $('#myTable').DataTable().destroy();
//     DataTableBindData(index + 1)
// }
// function BindPagination(TotalCount) {

//     let pageCount = Math.ceil(TotalCount / 10)
//     // Create the layout container
//     // var layoutCell = $('<div>', {
//     //     class: 'dt-layout-cell dt-layout-end'
//     // });

//     // // Create the pagination container
//     // var pagingDiv = $('<div>', {
//     //     class: 'dt-paging'
//     // });

//     // Create the navigation element
//     var nav = $('<nav>', {
//         'aria-label': 'pagination'
//     });

//     // Create the fixed buttons (First, Previous)
//     var fixedButtonsStart = [
//         { class: 'dt-paging-button first', role: 'link', type: 'button', 'aria-controls': 'example', 'aria-label': 'First', 'data-dt-idx': 'first', text: '«', onclick: 'handlePageClick(\'first\')' },
//         { class: 'dt-paging-button previous', role: 'link', type: 'button', 'aria-controls': 'example', 'aria-label': 'Previous', 'data-dt-idx': 'previous', text: '‹', onclick: 'handlePageClick(\'previous\')' }
//     ];

//     // Add 'First' and 'Previous' buttons
//     fixedButtonsStart.forEach(function (button) {
//         var btn = $('<button>', button);
//         nav.append(btn);
//     });

//     // Dynamically create numbered buttons based on pageCount
//     for (var i = 1; i <= pageCount; i++) {
//         var buttonConfig = {
//             class: i === 1 ? 'dt-paging-button current pgbtn' : 'dt-paging-button pgbtn', // Highlight the first button as current
//             role: 'link',
//             type: 'button',
//             'aria-controls': 'example',
//             'data-dt-idx': i - 1,
//             text: i,
//             'aria-current': i === 1 ? 'page' : null, // Set 'aria-current' only for the current page
//             onclick: 'handlePageClick(' + i + ')'
//         };
//         var btn = $('<button>', buttonConfig);
//         nav.append(btn);
//     }

//     // Create the fixed buttons (Next, Last)
//     var fixedButtonsEnd = [
//         { class: 'dt-paging-button next', role: 'link', type: 'button', 'aria-controls': 'example', 'aria-label': 'Next', 'data-dt-idx': 'next', text: '›', onclick: 'handlePageClick(\'next\')' },
//         { class: 'dt-paging-button last', role: 'link', type: 'button', 'aria-controls': 'example', 'aria-label': 'Last', 'data-dt-idx': 'last', text: '»', onclick: 'handlePageClick(\'last\')' }
//     ];

//     // Add 'Next' and 'Last' buttons
//     fixedButtonsEnd.forEach(function (button) {
//         var btn = $('<button>', button);
//         nav.append(btn);
//     });

//     // Build the final structure
//     // pagingDiv.append(nav);
//     // layoutCell.append(pagingDiv);

//     //return layoutCell;
//     $('.dt-paging').empty()
//     $('.dt-paging').append(nav);
// }
//function eventFired(type) {
// var ordering = DashboardDatatable.order();
// if (ordering.length === 0) return;
// let [columnid, sortorder] = ordering[0]
// var sortcolumn = columnid == 1 ? 'Name' : columnid == 2 ? 'Email' : columnid == 3 ? 'Phone' : '';
// //console.log('Table ordering changed: ' + JSON.stringify(ordering));
// DataTableBindData(1, '', '', '', sortcolumn, (sortorder == 'asc' ? 'ASC' : 'DESC'));
//}
function PaginationClick(pageIndex) {
    CurrentpageIndex = pageIndex;
    DataTableBindData(CurrentpageIndex, $('#searchbyname').val(), $('#searchbyemail').val(), $('#searchbyphone').val(), '', '', Searchstartdate, SearchEnddate)
}

$(document).on("keydown", function (event) {
    if (event.key === "Enter" || event.keyCode === 13) {
        event.preventDefault();
        DataTableBindData(CurrentpageIndex, $('#searchbyname').val(), $('#searchbyemail').val(), $('#searchbyphone').val(), '', '', Searchstartdate, SearchEnddate)
    }
});
// $('.applyBtn .btn').on('click', function () {
//     DataTableBindData(CurrentpageIndex, $('#searchbyname').val(), $('#searchbyemail').val(), $('#searchbyphone').val(), '', '', Searchstartdate, SearchEnddate)
// })

function Closepopup() {
    $('#enquiryFormModal').modal('hide');
    $('#name').val('');
    $('#email').val('');
    $('#phone').val('');
    $('#City').val('');
    $('#State').val('');
    $('#enquirerNote').val('');
    $('#Subject').val('');
    $('#Grade').val('');
    $('#Topic').val('');
    $('#Board').val('');
    $('#classType').val('');
    $('#instructiveLanguage').val('');
    $('#IsResponded').prop('checked', false);
    $('#RespondeDate').html('');
    $('#IsResponded').prop('disabled', false);
    $('#IsOnHold').prop('checked', false);
    $('#IsRequestCallBack').prop('checked', false);
    $('#RequestCallBackDate').val('');
    $('#IsCallAttemptFailed').prop('checked', false);
    $('#responderNote').val('');
}
function DataTableBindData(pageno = 0, name = '', email = '', phone = '', sortcolumn = '', sortorder = '', searchstartdate = '', searchEnddate = '') {
    $('#LoaderTable').show();
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: 'POST',
            url: "/Admin/GetEnquiryQueueData",
            data:
            {
                page: parseInt(pageno),
                name: (name !== null && name !== undefined) ? name.trim() : '',
                email: (email !== null && email !== undefined) ? email.trim() : '',
                phone: (phone !== null && phone !== undefined) ? phone.trim() : '',
                startdate: searchstartdate,
                enddate: searchEnddate
                //orderby: sortcolumn,
                //sortOrder: sortorder
            },
            dataType: 'json',
            /* timeout: 1000,*/
            success: function (result) {
                // $('#LoaderTable').hide();
                // $('#myTable').show();
                totalCount = result.recordsTotal;
                if (result.recordsTotal > 0) {
                    DashboardDatatable.clear();
                    DashboardDatatable.rows.add(result.data);
                    DashboardDatatable.draw();
                    // BindPagination(totalCount);
                    CustomPagination(totalCount, pageno)
                    BindDatatableInfo(totalCount, pageno);
                }
                else {
                    DashboardDatatable.clear();
                    DashboardDatatable.rows.add([]);
                    DashboardDatatable.draw();
                    CustomPagination(0, 0)
                    BindDatatableInfo(0, 0);
                }
            },
            error: function (err) {
                //reject(err);
            }
        });
    });

}
async function GetEnquiryByID(EnquiryID) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: 'POST',
            url: "/Admin/GetEnquiryByID",
            data: {
                enquiryid: EnquiryID
            },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result.enquiryID > 0) {
                    $('#name').val(result.name);
                    $('#email').val(result.email);
                    $('#phone').val(result.phone);
                    $('#City').val(result.city);
                    $('#State').val(result.state);
                    $('#enquirerNote').val(result.enquirerNote);
                    if (result.studentEnquiryGradeSubjectMaps != null && result.studentEnquiryGradeSubjectMaps.length > 0 && result.studentEnquiryGradeSubjectMaps[0].subject != null) {
                        $('#Subject').val(result.studentEnquiryGradeSubjectMaps[0].subject.subjectName);
                    }
                    if (result.studentEnquiryGradeSubjectMaps != null && result.studentEnquiryGradeSubjectMaps.length > 0 && result.studentEnquiryGradeSubjectMaps[0].grade != null) {
                        $('#Grade').val(result.studentEnquiryGradeSubjectMaps[0].grade.grade);
                    }
                    if (result.classTypes != null) {
                        $('#classType').val(result.classTypes.classType);
                    }

                    if (result.instructiveLanguage != null) {
                        $('#instructiveLanguage').val(result.instructiveLanguage.language);
                    }
                    if (result.topic != null) {
                        $('#Topic').val(result.topic.topics + result.topic.description);
                    }
                    if (result.boards != null) {
                        $('#Board').val(result.boards.board);
                    }

                    $('#IsResponded').prop('checked', result.isResponded);
                    $('#RespondeDate').html(' (' + moment(result.respondedOn).format('DD/MM/YYYY HH:mm') + ')');
                    if (result.isResponded) {
                        $('#IsResponded').prop('disabled', true);
                    }
                    $('#IsOnHold').prop('checked', result.isOnHold);
                    // $('#IsOnHoldDate').html(result.);
                    $('#IsRequestCallBack').prop('checked', result.isRequestCallBack);
                    if ($('#IsRequestCallBack')[0].checked) {
                        $('#IsRequestCallBack').trigger('change');
                    }
                    $('#RequestCallBackDate').val(result.callBackDate);
                    $('#IsCallAttemptFailed').prop('checked', result.isCallAttemptFailed);
                    $('#responderNote').val(result.responderNote);
                    // $('#IsCallAttemptFailedDate').html(result.);
                    resolve(result);
                } else {
                    reject("No data found");
                }
            },
            error: function (err) {
                //reject(err);
            }
        });
    });
}

async function EditEnquiry(enquiryid) {
    try {
        $('#enquiryFormModal').modal('show');
        const result = await GetEnquiryByID(enquiryid);
    } catch (error) {
        console.error("Error fetching enquiry data:", error);
    }
}
$('#EnquiryResponeSubmit').click(function () {
    $('#EnquiryResponeSubmitSpinner').show();
    $("#EnquiryResponeSubmit").prop("disabled", true);
    var datastring = {
        Name: $('#name').val(), Email: $('#email').val(), Phone: $('#phone').val(), IsResponded: $('#IsResponded').prop('checked'), IsOnHold: $('#IsOnHold').prop('checked'),
        IsRequestCallBack: $('#IsRequestCallBack').prop('checked'), RequestCallBackDate: $('#RequestCallBackDate').val(), IsCallAttemptFailed: $('#IsCallAttemptFailed').prop('checked'), ResponderNote: $('#responderNote').val()
    };
    var object2 = '/Admin/SubmitEnquiryResponse';

    Callservice(datastring, object2);
});
// DashboardDatatable.on('order.dt', () => eventFired('Order'))