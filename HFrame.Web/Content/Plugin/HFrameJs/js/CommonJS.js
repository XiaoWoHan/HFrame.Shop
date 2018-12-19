; !function (window) {
	"use strict";
	var HFrame =
	{
		version: '0.0.1',
		config: {
			Path: "./js/module/",
			modulePath:"/Content/Plugin/HFrameJs/test/js"
		}
	}
	/**
	 * 私有变量
	 */
	let modules = {

		"Common":"module/CommonHelper.js",
		"Validate": "module/ValidateHelper.js",
		"Alert":"module/AlertHelper.js",
		"Http":"module/HttpHelper.js"
	}
	/**
	 * 引用模块
	 * @param {模块名称} ModuleName 
	 * @param {回调} Callback
	 */
	HFrame.use = function (ModuleName, Callback = undefined) {
		ModuleName = typeof ModuleName == "string" ? [ModuleName] : ModuleName;
		for (let [index, itemModule] of new Map(ModuleName.map((item, i) => [i, item]))) {
			_loadJS(itemModule, index + 1 == ModuleName.length ? Callback : undefined);
		}
		return HFrame;
	};

	/**
	 * 获取模块地址
	 * @param {地址} sUrl 
	 */
	function _GetUrl(sUrl) {
		if (sUrl in modules) return `${HFrame.config.modulePath}/${modules[sUrl]}`;
		else return `${HFrame.config.Path}/${sUrl}`
	}
	/**
	* 加载外部的js文件
	* @param sUrl 要加载的js的url地址
	* @fCallback js加载完成之后的处理函数
	*/
	function _loadJS(sUrl, fCallback) {
		sUrl = `${_GetUrl(sUrl)}?v=${HFrame.version}`;
		let _scripts = document.querySelectorAll(`script[src="${sUrl}"]`);
		if (_scripts.length > 0) {
			if (fCallback) {
				fCallback();
			}
			return;
		}
		let _script = document.createElement('script');
		_script.async = true;
		_script.src = sUrl;
		_script.charset = 'utf-8';
		_script.type = 'text/javascript';
		document.querySelector('head').appendChild(_script);
		let Browser = {
			ie: /msie/.test(window.navigator.userAgent.toLowerCase()),
			moz: /gecko/.test(window.navigator.userAgent.toLowerCase()),
			opera: /opera/.test(window.navigator.userAgent.toLowerCase()),
			safari: /safari/.test(window.navigator.userAgent.toLowerCase())
		};
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
	};
	window.HFrame = HFrame;
	HFrame.use("Common");
}(window);