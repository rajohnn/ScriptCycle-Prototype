Declare("arTemplate", {
    serverModel: null,
    model: null,
    vm: null,
    init: function () {
        if (arTemplate.serverModel) {
            arTemplate.model = ko.observable(ko.mapping.fromJS(arTemplate.serverModel));
        }
        arTemplate.vm = arTemplate.model();
        ko.applyBindings(arTemplate.model);
    }
});

$(function () {
    $(".html-editor").dxHtmlEditor({
        toolbar: {
            items: [
                "undo", "redo", "separator",
                {
                    formatName: "size",
                    formatValues: ["8pt", "10pt", "12pt", "14pt", "18pt", "24pt", "36pt"]
                },
                {
                    formatName: "font",
                    formatValues: ["Arial", "Courier New", "Georgia", "Impact", "Lucida Console", "Tahoma", "Times New Roman", "Verdana"]
                },
                "separator", "bold", "italic", "strike", "underline", "separator",
                "alignLeft", "alignCenter", "alignRight", "alignJustify", "separator",
                {
                    formatName: "header",
                    formatValues: [false, 1, 2, 3, 4, 5]
                }, "separator",
                "orderedList", "bulletList", "separator",
                "color", "background", "separator",
                "link", "image", "separator",
                "clear", "codeBlock", "blockquote"
            ]
        }
    });
    $("#invoice-tree").dxTreeView({
        dataSource: [
            { id: "1", text: "Current Templates" },
            { id: "1_1", text: "2018 MedOne HS", parentId: "1" },
            { id: "1_2", text: "2018 MedOne HS v2", parentId: "1" },
            { id: "2", text: "2017 Templates" },
            { id: "2_1", text: "2017 MedOne HS", parentId: "2" },
            { id: "2_2", text: "2017 MedOne HS v2", parentId: "2" }
        ],
        dataStructure: "plain"
    });
    $("#claim-tree").dxTreeView({
        dataSource: [
            { id: "1", text: "Current Detail Templates" },
            { id: "1_1", text: "MedOne Standard Claim Details", parentId: "1" },
            { id: "1_2", text: "Extended Claim Details", parentId: "1" },
            { id: "2", text: "2017 Templates" },
            { id: "2_1", text: "2017 MedOne Standard Claim Details", parentId: "2" },
            { id: "2_2", text: "2017 Extended Claim Details", parentId: "2" }
        ],
        dataStructure: "plain"
    });
});