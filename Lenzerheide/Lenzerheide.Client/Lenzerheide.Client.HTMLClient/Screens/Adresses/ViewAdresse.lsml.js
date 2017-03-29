/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewAdresse.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Adresse.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Adresse." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

