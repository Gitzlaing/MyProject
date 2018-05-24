function releaseJob() {
    var salaryUpper = $('#SalaryUpper').val();
    var salaryLower = $('#SalaryLower').val();
    if (parseInt(salaryUpper) < parseInt(salaryLower)) {
        $('#salaryMsg').html("工资范围错误");
        return false;
    }
    return true;
}

/////删除职位信息,pageIndex当前页码
//function deleteJob(jobId,pageIndex) {
//    if (!confirm('确定删除吗？')) {
//        return false;
//    }
//    var postData = {
//        jobId: jobId,
//        pageIndex: pageIndex
//    }
//}

//拒绝简历方法
function refuseResume(uid, jobId) {
    if (!confirm('确认拒绝该简历吗？')) {
        return false;
    }

    $.post("/Company/Resume/RefuseResume", { "uid": uid, "jobId": jobId }, function (msg) {
        if (msg.Status == 1) {
            $('#divError').show();
        }
        else {
            location.reload();
        }
    }, 'json');
}



