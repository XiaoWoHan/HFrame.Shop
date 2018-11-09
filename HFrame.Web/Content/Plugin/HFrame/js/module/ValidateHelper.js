common.defaulename = {
	///内部参数
	_Data: {
		Phoneregex: /^(13|15|17|18)[0-9]{9}$/,
		Emailregex: /^[a-z0-9]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$/,
		Dateregex:/^((20|21|22|23|[0-1]\d)\:[0-5][0-9])(\:[0-5][0-9])?$/,
		IdCardredex15: /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/,
		IdCardredex18:/^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$/
	},
	///内部方法
	IsTelPhone: function(data) {
		return Phoneregex.test(data);
	},
	IsEmail: function(val) {
		return Emailregex.test(data);
	},
	IsData:function(val){
		return Dateregex.test(data);
	},
	IsIdCard:function(data){
		return IdCardredex15.test(data)||IdCardredex18.test(data);
	}
}
