var startVideoAnalize=function(){function a(a){function f(){null!=i&&(i.pause(),o=!1)}function g(){null!=i&&"#our-passion-drives-us"==window.location.hash&&(i.play(),h.removeClass("video-paused"),o=!1)}function w(){i.addEventListener("loadedmetadata",function(){l.setAttribute("max",i.duration),e()}),i.addEventListener("timeupdate",function(){null!=i&&(l.value=i.currentTime,m.style.width=Math.floor(i.currentTime/i.duration*100)+"%",e())}),i.addEventListener("timeupdate",function(){null!=i&&(l.getAttribute("max")||l.setAttribute("max",i.duration),l.value=i.currentTime,m.style.width=Math.floor(i.currentTime/i.duration*100)+"%",e())}),l.addEventListener("click",function(a){if(null!=i){var b=(a.pageX-this.offsetLeft)/this.offsetWidth;i.currentTime=b*i.duration}})}$(".modal--home-section").removeClass("modal--is-open"),$("#modal-"+a).addClass("modal--is-open"),h=$("#videoContainer"+a),i=$("#video"+a,"#videoContainer"+a)[0],p=$("#video"+a,"#videoContainer"+a),j=$("#video-controls"+a)[0],q=$("#video-controls"+a),null!=i&&(i.controls=!1,j.style.display="table",k=$("#playpause"+a)[0],r=$("#playpause"+a),l=$("#progress"+a)[0],s=$("#progress"+a),m=$("#progress-bar"+a)[0],t=$("#progress-bar"+a),u=$("#btPlay"+a),n=$("#videoTime"+a),o=!0,v=!0,w(),h.mousemove(function(a){o||q.hasClass("hide-all-elements")&&(q.removeClass("hide-all-elements"),$(".modal-header").removeClass("hide-all-elements"),d())}),p.click(function(){1==o||1==i.ended?c(""):b()}),r.click(function(a){i.played&&b()}),window.onfocus=g,window.onblur=f,u.click(function(a){window.mobile&&$(window).width()<1023||c("")}))}function b(){i.pause(),h.addClass("video-paused"),$(".icon-play").removeClass("click"),q.removeClass("hide-all-elements"),o=!0}function c(b){window.mobile&&$(window).width()<1023||(null==i&&a(b),$(".arrow-go-down").addClass("hidden"),$(".video-close").removeClass("is-hidden"),$("#main-header").addClass("hidden"),h.show(),o=!1,v=!0,(i.paused||i.ended)&&(i.play(),h.removeClass("video-paused"),$(this).addClass("click")),d(),v=!0)}function d(){q.hasClass("hide-all-elements")||setTimeout(function(){o||(q.addClass("hide-all-elements"),$(".modal-header").addClass("hide-all-elements"))},2500)}function e(){var a,b,c,d,e,g;a=Math.floor(i.currentTime),b=Math.floor(i.duration),c=Math.floor(a/60),d=Math.floor(60*(a/60-c)),e=Math.floor(b/60),g=Math.floor(60*(b/60-e));i.currentTime;d=f(d),g=f(g),n.html(c+":"+d+" / "+e+":"+g),c==e&&d==g&&startVideoAnalize.closeVideo("scrollback")}function f(a){return 10>a&&(a="0"+a),a}if(!(window.mobile&&$(window).width()<1023)){var g=!!document.createElement("video").canPlayType;if(g){var h,i,j,j,k,l,m,n,o,p,q,r,s,t,u,v=!1;return $("#btPlayStart").click(function(a){c("")}),$(".modal--do-close").click(function(){v&&startVideoAnalize.closeVideo("noScroll")}),{playVideoModal:function(){window.mobile&&$(window).width()<1023||c("")},closeVideo:function(a){null!=i&&($(".modal--home-section").removeClass("modal--is-open"),$(".arrow-go-down").removeClass("hidden"),$(".video-close").addClass("is-hidden"),o=!0,v=!1,i.pause(),q.removeClass("hide-all-elements"),$(".modal-header").removeClass("hide-all-elements"),$("#main-header").removeClass("hidden"),"scroll"==a?window.location.hash="#!":"scrollPause"==a?b():"scrollback"==a?(window.location.hash="#!",i.currentTime=0,l.value=0):"back"==a?(i.currentTime=0,l.value=0):(i.currentTime=0,l.value=0),i=null,r.unbind("click"),p.unbind("click"))},changeVideo:function(a){window.mobile&&$(window).width()<1023||c(a)},obtainVideoState:function(){return v}}}}}();