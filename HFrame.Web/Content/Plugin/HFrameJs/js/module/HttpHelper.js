; !function (HFrame) {
	///发送get请求
	var _getlocker = false;
	HFrame.get = function (url, data, callback) {
		HFrame.use("Alert", function () {
			if (!_getlocker) {
				_getlocker = true;
				HFrame.ajax(url, data, 'get', function (r) {
					_getlocker = false;
					if (callback) {
						callback(r);
					}
				});
			} else {
				HFrame.msg("操作太快啦，稍后再试吧");
			}
		});
	}

	///发送post请求
	var _postlocker = false;
	HFrame.post = function (url, data, callback) {
		HFrame.use("Alert", function () {
			if (!_postlocker) {
				_postlocker = true;
				HFrame.ajax(url, data, 'post', function (r) {
					_postlocker = false;
					if (callback) {
						callback(r);
					}
				});
			} else {
				HFrame.msg("操作太快啦，稍后再试吧");
			}
		});
	}
	/**
	 * 发送Ajax请求
	 * method：请求方法，常用的有get和post；
	 * headers：请求头信息，最常用的就是表单格式的数据：”Content-type”:”application/x-www-form-urlencoded”；
	 * mode：控制是否允许跨域。same-origin（同源请求）、no-cors（默认）和cros（允许跨域请求）；
	 * cache：关于缓存的一些设置；
	 * body：要发送到后台的参数，可以为ArrayBuffer，String，FormData等类型；
	 */
	var _ajaxlocker = false;
	HFrame.ajax = function (url, data, method, callback) {
		HFrame.use("Alert", function () {
			if (!_ajaxlocker) {
				_ajaxlocker = true;
				var loader = HFrame.load();
				fetch(url,
					{
						method: method
						, headers: {
							"Content-type": "application/json"
						}
						, body: JSON.stringify(data)
					})
					.then(response => {
						if (response.ok) {
							return response.json();
						}
					})
					.then(ref => {
						if (callback) {
							callback(ref);
						}
					})
					.catch(err => {
						HFrame.msg("请求出错");
						console.error(err);
					})
					.then(ref => {
						HFrame.close(loader);
						_ajaxlocker = false;
					});

			} else {
				HFrame.msg("操作太快啦，稍后再试吧");
			}
		});
	}
}(HFrame);