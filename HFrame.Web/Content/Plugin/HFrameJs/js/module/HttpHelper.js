///内部参数
let _Data = {
	postlocker: false, //post锁
	getlocker: false, //get锁
	ajaxlocker: false, //Ajax锁
};
var Message,Load;
///发送get请求
function get(url, data, callback) {
	if (!_Data.getlocker) {
		_Data.getlocker = true;
		ajax(url, data,'get', function(r) {
			_Data.getlocker = false;
			if (callback) {
				callback(r);
			}
		});
	} else {
		Message.warning("操作太快啦，稍后再试吧");
	}
}

///发送post请求
function post(url, data, callback) {
	if (!_Data.postlocker) {
		postlocker = true;
		ajax(url, data,'post', function(r) {
			_Data.postlocker = false;
			if (callback) {
				callback(r);
			}
		});
	} else {
		Message.warning("操作太快啦，稍后再试吧");
	}
}

///发送Ajax请求
function ajax(url, data, method, callback) {
	if (!_Data.ajaxlocker) {
		$.ajax({
			url: url,
			data: data,
			type: method,
			async: true,
			beforeSend: function() {
				_Data.ajaxlocker = true;
				Load.load();
			},
			success: function(r) {
				callback(r);
			},
			error: function(XMLHttpRequest, textStatus, errorThrown) {
				Message.warning("请求出错");
			},
			complete: function() {
				_Data.ajaxlocker = false;
				Load.close();
			},
			timeout: 20000
		})
	} else {
		Message.warning("操作太快啦，稍后再试吧");
	}
}

define(function(require, exports) {
	Message=require("MessageHelper");
	Load=require("LoadHelper");
	exports.get = get;
	exports.post = post;
	exports.ajax = ajax;
});
