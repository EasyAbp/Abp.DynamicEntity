(function ($) {

    abp.modals.CreateEditModal = function () {
        const initModal = function (publicApi, args) {
            const l = abp.localization.getResource('Dynamic');

            $("select").select2({
                width: "100%",
                language: {
                    noResults: function () {
                        return l("NoAvailableFields")
                    }
                }
            });

            orderSortedValues = function () {
                $("ul.select2-selection__rendered").children("li[title]").each(function (i, option) {
                    const element = $("#ViewModel_FieldIds").children(`option:contains('${option.title}')`);
                    moveElementToEndOfParent(element)
                });
            };

            moveElementToEndOfParent = function (element) {
                const parent = element.parent();

                element.detach();

                parent.append(element);
            };

            $("ul.select2-selection__rendered").sortable({
                containment: 'parent',
                update: function () {
                    debugger;
                    orderSortedValues();
                }
            });
        };

        return {
            initModal: initModal
        };
    }
})(jQuery);