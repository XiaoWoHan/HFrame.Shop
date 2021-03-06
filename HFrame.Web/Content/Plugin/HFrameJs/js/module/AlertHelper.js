; !function (HFrame) {
	let MsgStyle = [];
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
	left: 50%;
	position:absolute;
	border-radius: 8px;
	transform: translate(-50%,-50%);`;

	//弹窗样式
	MsgStyle[1] =
		`padding: 10px;
	position: absolute;
	background: white;
	width: 340px;
	min-height: 200px;
	box-shadow: 0px 10px 20px 0px rgba(0,0,0,0.4);
	box-sizing: border-box;
	z-index: 19999;
	top: 50%;
	left: 50%;
	transform: translate(-50%,-50%);`;

	//渐显
	function ShowGradually(obj, time, callback) {
		obj.style.opacity = 0; //隐藏元素
		let itemo = 0; //基数
		let frame = 100; //倍数

		//显示
		let t = setInterval(function () {
			itemo += 1;
			obj.style.opacity = itemo / frame;
			if (itemo >= frame) {
				//显示完成
				clearInterval(t);
				//隐藏
				setTimeout(function () { //延迟时间
					//隐藏
					let s = setInterval(function () {
						itemo -= 1;
						obj.style.opacity = itemo / frame;
						if (itemo <= 0) {
							clearInterval(s);
							obj.remove();
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
	HFrame.msg = function (message = '', time = 1000, callback) {
		let _msg = document.createElement("div");
		_msg.innerHTML = `<div style="${MsgStyle[0]}" id="HFrameMsg">${message}</div>`;
		document.querySelector("body").appendChild(_msg);
		ShowGradually(_msg, time, callback);
	}
	//弹窗
	HFrame.alert = function ({
		title = '提示信息',
		content = '确认操作',
		btn = ['确认', '取消']
	} = {}, ...btnclick) {
		//构造页面元素
		let AlertHtml =
			`<div style="${MsgStyle[1]}" id="HFrameAlert">
			<div style="margin: 10px;font-weight: bold;font-size: 1.2em;">${title}</div>
			<div style="margin: 10px;">${content}</div>
			<div style="width: calc(100% - 20px);position: absolute;bottom: 0px;">
				${btn.map((m, index) =>
				`<div class="HFrameAlertBtn${index}" style="margin: 10px;font-weight: bold;cursor: pointer;text-align: center;float: right;text-transform: uppercase;padding: 10px;">${m}</div>`
			).join('')
			}
			</div>
		</div>`;

		let _Alert = document.createElement("div");
		_Alert.innerHTML = AlertHtml;
		//添加元素
		document.querySelector("body").appendChild(_Alert);
		//添加事件
		document.querySelectorAll("[class^=HFrameAlertBtn]").forEach((m, index) => {
			m.onclick = function () {
				if (btnclick[index]) {
					btnclick[index]();
				}
				HFrame.close(_Alert);
			}
		});
		return _Alert;
	}

	const LoadHtml = [];
	LoadHtml[0] =
		`<div id="HFrameLoad" style="position:absolute;left:0px;top:0px;background:rgba(0, 0, 0, 0.4);width:100%;height:100%;filter:alpha(opacity=60);opacity:0.6;z-Index:19999;">
			<div style="z-index: 19999;margin:auto;top: 50%;left: 50%;position:absolute;transform: translate(-50%,-50%);">
		  		<img alt="" src="data:image/gif;base64,R0lGODlhGQAZAJECAK7PTQBjpv///wAAACH/C05FVFNDQVBFMi4wAwEAAAAh/wtYTVAgRGF0YVhNUDw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNS1jMDE0IDc5LjE1MTQ4MSwgMjAxMy8wMy8xMy0xMjowOToxNSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDo5OTYyNTQ4Ni02ZGVkLTI2NDUtODEwMy1kN2M4ODE4OWMxMTQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6RUNGNUFGRUFGREFCMTFFM0FCNzVDRjQ1QzI4QjFBNjgiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6RUNGNUFGRTlGREFCMTFFM0FCNzVDRjQ1QzI4QjFBNjgiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjk5NjI1NDg2LTZkZWQtMjY0NS04MTAzLWQ3Yzg4MTg5YzExNCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo5OTYyNTQ4Ni02ZGVkLTI2NDUtODEwMy1kN2M4ODE4OWMxMTQiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz4B//79/Pv6+fj39vX08/Lx8O/u7ezr6uno5+bl5OPi4eDf3t3c29rZ2NfW1dTT0tHQz87NzMvKycjHxsXEw8LBwL++vby7urm4t7a1tLOysbCvrq2sq6qpqKempaSjoqGgn56dnJuamZiXlpWUk5KRkI+OjYyLiomIh4aFhIOCgYB/fn18e3p5eHd2dXRzcnFwb25tbGtqaWhnZmVkY2JhYF9eXVxbWllYV1ZVVFNSUVBPTk1MS0pJSEdGRURDQkFAPz49PDs6OTg3NjU0MzIxMC8uLSwrKikoJyYlJCMiISAfHh0cGxoZGBcWFRQTEhEQDw4NDAsKCQgHBgUEAwIBAAAh+QQFCgACACwAAAAAGQAZAAACTpSPqcu9AKMUodqLpAb0+rxFnWeBIUdixwmNqRm6JLzJ38raqsGiaUXT6EqO4uIHRAYQyiHw0GxCkc7l9FdlUqWGKPX64mbFXqzxjDYWAAAh+QQFCgACACwCAAIAFQAKAAACHYyPAsuNH1SbME1ajbwra854Edh5GyeeV0oCLFkAACH5BAUKAAIALA0AAgAKABUAAAIUjI+py+0PYxO0WoCz3rz7D4bi+BUAIfkEBQoAAgAsAgANABUACgAAAh2EjxLLjQ9UmzBNWo28K2vOeBHYeRsnnldKBixZAAA7" />
	  		</div>
		</div>`;
	//加载动画
	HFrame.load = function (index = 0) {
		let load = document.createElement('div');
		load.innerHTML = LoadHtml[index];

		let _body = document.querySelector('body');
		_body.appendChild(load);
		return load;
	}

	//关闭
	HFrame.close = function (itemElement) {
		if (itemElement)
			itemElement.remove();
	}
}(HFrame);