seajs.config({  
    base: '/Content/Plugin/HFrameJs/js/module/',  
    alias: {
		"layer":"/Content/Plugin/layer/layer.js"
    },  
    charset: 'utf-8',  
    timeout: 20000,  
    debug: false  
}); 

$(function() {
	common.ready();
})

var common = {}
common = {
	ready: function() {
		common.use('CommonHelper.js', function(r) {
			common.Helper = r;
		});
	},
	use: function(moduleName,callback) {
		seajs.use(moduleName, function(r) {
			if(r.ready){
				r.ready();
			}
			callback(r);
		});
	}
}
