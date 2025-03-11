$(document).ready(function () {
	$('[name="Name"]').on( "keyup", function(){
		const currentName = $('[name="Name"]').val();
		$('.idol .name').text(currentName);
	});

	$('[name="Src"]').on( "keyup", function(){
		const currentSrc = $('[name="Src"]').val();
		$('.idol .image-container img').attr('src', currentSrc);
	})
});
