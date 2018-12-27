; !function (HFrame) {
	//拦截表单
	let _form = document.querySelectorAll("form");
	if (_form && _form.length > 0) {
		HFrame.use(['Alert', 'Http'], function () {
			for (let item of _form) {
				item.addEventListener('submit', function (event) {
					event.preventDefault(); //阻止提交表单
					let _That = this;
					let _Url = _That.action;
					let _Method = _That.method;
					let _Data = GetFormData(_That);
					HFrame.ajax(_Url, _Data, _Method, function (r) {
						HFrame.msg(r.ErrorMsg, 1000, function () {
							if (r.ErrorCode == -2) {
								location.href = '/Login';
							}
							if (r.ErrorCode == 0 && !HFrame.IsNullOrEmpty(r.CallbackPage)) {
								location.href = r.CallbackPage;
							}
						});
					});
					return false;
				});
			}
		});
	}

	//拦截删除按钮点击事件
	let _delete = document.querySelectorAll('.delete');
	if (_delete && _delete.length > 0) {
		HFrame.use(['Alert', 'Http'], function () {
			for (let item of _delete) {
				item.addEventListener("click", function (event) {
					event.preventDefault();
					let _That = this;
					let u = _That.href;
					HFrame.alert(
						{
							title: '删除确认!',
							content: '您确认要删除此数据么？'
						}, function () {
							HFrame.post(u, {}, function (r) {
								if (r.ErrorCode == 0) {
									_That.offsetParent.remove();
								}
								HFrame.msg(r.ErrorMsg, 1000, function () {
									if (r.ErrorCode == -2) {
										location.href = '/Login';
									}
								});
							});
						});
				});
			}
		});
	}

	/**
	 * 判断字符是否为空的方法
	 */
	HFrame.IsNullOrEmpty = function (obj) {
		if (typeof obj == "undefined" || obj == null || obj == "") {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 获取指定的URL参数值
	 */
	HFrame.getParam = function (paramName) {
		paramValue = "", isFound = !1;
		if (this.location.search.indexOf("?") == 0 && this.location.search.indexOf("=") > 1) {
			arrSource = unescape(this.location.search).substring(1, this.location.search.length).split("&"), i = 0;
			while (i < arrSource.length && !isFound) arrSource[i].indexOf("=") > 0 && arrSource[i].split("=")[0].toLowerCase() ==
				paramName.toLowerCase() && (paramValue = arrSource[i].split("=")[1], isFound = !0), i++
		}
		return paramValue == "" && (paramValue = null), paramValue
	}

	/**
	 * 占位符
	 */
	String.prototype.Format = function () {
		if (arguments.length == 0) return this;
		for (let s = this, i = 0; i < arguments.length; i++)
			s = s.replace(new RegExp("\\{" + i + "\\}", "g"), arguments[i]);
		return s;
	};
	/**
	 * 获取表单数据
	 */
	function GetFormData(_formData) {
		let res = {}, //存放结果的数组 
			current = null, //当前循环内的表单控件 
			i, //表单NodeList的索引 
			len, //表单NodeList的长度 
			k, //select遍历索引 
			optionLen, //select遍历索引 
			option, //select循环体内option 
			optionValue, //select的value 
			form = _formData; //用form变量拿到当前的表单，易于辨识 
		for (i = 0, len = form.elements.length; i < len; i++) {
			current = form.elements[i]; //disabled表示字段禁用，需要区分与readonly的区别 
			if (current.disabled) continue;
			switch (current.type) { //可忽略控件处理 
				case "file": //文件输入类型 
				case "submit": //提交按钮 
				case "button": //一般按钮 
				case "image": //图像形式的提交按钮 
				case "reset": //重置按钮 
				case undefined: //未定义 
					break; //select控件 
				case "select-one":
				case "select-multiple":
					if (current.name && current.name.length) {
						console.log(current)
						for (k = 0, optionLen = current.options.length; k < optionLen; k++) {
							option = current.options[k];
							optionValue = "";
							if (option.selected) {
								if (option.hasAttribute) {
									optionValue = option.hasAttribute('value') ? option.value : option.text
								} else {
									//低版本IE需要使用特性 的specified属性，检测是否已规定某个属性 
									optionValue = option.attributes('value').specified ? option.value : option.text;
								}
							}
							res[encodeURIComponent(current.name)] = encodeURIComponent(optionValue);
						}
					}
					break; //单选，复选框 
				case "radio":
				case "checkbox":
					//这里有个取巧 的写法，这里的判断是跟下面的default相互对应。
					//如果放在其他地方，则需要额外的判断取值 
					if (!current.checked) break;
				default: //一般表单控件处理 
					if (current.name && current.name.length) {
						res[encodeURIComponent(current.name)] = encodeURIComponent(current.value);
					}
			}
		}
		return res;
	}
}(HFrame);