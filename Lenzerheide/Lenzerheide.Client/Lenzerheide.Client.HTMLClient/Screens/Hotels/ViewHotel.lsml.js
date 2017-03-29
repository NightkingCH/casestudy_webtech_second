/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewHotel.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Hotel.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Hotel." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

