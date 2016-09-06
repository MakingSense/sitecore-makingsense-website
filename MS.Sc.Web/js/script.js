if (/Android|webOS|iPhone|iPad|iPod|BlackBerry/i.test(navigator.userAgent)) {
    window.mobile = true;
} else {
    window.mobile = false;
}

function showCloseModal() {
	$('.modal--holder').parents('section').each(function(){
		if(window.location.hash == '#' + $(this).attr('id') || window.location.hash == '#' + $(this).find('.modal--holder').attr('id')) {
			$('#main-header').addClass('modal--is-open');
            $("html").addClass('noScroll');

            if (getCurrentSection() == "talk-to-us") {

                setTimeout(function(){
                    $(".parallax--bg-fixed").css('z-index', '900');
                }, 50);
            };
			if($('#main-header').hasClass('header--is-hidden')){
				$('#main-header').removeClass('header--is-hidden');
            }
            return;
		} else {
			$('#main-header').removeClass('modal--is-open');
			$("html").removeClass('noScroll');
			if($(document).scrollTop() > 100)
				$('#main-header').addClass('header--is-hidden');
		}
	});
}

function displayMobileMenu() {
	$('.menu--show-mobile').off().click(function(event){

        $(this).parents('#main-header').toggleClass('modal--is-open');
		$('.modal--mobile-menu').toggleClass('modal--is-open');
        $('html, body').toggleClass('mobile--nav-open');
        $("html").toggleClass('noScroll');

		event.preventDefault();

        if($('#main-header').hasClass('modal--is-open')) {
            $('.modal--do-close').click(function(event){
                $("html").removeClass('noScroll');
                $(this).parents('#main-header').removeClass('modal--is-open');
                $('.modal--mobile-menu').removeClass('modal--is-open');
                $('html, body').removeClass('mobile--nav-open');
                $('#main-header').removeClass('modal--is-open');
                //event.preventDefault();
            })
        }
	});
}

function checkVisible( elm, eval ) {
    eval = eval || "visible";
    var vpH = $(window).height(), // Viewport Height
        st = $(window).scrollTop(), // Scroll Top
        y = $(elm).offset().top,
        elementHeight = $(elm).height();

    if (eval == "visible") return ((y < (vpH + st)) && (y > (st - elementHeight)));
    if (eval == "above") return ((y < (vpH + st)));
};

var arrayHash = ["#our-passion-drives-us", "#more-about-us", "#video-slide1", "#video-slide2", "#video-slide3"];

$(window).on('hashchange', function(){
	displayMobileMenu();
    showCloseModal();
    var currentChangedHash = window.location.hash;
    var closeVideo = true;

    $.each( arrayHash, function( key, value ) {
        if (currentChangedHash == value) {
            closeVideo = false;
        }
    });
    if (closeVideo && startVideoAnalize.obtainVideoState()) {startVideoAnalize.closeVideo('back');};
});

function ctaTopNav() {
	var lastScrollTop = 0, delta = 5, isModalOpen = false;

	$(window).scroll(function(event){
		var st = $(this).scrollTop();

		if(Math.abs(lastScrollTop - st) <= delta)
			return;

        if (st > lastScrollTop && st > 100){
			// downscroll code
			$('#main-header').addClass('header--is-hidden');
		} else {
			// upscroll code
			$('#main-header').removeClass('header--is-hidden');
		}

		if($('#main-header').hasClass('modal--is-open')) {
			$('#main-header').removeClass('header--is-hidden');
		}

		lastScrollTop = st;
	});
}


/* ==================================================================================================================== */
/*    About-US Video Full Height Top                                                                                    */
/* ==================================================================================================================== */

$('#btPlayStart').click(function() {
    $(window, 'body', 'html').scrollTop(0);
});

/* ==================================================================================================================== */

