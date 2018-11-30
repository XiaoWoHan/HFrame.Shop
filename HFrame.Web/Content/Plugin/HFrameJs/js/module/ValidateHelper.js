define(function(require, exports) {
	exports.IsTelPhone = IsTelPhone;
	exports.IsEmail = IsEmail;
	exports.IsData = IsData;
	exports.IsIdCard = IsIdCard;
});

///验证是手机号
function IsTelPhone(data) {
	let Phoneregex = /^(13|15|17|18)[0-9]{9}$/;
	return Phoneregex.test(data);
}
//验证是邮箱
function IsEmail(val) {
	let Emailregex = /^[a-z0-9]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$/;
	return Emailregex.test(data);
}
//验证是时间
function IsData(val) {
	let Dateregex = /^((20|21|22|23|[0-1]\d)\:[0-5][0-9])(\:[0-5][0-9])?$/;
	return Dateregex.test(data);
}
//验证是身份证
function IsIdCard(data) {
	let IdCardredex15 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/,
		IdCardredex18 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$/;
	return IdCardredex15.test(data) || IdCardredex18.test(data);
}
