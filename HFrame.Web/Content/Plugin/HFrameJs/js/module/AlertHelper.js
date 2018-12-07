var MsgStyle = [];
//透明黑色弹窗
MsgStyle[0] =
	`background-color:rgba(0,0,0,.6);
	color:#fff;
	border:none;
	text-align:center;
	z-index: 19999;
	padding:10px;
	min-width:100px;
	max-width:200px;
	margin:auto;
	top: 50%;
	left: 48%;
	position:absolute;
	border-radius: 8px;`;

//弹窗样式
MsgStyle[1] =
	`padding: 10px;
	position: absolute;
	background: white;
	width: 400px;
	min-height: 200px;
	margin: auto;
	box-shadow: 0px 10px 20px 0px rgba(0,0,0,0.4);
	box-sizing: border-box;
	z-index: 19999;
	top: 50%;
	left: 40%;`;

//渐显
function ShowGradually(obj, time, callback) {
	obj.style.opacity = 0; //隐藏元素
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
			setTimeout(function() { //延迟时间
				//隐藏
				let s = setInterval(function() {
					itemo -= 1;
					obj.style.opacity = itemo / frame;
					if (itemo <= 0) {
						clearInterval(s);
						obj.parentNode.removeChild(obj);
						//回调
						if (callback) {
							callback();
						}
					}
				}, 1);
			}, time);
		}
	}, 1);
}
//提示
function msg(message = '', time = 1000, callback) {
	message = message || '';
	let MsgHtml = `<div style="${MsgStyle[0]}" id="HFrameMsg">${message}</div>`;
	$('body').append(MsgHtml);
	ShowGradually(document.getElementById("HFrameMsg"), time, callback);
}
//弹窗
function alert(title = "提示信息", content = "确认操作", btn = ["确认", "取消"], btnclick) {
	let AlertHtml =
		`<div style="${MsgStyle[1]}" id="HFrameAlert">
			<div style="margin: 10px;font-weight: bold;font-size: 1.2em;">${title}</div>
			<div style="margin: 10px;">${content}</div>
			<div style="width: calc(100% - 20px);position: absolute;bottom: 0px;">
				${btn.map((m,index)=>
					`<div class="HFrameAlertBtn${index}" style="margin: 10px;font-weight: bold;cursor: pointer;text-align: center;float: right;text-transform: uppercase;padding: 10px;">${m}</div>`
					).join('')
				}
			</div>
		</div>`;
	$('body').append(AlertHtml);
	btncallback(btnclick);
}
//弹窗关闭事件
function closealert() {
	let Item = document.getElementById("HFrameAlert");
	Item.parentNode.removeChild(Item);
}
//弹窗回调
function btncallback(btnclick) {
	document.querySelectorAll("[class^=HFrameAlertBtn]").forEach((m,index)=>{
		m.onclick=function(){
			if(btnclick){
				if(btnclick[index]){
					btnclick[index]();
				}
			}
			closealert();
		}
	});
}
define(function(require, exports) {
	exports.msg = msg;
	exports.alert = alert;
});