$(document).ready(function() {

	displayMobileMenu();

    $('a[href^="#"]').not('.modal--do-close').not('.menu-icon').not('.menu--show-mobile').not('.icon-play').not('.play-testimonial').not('#cancel-subscribe').click(function(event)  {

        setTimeout(function(){
            history.pushState(null, "", window.location.href);
        },500);

        event.preventDefault();

        var dest_elem = $(this).attr('href');
        var header_height = $('#main-header').outerHeight();

        if ($('.form--default').length > 0) {
            $('.form--default')[0].reset();
        }

        $(".form--default div.input--holder").removeClass('input--has-value');

        $('body, html').animate({
          scrollTop: $(dest_elem).offset().top
        }, 400, function(){
        			location.replace( dest_elem );
        		});
    });

    showCloseModal();
	ctaTopNav();

    $("#cancel-subscribe").click(function() {
        $(".input-form").val("");
        $(".input--holder").each(function() {
            $(this).removeClass('input--has-error').removeClass('input--is-active').removeClass('input--has-value');
            var labelText = $(this).find('.label-visible');
                labelText.text(labelText.data('text'));
        });
    });



	//detectar scroll hacia abajo

    var doc = $(document);          //objeto sobre el que quiero detectar scroll
    var obj_top = doc.scrollTop()   //scroll vertical inicial del objeto
    var headerHeight = $('#main-header').outerHeight(true);  // Obtengo la altura del header.

    //evento para cuando se hace scroll
    doc.scroll(function(){
        var obj_act_top = $(this).scrollTop();  //obtener scroll top instantaneo
        //Obtengo la opacidad mediante el alto del video resto el valor del scroll donde se encuentra el doc y luego divido por el alto del video,
        // para obtener un valor menor a 1.
        var opacity = ($('.parallax--bg-fixed').height() - obj_act_top) / $('.parallax--bg-fixed').height();


        if(!window.mobile && $(window).width() > 1023) {
            //asigno la opacidad mediante CSS.
            if(opacity >= 0.3)
                $('.content--table-center', '.parallax--bg-fixed').css('opacity', opacity);

            //Margen negativo en el contenido del header onScroll.
            if(obj_act_top / 5 < 160)
                if (!$("#main-header").hasClass('modal--is-open')) {
                    $('.parallax--bg-fixed .wrapper').css({'margin-top': '-' + (obj_act_top / 5) + 'px' });
                };
                // $(".talk-to-us.wrapper").css('margin-top', '0');
        }


        if($(window).width() < 800) {
            if (($('.parallax--bg-fixed').height() - obj_act_top) - 200 <= headerHeight) {
                $('#main-header').addClass('not-over-header');
            }
            else{
                $('#main-header').removeClass('not-over-header');
            };
        } else {
            if (($('.parallax--bg-fixed').height() - obj_act_top) <= headerHeight) {
                $('#main-header').addClass('not-over-header');
            }
            else{
                $('#main-header').removeClass('not-over-header');
            };
        }

        if (opacity <= 0.5 && window.location.hash == '#our-passion-drives-us' && getCurrentSection() == 'about-us'){
            startVideoAnalize.closeVideo("scroll");
        }

        /*Services*/
        if (getCurrentSection() == 'services') {
            var target = $(".services--process").offset().top;
            if(obj_act_top >= target - $(".services--process").position().top){
                $(".process-image").addClass("animated fadeInUp");
                $(".icon-holder.black").addClass("animated fadeIn");
                $(".icon-holder.violet").addClass("animated fadeIn");
                $(".icon-holder.orange").addClass("animated fadeIn");
                $(".icon-holder.darkGray").addClass("animated fadeIn");
                $(".shadow-image").addClass("animated fadeInDown");
            }
        }


        if (getCurrentSection() == 'home' && !window.mobile && !$(window).width() < 1023) {
            if($('#video').length > 0 && obj_act_top > $('.parallax--bg-fixed').height()) {
                $('#video')[0].pause();
            } else {
               $('#video')[0].play();
            }
        }
    });

	//Careers al hacer click sobre cada uno de los elementos.
    $('.testimonial--member').click(function(event) {
        var textMember = $(this).attr('data-member-testimonial');
        var blockquoteText = $('.member-testimonial-text');
        blockquoteText.addClass('fadeOut');
        setTimeout(function(){
            blockquoteText.text(textMember);
            blockquoteText.removeClass('fadeOut');
        }, 300);

        $('.testimonial--member').removeClass('testimonial--is-active');
        $(this).addClass('testimonial--is-active')
        event.preventDefault();
    });


    (function($){
        $.fn.clearDefault = function(){
            return this.each(function(){
                var default_value = $(this).val();
                $(this).focus(function(){
                    if ($(this).val() == default_value) $(this).val("");
                });
                $(this).blur(function(){
                    if ($(this).val() == "") $(this).val(default_value);
                });
            });
        };
    })(jQuery);

    $('input, select, textarea').each(function(){

      $(this).focus(function(){
        if (!$(this).parent('.input--holder').hasClass('input--has-error')) {
            $(this).parent('.input--holder').addClass('input--is-active');
        };
        var labelText = $(this).parent('.input--holder').find('.label-visible');
        if($(this).val() == '' && !$(this).parent('.input--holder').hasClass('input--has-error')) {
            labelText.text(labelText.data('text'));
        };
      });

        $(this).keyup(function() {
            $(this).parent('.input--holder').removeClass('input--has-error').addClass('input--is-active input--has-value');
            if($(this).val() == "") {
                $(this).parent('.input--holder').removeClass('input--has-value');
            }
            var labelText = $(this).parent('.input--holder').find('.label-visible');
            labelText.text(labelText.data('text'));
        });

        $(this).blur(function(){
            $(this).parent('.input--holder').removeClass('input--is-active');
            if($(this).val() == '') {
              $(this).parent('.input--holder').removeClass('input--has-value');
            }
            else{
                $(this).parent('.input--holder').addClass('input--has-value');
            }
        });
    });



    $("#action-button").click(function() {
        $('body').addClass('frm-contact');
        $('.talk-to-us-intro').addClass('contact-frm-bg');
        // $(".form-wrapper").show();
        //$(".section-intro .section-header,.section-intro .pure-g-r,.nav-menu-top,.section-lead").hide();

        // $('.cancel-contact').css('display', 'table');

    });

    $('.cancel-contact').click(function() {
        $('body').removeClass('frm-contact');
        $('.talk-to-us-intro').removeClass('contact-frm-bg');
        // $(".form-wrapper").hide();
        // $(".section-intro .section-header,.section-intro .pure-g-r,.nav-menu-top,.section-lead").show();
        // $('.talk-to-us-intro').removeClass('contact-frm-bg');
        // $('.cancel-contact').hide();
        event.preventDefault();
    });

    if (getCurrentSection() == 'home') {

        var currentHash = window.location.hash;
        var currentSlide = currentHash.replace('#slide','');
        currentSlide = currentSlide - 1;

        $('.play-testimonial').click(function() {
            var idSlide = $(this).attr('href');
            startVideoAnalize.changeVideo($(this).attr('href').replace('#','-'));
            // else if (idSlide == '#video-slide3') { startVideoAnalize.videoPublic = $('.home--slide3')[0]; }
        });

        if(window.mobile) {
            if ($(window).width() < 1023) {
                if(window.location.hash == '#video-slide1') {
                    window.open( "https:\/\/www.youtube.com\/watch\?v\=JbzsRXWNEJQ", "_self");
                }
                else if(window.location.hash == '#video-slide2') {
                    window.open( "https:\/\/www.youtube.com\/watch\?v\=os0O9qkfjiI", "_self");
                }
                else if(window.location.hash == '#video-slide3') {
                    window.open( "https:\/\/www.youtube.com\/watch\?v\=nlurow_MHAU", "_self");
                }
                else{
                    $("a[href='#video-slide1']").attr('href', "https:\/\/www.youtube.com\/watch\?v\=JbzsRXWNEJQ");
                    $("a[href='#video-slide2']").attr('href', "https:\/\/www.youtube.com\/watch\?v\=os0O9qkfjiI");
                    $("a[href='#video-slide3']").attr('href', "https:\/\/www.youtube.com\/watch\?v\=nlurow_MHAU");
                }
            }
            else{
                $('.play-testimonial').click(function() {
                    var idSlide = $(this).attr('href');
                    $('#main-header').css('display', 'none');
                    startVideoAnalize.changeVideo($(this).attr('href').replace('#','-'));
                 });
            }

            var heightSlider = $('#our-work').height();
            $('.section-touch').slick({
                fade: true,
                infinite: true,
                speed: 500,
                slide: 'div',
                arrows: false,
                cssEase: 'linear',
                onInit: function(){
                    $('.slick-slide').css('height', heightSlider - 150); //150px is a height of paginator.
                    $('.slick-list').css('height', heightSlider);
                    $(".item").css('position', 'relative');
                },
                onAfterChange: function(){
                    window.location.hash = $(".slick-active").attr('id');
                }
            });

            if (currentHash.indexOf("#slide") >= 0) {
                $('.section-touch').slickGoTo(currentSlide);
            }
            else {
                $('.play-testimonial').click(function() {
                    var idSlide = $(this).attr('href');
                    startVideoAnalize.changeVideo($(this).attr('href').replace('#','-'));
                 });
            }

            $('a[class*="pager-"]').click(function(event) {
                var slideNumbre = $(this).attr('href');
                var slideNumbre = slideNumbre.replace('#slide','');
                slideNumbre = slideNumbre - 1;
                $('.section-touch').slickGoTo(slideNumbre);
            });

        }

        $('.modal--testimonial').each(function() {
            var idSlide = '#' +  $(this).attr('id');
            if(window.location.hash == idSlide) {
                $('#main-header').css('display', 'none');
                startVideoAnalize.changeVideo(idSlide.replace('#','-'));
            };
        });
    };

    if (getCurrentSection() == 'about-us') {
        if(window.mobile && $(window).width() < 1023){
            if(window.location.hash == '#our-passion-drives-us') {
                window.open( "https:\/\/www.youtube.com\/watch\?v\=L9gv1k\-rvak", "_self");
            }
            else {
                $("a[href='#our-passion-drives-us']").attr('href', "https:\/\/www.youtube.com\/watch\?v\=L9gv1k\-rvak");
            }
        }
        else if(window.location.hash == "#our-passion-drives-us"){
            startVideoAnalize.playVideoModal();
        };

        //$('.icon-play').click(function(event) { startVideoAnalize.iconPlayVideo(); });


        $("#icon-play-2013").click(function(event) {
            $("#video-2013")[0].play();
            $(".block--is-video").css('display', 'block');
            $(this).addClass('icon-play-hide');
        });
    };

    function updateContentMenuServices(event, elementSelected){
        var completeItem;

        $('.menu-icon').each(function(index){
            if ($(this).attr("href") == elementSelected) {
                completeItem=$(this);
            };
        });

        $('.menu-icon').removeClass('menu-icon-active');
        completeItem.addClass('menu-icon-active');
        $('.slide').removeClass('services--is-active');
        $(elementSelected).addClass('services--is-active');
        event.preventDefault();
    }

    /*Load functions for current section */
    if (getCurrentSection() == 'services') {

        /* Init the timeline controlls */
        serviceSwitcher();
         /* Form controller*/
        SendMail("services_new-projects");

        if (!window.location.hash == "" && window.location.hash != "#our-services") {
            updateContentMenuServices(event, window.location.hash);
        }

        $('.menu-icon').click(function(event){
            updateContentMenuServices(event, $(this).attr('href'));
        });
    }

    else if (getCurrentSection() == 'careers') {

        var videoPlayed = false
        var heightScreen, screenPosition;

        var offsetXmoveVideo = .02;
        var offsetXmoveVideoMan = offsetXmoveVideo * 4;
        getLinkedingJobs();
        uploadFile();


        $("#button_form_careers").click(function(){
            SendMail("careers_new-projects");
        });

        if(window.mobile && $(window).width() < 1023){
            if(window.location.hash == '#more-about-us') {
                window.open( "https:\/\/www.youtube.com\/watch\?v\=KZKCyay9Mus", "_self");
            }
            else{
                $("a[href='#more-about-us']").attr('href', "https:\/\/www.youtube.com\/watch\?v\=KZKCyay9Mus");
            }
        }
        else if(window.location.hash == "#more-about-us" ) {
            startVideoAnalize.playVideoModal();
            setScrollValues();
        };

        $('.modal--do-close').click(function() {
            toggleModalContent(true);
        });

        //$("#apply-to-position").height($(window).height());

        $('.block--is-video.careers--play-video').mousemove(function(e){

            var contXVideo = (e.pageX - $(window).width() * 0.2) * offsetXmoveVideo - 300;
            var contXMan = (e.pageX * offsetXmoveVideoMan);

            $(".section--testimonials-video").css({"background-position": contXVideo + "px"});
            $(".parallax-careers").css({left: contXMan +'px'},"slow","linear");
        });

        $('.icon-play').click(function(event) {
            setScrollValues();
        });

        function setScrollValues(){
            videoPlayed = true;
            heightScreen = $(window).height()/2;
            screenPosition = $(window).scrollTop();
            scrollVideo = 0;
    }

        $(window).scroll(function() {
            if (videoPlayed) {
                var scrollVideo = Math.abs(screenPosition - $(window).scrollTop());
                if (scrollVideo >= heightScreen) {
                    startVideoAnalize.closeVideo("scrollPause");
                    videoPlayed = false;
                };
            }
        });
    }

    else if (getCurrentSection() == 'our-work') {
        $(window).scroll(function() {
            $('.product--blocks').each(function(){
                if (checkVisible($(this))) {
                    $(this).addClass('product--animate-blocks');
                }
            })

        });
    }

    else if (getCurrentSection() == 'talk-to-us') {
        /* Load Google Maps API and show the map */
        mapSwitcher();
        window.onload = loadScript;
        /* Form controller*/

        $("#button_form_talk_to_us").click(function(){
            SendMail("talk-to-us_new-projects");
    });

        $('.modal--do-close').click(function() {
        toggleModalContent(true);
    });
    }

    doExternalLinks();
    susbscribeNewsletter();
});


