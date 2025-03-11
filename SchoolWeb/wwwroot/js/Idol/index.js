$(document).ready(function () {
  let counter = 1;
  const idolIdToRemoveIds = [];

  $(".idol .image-container img").click(function () {
    // after user click on image

    $(".idol .image-container img").removeClass("active");
    $(this).addClass("active");
  });

  $(".user-with-idol-ages").click(() => {
    console.log(++counter);
  });

  $(".soft-remove").click(function () {
    const idolTag = $(this).closest(".idol");
    idolTag.addClass("to-remove");
    const idolId = idolTag.attr("data-id");
    idolIdToRemoveIds.push(idolId);
    console.log(idolIdToRemoveIds);
  });

  $(".remove-all-selected-button").click(function () {
    const str = idolIdToRemoveIds.join(",");
    $("[name=idsToRemove]").val(str);
  });

  $(".view-mode").click(function () {
    const viewModeContainer = $(this);
    viewModeContainer.hide();
    const oldName = viewModeContainer.text().trim();
    const updateModeContainer = $(this).parent().find(".update-mode");
    updateModeContainer.show();
    updateModeContainer.find(".new-name").val(oldName);
  });

  $(".close").click(function () {
    const updateModeContainer = $(this).closest(".update-mode");
    updateModeContainer.hide();
    updateModeContainer.parent().find(".view-mode").show();
  });

  $(".update-mode .update").click(function () {
    const id = $(this).closest(".idol").attr("data-id");
    const newName = $(this).closest(".update-mode").find(".new-name").val();
    const url = `/api/idol/UpdateName?id=${id}&newName=${newName}`;
    $.get(url);

    const updateModeContainer = $(this).closest(".update-mode");
    updateModeContainer.hide();
    const viewModeContainer = updateModeContainer.parent().find(".view-mode");
    viewModeContainer.text(newName);
    viewModeContainer.show();
  });

  $(".ajax-remove").click(function () {
    if (confirm("Are you sure?")) {
      const idol = $(this).closest(".idol");
      const id = idol.attr("data-id");
      idol.remove();

      $.get("/api/idol/remove?id=" + id);
    }
  });

  $(".new-image").on("keyup", function () {
    const newImage = $(this).val();
    $(this).closest(".idol").find(".image-container img").attr("src", newImage);
  });

  $(".create").click(function () {
    const newNameTag = $(this).closest(".idol").find(".new-name");
    const newImageTag = $(this).closest(".idol").find(".new-image");
    const name = newNameTag.val();
    const image = newImageTag.val();
    const idol = {
      Name: name,
      Src: image,
    };
    $.post("/api/idol/create", idol).then(function (id) {
      const clone = $(".idol.template").clone();
      clone.removeClass("template");
      clone.attr("data-id", id);
      clone.find(".name .view-mode").text(name);
      clone.find(".image-container img").attr("src", image);
      clone.insertBefore($(".create-container"));

	  newNameTag.val('');
	  newImageTag.val('');
	  newImageTag.closest('.idol').find('.image-container img').attr('src', '');
    });
  });
});
