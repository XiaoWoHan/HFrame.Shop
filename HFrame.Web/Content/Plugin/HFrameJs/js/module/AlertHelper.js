let MsgHtml=[];
MsgHtml[0] =
	`<div style="background-color: rgba(0,0,0,.6);color: #fff;border:none;text-align: center;z-index: 19999;padding-bottom:3px;min-width:100px;max-width:200px;">
		
	</div>`;
function msg(message){
	$('body').append(MsgHtml[0]);
}
define(function(require, exports) {
	exports.msg=msg;
});