function citySwitcher() {
    $('.current-office').click(function() {
        $(this).parent('.office-selector').toggleClass('selector-closed selector-opened');
    });

    $('.offices a').click(function() {
        var cityActiveName = $(this).data('city');
        var cityActiveClass = $(this).attr('class');

        $(this).parents('.office-selector').find('.current-office').text(cityActiveName);
        $(this).parents('.office-selector').toggleClass('selector-opened selector-closed');
    });
}

function mapSwitcher() {
    $(document).click(function(e){
        var container = $(".current-office");
        if (!container.is(e.target) // if the target of the click isn't the container...
        && container.has(e.target).length === 0) // ... nor a descendant of the container
        {
            container.parent('.office-selector').removeClass('selector-opened').addClass('selector-closed');;
        }
    });
    $('.current-office , .msicon-arrow-down-combo').click(function(event) {
        $(this).parent('.office-selector').toggleClass('selector-closed selector-opened');

        event.preventDefault();
    })

    $('.offices a').click(function(event) {

        var officeCity = $(this).attr('class');

        getOfficeInfo(officeCity);

        event.preventDefault();
    });


}


function getOfficeInfo(officeCity) {

    var cityActiveName = $('.' + officeCity).data('city');
    var cityActiveClass = $('.' + officeCity).attr('class');
    var cityCoords = $('.' + officeCity).data('coords');
    var coords = cityCoords.split(',');
    var cityHero = $('.' + officeCity).data('hero');
    var cityAddress = $('.' + officeCity).data('address');
    var cityPhone = $('.' + officeCity).data('phone');
    var cityText = $('.' + officeCity).data('text');

    $('.' + officeCity).parents('.office-selector').find('.office-name').text(cityActiveName);
    $(".map-hero").text(cityHero);
    $('.' + officeCity).parents('.section--holder').find('.maps-data').find('.maps-info').find('.info-address').html(cityAddress);
    $('.' + officeCity).parents('.section--holder').find('.maps-data').find('.maps-info').find('.info-phone').text(cityPhone);

    $('.' + officeCity).parents('.office-selector').removeClass('selector-opened').addClass('selector-closed');

    initialize(coords[0], coords[1]);

}

