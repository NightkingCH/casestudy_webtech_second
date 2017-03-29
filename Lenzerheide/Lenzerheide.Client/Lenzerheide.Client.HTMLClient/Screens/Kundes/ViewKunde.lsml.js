/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewKunde.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Kunde.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Kunde." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

