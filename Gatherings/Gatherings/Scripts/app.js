var $overlay = $('<div id="overlay"></div>');
var $signUpForm = $("#signUpForm .container");
var $closeLogin = $(".closeLogin")

//add signup form
$overlay.append($signUpForm);
//add Overlay


$("body").append($overlay);
	
//click event to signUp
$("#signUp a").click(function(event){
	event.preventDefault();
	//update to show sign-in form
	$signUpForm.show();
	//show Overlay
	$overlay.show();
});

//click event to signUp
$("#register a").click(function (event) {
    event.preventDefault();
    //update to show sign-in form
    $('#signupbox').show();
    //show Overlay
    $overlay.show();
});


//$overlay.click(function(){
	//hide overlay
	//$overlay.hide();
	//$signUpForm.hide();
//});

$closeLogin.click(function(){
	//hide overlay
	$overlay.hide();
	$signUpForm.hide();
});