var map = null;
var center = null;
var lat = '';
var lng = '';
var userlang = window.navigator.userLanguage || window.navigator.language;

function initialize(lat, lng) {
    var mapOptions = {
        zoom: 17,
        disableDefaultUI: true,
        center: new google.maps.LatLng(lat, lng),
        mapTypeId: google.maps.MapTypeId.HYBRID,
    }
    map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    var center = map.getCenter();
    google.maps.event.addDomListener(window, "resize", function() {
        google.maps.event.trigger(map, "resize");
        map.setCenter(center);
    });


}

function loadScript() {
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = "http://maps.googleapis.com/maps/api/js?key=AIzaSyDn1Jw5vfiG68VSuK3u1SVWW_8CtUlBaDg&sensor=false&callback=obtainLatLong";
        document.body.appendChild(script);
}


/* ==================================================================================================================== */
/*    ALL SECTIONS > Form functions                                                                             */
/* ==================================================================================================================== */

/*function sendForm(formID) {

    $('#' + formID).submit(function(event) {
        var evaluateValid = formValidation(formID);
        if (!evaluateValid) {
            return false;
        } else {
            $.ajax({
                type: 'POST',
                url: $('#' + formID).attr('action'),
                data: new FormData( this ),
                processData: false,
                contentType: false,
                success: function(response) {
                    toggleModalContent(false);
                    //que muestre algo si es success
                }
            });
        }
        return false;
    })
}*/

