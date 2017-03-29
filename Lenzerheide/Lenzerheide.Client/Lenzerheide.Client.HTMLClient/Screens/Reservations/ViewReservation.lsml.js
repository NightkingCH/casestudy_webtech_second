/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewReservation.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Reservation.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Reservation." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

