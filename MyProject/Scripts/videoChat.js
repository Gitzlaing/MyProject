//获取视频流代码块
var canvas = document.getElementById("canvas"), //取得canvas实例
    context = canvas.getContext("2d"), //取得2D画板
    video = document.getElementById("video"),//取得视频标签
    videoObj = { "video": true }, //设置获取视频
    errBack = function (error) {
        console.log("Video capture error: ", error.code);
    }; //设置错误回发信息

if (navigator.getUserMedia) { // 标准获取视频语法
    navigator.getUserMedia(videoObj, function (stream) {
        video.src = stream;
        video.play();
    }, errBack);
} else if (navigator.webkitGetUserMedia) { // Webkit内核语法
    navigator.webkitGetUserMedia(videoObj, function (stream) {
        video.src = window.webkitURL.createObjectURL(stream);
        var data = window.webkitURL.createObjectURL(stream);
        video.play();
    }, errBack);
}
else if (navigator.mozGetUserMedia) { // 火狐内核语法
    navigator.mozGetUserMedia(videoObj, function (stream) {
        video.src = window.URL.createObjectURL(stream);
        video.play();
    }, errBack);
}
//执行定时程序
window.setInterval(function () {
    context.drawImage(video, 0, 0, 320, 240);
    var type = 'jpg'
    var imgData = canvas.toDataURL(type);
    　　　　　　　　　　　　//使用localResizeIMG3压缩图像.
    lrz(imgData, {
        quality: 0.1,      //压缩率             
        done: function (results) {
            var data = results;
            chat.server.sendImage(data.base64);
            //var reader = new FileReader();
            // $("#canvas2").attr("src", data.base64);
        }
    });
},20)







// 这里是注册集线器调用的方法,和1.0不同的是需要chat.client后注册,1.0则不需要
var chat = $.connection.getMessage;
chat.client.broadcastMessage = function (name) {
    // HTML编码的显示名称和消息。
    var encodedMsg = $('<div />').text(name).html();
    // 将消息添加到该页。
    $('#messsagebox').append('<li>' + encodedMsg + '</li>');
};

//获取图片数据,并实时显示
chat.client.showimage = function (data) {
    if ($("#" + data.id).length <= 0) {
        var html = '<div style="float: left; border: double" id="div' + data.id + '">\
                                <img id="'+ data.id + '" width="320" height="240">\
                                <br />\
                                <span>用户'+ data.id + '</span>\
                                </div>'
        $("#contextdiv").append(html)
    }
    $("#" + data.id).attr("src", data.data);
}
// 获取用户名称。
$('#username').html(prompt('请输入您的名称:', ''));
// 设置初始焦点到消息输入框。
$('#message').focus();

// 启动连接,这里和1.0也有区别
$.connection.hub.start().done(function () {
    $('#send').click(function () {
        var message = $('#username').html() + ":" + $('#message').val()
        // 这里是调用服务器的方法,同样,首字母小写
        chat.server.sendMessage(message);
        // 清空输入框的文字并给焦点.
        $('#message').val('').focus();
    });
});