function toggleModalContent(showOrHide) {
    if (showOrHide == true) {
        $(".modal--holder").removeClass('modal--content-form-is-success');
    }
    else{
        $(".modal--holder").addClass('modal--content-form-is-success');
    }

    $(".input-form").val("");
    $(".input--holder").each(function() {
        //onsole.log($(this));
        $(this).removeClass('input--has-error').removeClass('input--is-active').removeClass('input--has-value');
        var labelText = $(this).find('.label-visible');
            labelText.text(labelText.data('text'));
    });
    if (getCurrentSection() == "talk-to-us" &&  $('#main-header').hasClass("modal--is-open")) {
        $(".parallax--bg-fixed").css('z-index', '0');
    };
}


/* Form validations */
var error = false;
function formValidation(formID) {

    errorsArray = []
    var emailRegex = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    var textError = 'Please, fill in this field';
    var emailError = 'This is not a valid email address :(';

    $('.required', $('#' + formID)).each(function() {
        var elemValue = $(this).val();
        var parentInput = $(this).parent('.input--holder');

        if ($(this).hasClass('field-text')) {
            if ((elemValue.length == 0) || (elemValue.length == null) || (elemValue == ' ')) {
                    changeStateError(parentInput, $(this), textError);
                    error = true;
            } else {
                error = false;
            }
            errorsArray.push(error);
        }
        if ($(this).hasClass('field-email')) {
            if ((elemValue.length == 0) || (elemValue.length == null) || (elemValue == ' ')) {
                changeStateError(parentInput, $(this), emailError);
                error = true;
            } else if (!emailRegex.test(elemValue)) {
                changeStateError(parentInput, $(this), emailError);
                parentInput.addClass('input--has-value');
                $('.input--holder').find('.label-visible').removeClass('translate-email');
                error = true;
                $('.input--holder').find('.label-visible').removeClass('translate-email');
            } else {
                error = false;
                $('.input--holder').find('.label-visible').addClass('translate-email');
            }
            errorsArray.push(error);
        }
        if ($(this).hasClass('field-newsletter')) {
            if ((elemValue.length == 0) || (elemValue.length == null) || (elemValue == ' ') || (!emailRegex.test(elemValue))) {
                setTimeout(doShake(), 999);
                changeStateError(parentInput, $(this), textError);
                error = true;
            } else {
                error = false;
            }
            errorsArray.push(error);
        }
    });

    if ($.inArray(true, errorsArray) == -1) {
        return true;
    } else {
        return false;
    }
}

