var MsgStyle = [];
//透明黑色弹窗
MsgStyle[0] =
	`background-color:rgba(0,0,0,.6);
color:#fff;
border:none;
text-align:center;
z-index: 19999;
padding:3px;
min-width:100px;
max-width:200px;
margin:auto;
top: 50%;
left: 50%;
position:absolute;
border-radius: 8px;`;

function msg(message,time,callback) {
	message = message || '';
	let MsgHtml = `<div style="${MsgStyle[0]}" id="HFrameAlertMsg">${message}</div>`;
	$('body').append(MsgHtml);
	ShowGradually(document.getElementById("HFrameAlertMsg"), time,callback);
}
//渐显
function ShowGradually(obj, time, callback) {
	obj.style.opacity = 0;//隐藏元素
	let itemo = 0; //基数
	let frame = 100; //倍数
	//显示
	let t = setInterval(function() {
		itemo += 1;
		obj.style.opacity = itemo / frame;
		if (itemo >= frame) {
			//显示完成
			clearInterval(t);
			//隐藏
			setTimeout(function() {//延迟时间
				//隐藏
				let s=setInterval(function() {
					itemo -= 1;
					obj.style.opacity = itemo / frame;
					if (itemo <= 0) {
						clearInterval(s);
					}
				}, 1);
			}, time);
			//回调
			if (callback) {
				callback();
			}
		}
	}, 1);
}
define(function(require, exports) {
	exports.msg = msg;
});
