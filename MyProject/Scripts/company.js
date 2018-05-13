function releaseJob() {
    var salaryUpper = $('#SalaryUpper').val();
    var salaryLower = $('#SalaryLower').val();
    if (salaryUpper < salaryLower) {
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



