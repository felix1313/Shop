

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
})});