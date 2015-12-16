

$( "#right_nav li" ).click(function() {
	$("#right_nav li").removeClass( "active" );
	$("#right_nav li").addClass( "non_active" );
  $( this).addClass( "active" );
});

$(function() {

  $(window).scroll(function() {   
  	
  	//alert(window.pageYOffset );
  	if(window.pageYOffset > 220){
  		$('.go_up').css('display','block');
  		
  	}else{
  	    $('.go_up').css('display','none');
  	}
  })
});


$(function () {
    $('.top_img3_img_lang').click(function lang() {
        console.log(window.location.href);
        window.location.href += '?lang=' + lng;
    });

    $(window).scroll(function () {

       
        if (window.pageYOffset > 200) {
            $('#left_section').removeClass("nav_static").addClass("nav_fixed");
            $('#itemsContainer').css('margin-left', '200px');

        } else {
            $('#left_section').removeClass("nav_fixed").addClass("nav_static");
            $('#div_none').css('display', 'none');
        }
    })
});