; (function (window) {
	var HFrame = window.HFrame || {};

	HFrame.config = {
		path: "js/module/"
	};
	HFrame.model = {
		Alert: "js/module/AlertHelper.js",
		Validate: "js/module/ValidateHelper.js"
	}
	/**
	 * 加载模块
	 */
	HFrame.use = function (model, fCallback) {
		//判断参数格式
		//TODO 判断已加载模块
		switch (model.constructor) {
			case Array:
				model.forEach((element, index) => {
					var Url = GetModelUrl(element);
					if (Url) {
						//TODO 回调如果最后一个加载完成前面未加载完成则出错
						LoadJS(Url, index + 1 == model.length ? fCallback : null);
					}
				});
				break;
			case String:
				var Url = GetModelUrl(model);
				LoadJS(Url, fCallback);
				break;
			default:
				//TODO 抛出异常
				return;
		}
	}
	/**
	 * 获取模块路径
	 * @param {模块名称} Name 
	 */
	function GetModelUrl(Name) {
		if (Name in HFrame.model) {
			return HFrame.model[Name]
		}
		return `${HFrame.path} ${Name}`;
	}
	/**
	 * 加载JS文件
	 * @param {Js路径} sUrl 
	 * @param {加载完成回调} fCallback 
	 * @todo 添加缓存
	 */
	function LoadJS(sUrl, fCallback) {
		//判断当前浏览器
		let Browser = {
			ie: /msie/.test(window.navigator.userAgent.toLowerCase()),
			moz: /gecko/.test(window.navigator.userAgent.toLowerCase()),
			opera: /opera/.test(window.navigator.userAgent.toLowerCase()),
			safari: /safari/.test(window.navigator.userAgent.toLowerCase())
		}
		var _script = document.createElement('script');
		_script.setAttribute('charset', 'gbk');
		_script.setAttribute('type', 'text/javascript');
		_script.setAttribute('src', sUrl);
		document.getElementsByTagName('head')[0].appendChild(_script);

		if (Browser.ie) {
			_script.onreadystatechange = function () {
				if (this.readyState == 'loaded' || this.readyStaate == 'complete') {
					if (fCallback != undefined) {
						fCallback();
					}

				}
			};
		} else if (Browser.moz) {
			_script.onload = function () {
				if (fCallback != undefined) {
					fCallback();
				}
			};
		} else {
			if (fCallback != undefined) {
				fCallback();
			}
		}
	}

	window.HFrame = HFrame;
})(window);