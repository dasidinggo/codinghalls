// JavaScript Document
		(function($){
			$.fn.extend({
				Marquee:function(opt,callback){   
					if(!opt) var opt={};
						var _btnLeft = $("#"+ opt.left);//Shawphy:向上按钮
						var _btnRight = $("#"+ opt.right);//Shawphy:向下按钮
						var timerID;
						var _this=this.eq(0).find("ul:first");
						var     lineW=_this.find("li:first").width(), //获取列宽
								line=opt.line?parseInt(opt.line,0):parseInt(this.width()/lineW,10), //每次滚动的行数，默认为一屏，即父容器高度
								speed=opt.speed?parseInt(opt.speed,10):800; //卷动速度，数值越大，速度越慢（毫秒）
								timer=opt.timer //?parseInt(opt.timer,10):3000; //滚动的时间间隔（毫秒）
						if(line==0) line=1;
						var leftwidth = 0-line*lineW;
						//滚动函数
						
						//Shawphy:向左翻页函数
						var scrollLeft=function(){
								_btnLeft.unbind("click",scrollLeft); //Shawphy:取消向上按钮的函数绑定
								_this.animate({
										marginLeft:leftwidth
								},speed,function(){
										for(i=1;i<=line;i++){
												_this.find("li:first").appendTo(_this);
										}
										_this.css({marginLeft:0});
										_btnLeft.bind("click",scrollLeft); //Shawphy:绑定向上按钮的点击事件
								});
						}
						
						//Shawphy:向右翻页函数
						var scrollRight=function(){
								_btnRight.unbind("click",scrollRight);
								for(i=1;i<=line;i++){
										_this.find("li:last").show().prependTo(_this);
								}
								_this.css({marginLeft:leftwidth});
								_this.animate({
										marginLeft:0
								},speed,function(){
										_btnRight.bind("click",scrollRight);
								});
						}
						
					   //Shawphy:自动播放
//						var autoPlay = function(){
//								if(timer)timerID = window.setInterval(scrollLeft,timer);
//						};
//						var autoStop = function(){
//								if(timer)window.clearInterval(timerID);
//						};
//						 //鼠标事件绑定
//						_this.hover(autoStop,autoPlay).mouseout();
						_btnLeft.css("cursor","pointer").click( scrollLeft );//Shawphy:向上向下鼠标事件绑定
						_btnRight.css("cursor","pointer").click( scrollRight );
				}
			})
		})(jQuery);

		
//		$(function(){
//            $("#scroolbar2").Marquee({line:1,speed:300,timer:3000,left:"sbnright",right:"sbnleft"});
//		});

		 
