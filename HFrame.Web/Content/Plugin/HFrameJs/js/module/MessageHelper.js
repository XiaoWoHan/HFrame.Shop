define(function(require, exports) {
	require.async(["notify"]); //拦截表单
	exports.msg = msg;
	exports.success = success;
});
//信息样式
let typeInfo = ['', 'info', 'danger', 'success', 'warning', 'rose', 'primary'];
//成功弹窗
function success(message,callback) {
	msg(message, 3,callback);
}
//错误弹窗
function error(message,callback) {
	msg(message, 2,callback)
}
//警告弹窗
function warning(message,callback) {
	msg(message, 4,callback)
}
//弹窗
function msg(message, messagetype,callback) {
	let type = {
		type: typeInfo[messagetype] || typeInfo[1],
		timer:1000,
		placement: {
			from: "top",
			align: "right"
		},
		onClosed:callback
	}
	$.notify(message, type);
}
