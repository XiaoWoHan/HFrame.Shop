///内部参数
var _Data = {
	postlocker: false, //post锁
	getlocker: false, //get锁
	ajaxlocker: false, //Ajax锁
};

///发送get请求
function get(url, data, callback) {
	if (!_Data.getlocker) {
		_Data.getlocker = true;
		$.get(url, data, function(r) {
			_Data.getlocker = false;
			if (callback) {
				callback(r);
			}
		});
	} else {
		layer.msg("操作太快啦，稍后再试吧");
	}
}

///发送post请求
function post(url, data, callback) {
	if (!_Data.postlocker) {
		postlocker = true;
		$.post(url, data, function(r) {
			_Data.postlocker = false;
			if (callback) {
				callback(r);
			}
		});
	} else {
		layer.msg("操作太快啦，稍后再试吧");
	}
}

///发送Ajax请求
function ajax(url, data, method, callback) {
	var lod;
	if (!_Data.ajaxlocker) {
		$.ajax({
			url: url,
			data: data,
			type: method,
			async: true,
			beforeSend: function() {
				_Data.ajaxlocker = true;
				lod = layer.load();
			},
			success: function(r) {
				callback(r);
			},
			error: function(XMLHttpRequest, textStatus, errorThrown) {
				layer.msg("请求出错");
			},
			complete: function() {
				_Data.ajaxlocker = false;
				layer.close(lod);
			},
			timeout: 20000
		})

	} else {
		layer.msg("操作太快啦，稍后再试吧");
	}
}

define(function(require, exports) {
	exports.get = get;
	exports.post = post;
	exports.ajax = ajax;
});
