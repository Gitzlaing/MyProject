/// <reference path="jquery.signalr-2.1.2.min.js" />


function applyJob(uid, companyId, jobId, btn) {
    if (uid=="0") {
        alert('请登录账号');
        location.href = "/Login";
        return ;
    }
    if (btn.val() == '已申请该职位') {
        return;
    }
    var postData = {
        companyId: companyId,
        uId:uid,
        jobId: jobId
    }
    $.post('/Jobs/ApplyJob', postData, function (data) {
        if (data.Status == 0) {
            btn.val("已申请该职位");
            btn.css("background-color", "forestgreen");
        }
        else {
            alert(data.Msg);
        }
    }, 'json')
}


//function sendResumeToCompany() {
//    var conn = $.connection.resume;
//    conn.sendResume = function () { };
//}