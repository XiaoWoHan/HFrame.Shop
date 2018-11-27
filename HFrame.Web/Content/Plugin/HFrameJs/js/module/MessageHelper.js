define(function(require, exports) {
	exports.ready = function() {
		require.async(["notify"]); //拦截表单
	}
	exports.msg = msg;
	exports.success = success;
});

//弹窗
function msg(message,pram) {
	
	let message=message;
	let title=pram.title||"通知";
	$.notify({
		title: pram.title||'通知',
		message: message
	});
}
//弹窗
function success(message) {
	$.notify(message);
}
