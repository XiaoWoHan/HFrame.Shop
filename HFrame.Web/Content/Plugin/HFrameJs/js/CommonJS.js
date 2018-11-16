$(function() {
	common.ready();
})

var common = {}
common = {
	ready: function() {
		common.importJs('/Content/Plugin/layer/layer.js'); //默认引入Layer
		common.importJs('/Content/Plugin/HFrameJs/js/module/HttpHelper.js'); //默认引入Http模块
		common.interceptform(); //默认拦截表单
		console.log(common)
	},
	interceptform: function(callback) { //拦截表单
		$(":submit").click(function(check) {
			check.preventDefault(); //此处阻止提交表单
			var d = $('form').serializeArray();
			var u = $('form').attr("action");
			var m = $('form').attr("method");
			common.Http.ajax(u, d, m, function(r) {
				layer.msg(r.ErrorMsg, {
					anim: 0
				}, function() {
					if (callback) {
						callback(r);
					}
					if (r.ErrorCode==0&&!common.IsNullOrEmpty(r.CallbackPage)) {
						location.href = r.CallbackPage;
					}
				});
			});
		});
	},
	importJs: function importJs(url) { //封装引入JS
		var newscript = document.createElement('script');
		newscript.setAttribute('type', 'text/javascript');
		newscript.setAttribute('src', url);
		var head = document.getElementsByTagName('head')[0];
		head.appendChild(newscript);
	},
	IsNullOrEmpty: function(obj) {
		//判断字符是否为空的方法
		function isEmpty(obj) {
			if (typeof obj == "undefined" || obj == null || obj == "") {
				return true;
			} else {
				return false;
			}
		}
	}
}