function changeStateError(parentInput, element, textError){
    parentInput.addClass('input--has-error');
    element.siblings('label').text(textError);
}

/* ==================================================================================================================== */
/*    ALL SECTIONS > Get the current page.                                                                              */
/* ==================================================================================================================== */

function getCurrentSection() {
    var currentSection = window.location.pathname.split('/').pop(); // returns the the current path
    switch (currentSection) {
        case '':
            return 'home';
        case 'about-us':
            return 'about-us';
        case 'services':
            return 'services';
        case 'our-work':
            return 'our-work';
        case 'careers':
            return 'careers';
        case 'talk-to-us':
            return 'talk-to-us';
        case '404':
            return '404';
    }
}

/* ==================================================================================================================== */
/*    SERVICES > Services switcher.                                                                                     */
/* ==================================================================================================================== */

function serviceSwitcher() {
    $('.service-bubble').click(function(event) {
        var service = $(this).data('description');

        $('.service-bubble').removeClass('active');
        $(this).addClass('active');

        $('.service-description').fadeOut('fast', function() {
            $(this).html(service).fadeIn('fast')
        });

        event.preventDefault();
    })
}


/* ==================================================================================================================== */
/*    SendMail
/* ==================================================================================================================== */
function SendMail(formID) {

        var evaluateValid = formValidation(formID);
        if (!evaluateValid) {
            return false;
        } else {

            $('#button_form_careers').prop('disabled', true);
            $('#button_form_talk_to_us').prop('disabled', true);
            $('#button_subscribe_newsletter').prop('disabled', true);



            var m_data = new FormData();
            m_data.append( 'full_name', $('input[name=full_name]').val());
            m_data.append( 'email', $('input[name=email]').val());
            m_data.append( 'ideas', $('textarea[name=ideas]').val());
            m_data.append( 'website_currentpage', $('input[name=website_currentpage]').val());
            if($('input[name=fileInput]').val()!=undefined)
            m_data.append( 'fileInput', $('input[name=fileInput]')[0].files[0]);
            $.ajax({
                type: 'POST',
                url: $('#' + formID).attr('action'),
                contentType: false,
                processData: false,
                data: m_data,

                success: function(response) {

                    $('#button_form_careers').prop('disabled', false);
                    $('#button_form_talk_to_us').prop('disabled', false);
                    $('#button_subscribe_newsletter').prop('disabled', false);
                    if(formID=="form-newsletter"){
                        $(".message-holder").remove();
                        var div = $("<div></div>",{'class':'message-holder'});
                        var icon = $("<span></span>",{'class':'icon-confirmation'});
                        var text = $("<p></p>",{"class":"message"}).text("Your message was sent succesfully");
                        div.append(icon,text);
                        $('#'+formID).after(div);
                        $('#'+formID).addClass("fade--out");
                        div.addClass("fade--in");
                        setTimeout(function(){
                                div.fadeOut(500,function(){
                                    location.hash = "#!";
                                    $('#'+formID).show();
                                    $("#"+formID).find(".input--holder").removeClass("input--has-value");
                                    div.removeClass("fade--in");
                                });
                                $('#'+formID).find("input").val("");
                                setTimeout(function(){
                                    $('#'+formID).removeClass("fade--out");
                                },500);
                        },2000);
                    }
                    else{
                        toggleModalContent(false);
                    }
                },
                error: function(result){
                    console.log("error");


                }
            });
        }

}




/* ==================================================================================================================== */
/*    Get Linkedin jobs and put in view                                                                                  */
/* ==================================================================================================================== */
 function getLinkedinJobIconClass(position_title){
    position_title = position_title.toLowerCase();

    if(position_title.match(".net")){
        return "icon-net-developer";
    }
    else if (position_title.match("ember")){
        return "icon-javascript-developer";
    }
    else if (position_title.match("node.js")){
        return "icon-javascript-developer";
    }
    else if (position_title.match("front-end")){
        return "icon-frontend-developer";
    }
    else if (position_title.match("stack")){
        return "icon-frontend-developer";
    }
    else if (position_title.match("ios")){
        return "icon-mobile-developer";
    }
    else if (position_title.match("mobile")){
        return "icon-mobile-developer";
    }
    else if (position_title.match("ui")){
        return "icon-ui-designer";
    }
    else if (position_title.match("ux")){
        return "icon-ux-designer";
    }
    else if (position_title.match("pm")){
        return "icon-pm";
    }
    else if (position_title.match("qa")){
        return "icon-qa-position";
    }
    else if (position_title.match(" ")){
        return "icon-generic-position";
    }
}


