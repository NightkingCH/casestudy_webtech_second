/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewZimmer.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Zimmer.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Zimmer." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

