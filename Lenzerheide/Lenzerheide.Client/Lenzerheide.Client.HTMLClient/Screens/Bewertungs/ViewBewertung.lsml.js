/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewBewertung.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Bewertung.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Bewertung." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