var positionName = "";
function getLinkedingJobs(){
    $.ajax({
            url: "subscribe/jobs.json",
            //force to handle it as text
            dataType: "text",
            success: function(data) {

                //convert text in json format
                var str = "[" + data + "]";
                var str = str.replace(/}{/g, "},{");
                var json = $.parseJSON(str);
                //let's display a few items

                var container = $(".positions--holder");
                container.empty();
                $.each(json, function(index, item) {
                    if (index < 3) {
                        var column = $("<div></div>", {"class": "position--block block-up"});
                    }else{
                        var column = $("<div></div>", {"class": "position--block block-down"});
                    }
                    var header = $("<header></header>");
                    var icon = $("<div></div>", {"class": getLinkedinJobIconClass(item.position_title)});
                    var positionTitle = $("<h3></h3>").text(item.position_title);
                    var location = $("<p></p>",{"class":"text--location"}).text(item.location);
                    var description = $("<p></p>",{"class":"text--small"});
                    if (item.description.length > 220) {
                        var str = item.description.substr(0, 220);
                        str += "...";
                        description.text(str);
                    }
                    else {
                        description.text(item.description);
                    }
                    var link = $("<a></a>", {"href": "#apply-to-position", "role":"button", "class":"button button--secondary button--dark button--small position--do-apply positionName"}).text("Apply now");
                    header.append(icon,positionTitle,location);
                    column.append(header, description, link);
                    container.append(column);
                    if (index == 2) {
                        var layerClear = $("<div></div>",{"class":"clear-layer"});
                        $('.positions--holder').append(layerClear);
                    };

                })
                $(".positionName").click(function() {
                    positionName = $(this).siblings('header').find('h3').text();
                    $("#subjectPosition").val(positionName);

                });
                //doExternalLinks();
            },
            error: function(error) {
                //console.log("error");
            }
        });
}
/* ==================================================================================================================== */
/*    Upload file                                                                                                       */
/* ==================================================================================================================== */
function uploadFile(){
    function cleanData(){
        $(".fileInfo-container").hide();
        $(".progress-bar").removeAttr("style");
        fileNameSpan.removeClass("error").text("");
        fileInput.val("");
    }
    var attachResume = $("#attach-resume");
    var fileInput = $('#fileInput');

    var fileNameSpan = $("#filename");
    attachResume.click(function(){
        $(this).hide();
        $(".dragAndDrop-container").css("display","table");
    });
    $("#cancel").click(function(){
        $(".dragAndDrop-container").show();
        cleanData();
    })
    $("#closeUpload").click(function(){
        $(".dragAndDrop-container").hide();
        attachResume.css("display","inline-block");
        cleanData();
    });


    $(".icon-close").click(function() {
        $(".dragAndDrop-container").css('display', 'none');
        $("#attach-resume").css('display', 'inline-block');
        cleanData();
    });

    fileInput.change(function(e) {
        var file = this.files ? this.files[0] : [];
        var fileStringArray = file.name.split(".");
        var fileExtension = fileStringArray[fileStringArray.length-1];
        var allowedExtensions = ['doc', 'docx', 'txt', 'pdf', 'rtf'];
        var fileSize = (file.size / 1024).toFixed(2);
        $(".dragAndDrop-container").hide();
        $(".fileInfo-container").css("display","inline-block");
        if (allowedExtensions.indexOf(fileExtension) === -1 || fileSize > 10240) {
            fileNameSpan.addClass("error").text("Invalid file format");
        } else {

            $(".progress").show();
            fileNameSpan.text(file.name);
            $('.progress .progress-bar').animate({
                    width: "100%"
            }, "slow", function() {
                setTimeout(function() {
                    $(".progress").hide();
                    $(".progress-bar").removeAttr("style");
                }, 1000);
            });

        }
    });
}
/* ==================================================================================================================== */
/*    ALL SECTIONS > Subscribe Newsletter                                                                             */
/* ==================================================================================================================== */
function susbscribeNewsletter(){
    if(location.hash=="#subscribe-newsletter"){
        focusOnElement($("#form-newsletter #email"),3000);
    }
    $("#subscribe-news-button").click(function(){
        focusOnElement($("#form-newsletter #email"),200);
    });

    $("#button_subscribe_newsletter").click(function(){
        SendMail("form-newsletter");
    });


}

