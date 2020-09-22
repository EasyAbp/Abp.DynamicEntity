$(function () {

    const l = abp.localization.getResource('DynamicEntitySample');

    var createModal = new abp.ModalManager(abp.appPath + 'Computers/Computer/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Computers/Computer/EditModal');

    easyAbp.abp.dynamicUI.configureDataTable(
        {
            modelName: "computer",
            $table: $("#ComputerTable")
        },
        {
            ordering: false,
            initComplete: function () {
                // Setup - add a text input to each header cell
                $('table:eq(0) thead th').each(function () {
                    var title = $(this).text();
                    $(this).append(`<input type="text" class="form-control form-control-sm" placeholder="${l('Search')} ${title}" />`)
                    ;
                });

                // Apply the search
                this.api().columns().every(function () {
                    var that = this;

                    $("input", this.header()).on('keyup change clear', function () {
                        if (that.search() !== this.value) {
                            that
                                .search(this.value)
                                .draw();
                        }
                    });
                });
            },
        },
        function (requestData) {
            const filterGroup = {
                type: 0,
                conditions: []
            }
            for (let i = 0; i < requestData.columns.length; i++) {
                if (!requestData.columns[i].search.value) continue;
                filterGroup.conditions.push({
                    fieldName: requestData.columns[i].name,
                    operator: 10,   // contain
                    value: requestData.columns[i].search.value
                })
            }
            return {
                filterGroup: filterGroup
            }
        }
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewComputerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});