/* ==================================================================================================================== */
/*    ALL SECTIONS > General functions                                                                             */
/* ==================================================================================================================== */
function doExternalLinks() {
    $('a[rel="external"]').on('click', function () {
        $(this).attr({'target':'_blank'});
    });
}
/* ==================================================================================================================== */
/*    ALL SECTIONS > Focus on element                                                                             */
/* ==================================================================================================================== */
function focusOnElement(element,time){
    setTimeout(function(){$(element).focus();},time);
}
function obtainLatLong() {
    analyzedRegion(37.4441171, -122.161044); //Default Set Palo Alto Office

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        //x.innerHTML = "Geolocation is not supported by this browser.";
    }

    function showPosition(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;
        analyzedRegion(latitude, longitude);

        //Para testear descomentar todas estas lineas.

        //analyzedRegion(-34.711452, -58.475662);  //Bs. As.
        //analyzedRegion(-36.548633, -66.557753);  //Resto de Argentina
        //analyzedRegion(-37.343237, -59.150221);  //Tandil

        //analyzedRegion(11.315094, 10.409347);  //Europa
        //analyzedRegion(27.180774, -106.347616);  //Mexico
        //analyzedRegion(-13.099541, -72.237362);  //Perú
        //analyzedRegion(56.817415, -108.597161);  //Canadá

        //analyzedRegion(42.332919, -71.078443);  //Boston
        //analyzedRegion(30.240785, -97.569086);  //Austin
        //analyzedRegion(28.206445, -99.587258);  //Limite derecho Mexico
        //analyzedRegion(42.616336, -96.600852); //Nebraska
        //analyzedRegion(32.285391, -83.812982); //Georgia
        //analyzedRegion(46.014574, -93.931824); //Minnesota
        //analyzedRegion(36.659111, -108.226202); //Albuquerque
        //analyzedRegion(30.309291, -102.980756); //Limite centro mexico EEUU
        //analyzedRegion(31.899354, -110.304116); //limite izquierdo mex EEUU
    }
  }

  function analyzedRegion(latitude, longitude) {
    //(((((((((((((((((((((   EUROPA   )))))))))))))))))))))
        if (longitude >= -30 ) {
            getOfficeInfo("palo-alto");
            return;
        }
        // ************ Fin Europa
        //((((((((((((((((((((((((  AFUERA DE ARGENTINA  ))))))))))))))))))))))))

        //   ********** MEXICO y SUR de EE UU **************
        if (latitude >= 14.596833 && latitude <= 32.680716
            && longitude <= -86.724688 && longitude >= -115.276777) {   //delimito todo mexico

            if (latitude >= 26.109020 && latitude <= 33.131055
                && longitude <= -91.752729 && longitude >= -100.541792) { //delimito el sur de EE UU y el norte de mexico (lado derecho)
                if (latitude >= 29.862450 && latitude <= 30.949710
                    && longitude <= -96.812757 && longitude >= -98.352217) { // Dentro de ese límite se encuentra Austin
                    getOfficeInfo("austin");
                    return;
                }
                getOfficeInfo("san-antonio");
                return;
            }
            else if ((latitude >= 29.872028 && latitude <= 33.131055
                && longitude <= -100.541792 && longitude >= -106.232710) ||
                (latitude >= 31.806035 && latitude <= 33.131055
                && longitude <= -106.232710 && longitude >= -113.116616 )) {
                getOfficeInfo("san-antonio");
                return;
            }
            getOfficeInfo("mexico-city");
            return;
        }
        //   **********  FIN MEXICO y SUR de EE UU **************
        if (latitude >= 39.758676 && latitude <= 42.941097
            && longitude <= -69.284925 && longitude >= -75.964613) {
            getOfficeInfo("boston");
            return;
        }

        getOfficeInfo("palo-alto");

        //((((((((((((((((  de méxico para abajo  ))))))))))))))))

        if (latitude >= -55.780828 && latitude <= 17.870501
            && longitude <= -30.559980 && longitude >=  -122.317793) {

            //(((((((((((( Delimita todo el territorio Argentino ))))))))))))
            if (latitude <= -21.789556 && latitude >= -55.050660
                && longitude <= -53.332383 && longitude >= -73.810899) {
                //(((((((((((((((((((  Interior de Argentina  )))))))))))))))))))
                if (latitude <= -34.299123 && latitude >= -35.196588
                    && longitude <= -58.087070 && longitude >= -58.891819) {
                    getOfficeInfo("buenos-aires");
                    return;
                }
                if (latitude <= -37.274667 && latitude >= -37.362039
                    && longitude <= -59.066470 && longitude >= -59.205859) {
                    getOfficeInfo("tandil");
                    return;
                }
                getOfficeInfo("mar-del-plata");
                return;
            }
            getOfficeInfo("buenos-aires");
        }
    };
