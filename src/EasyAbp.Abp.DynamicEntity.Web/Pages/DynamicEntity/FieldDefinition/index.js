$(function () {

    var l = abp.localization.getResource('DynamicEntity');

    var service = easyAbp.abp.dynamicEntity.fieldDefinitions.fieldDefinition;
    var createModal = new abp.ModalManager(abp.appPath + 'DynamicEntity/FieldDefinition/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'DynamicEntity/FieldDefinition/EditModal');

    var dataTable = $('#FieldDefinitionTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('DynamicEntity.FieldDefinition.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DynamicEntity.FieldDefinition.Delete'),
                                confirmMessage: function (data) {
                                    return l('FieldDefinitionDeletionConfirmationMessage', data.record.name);
                                },
                                action: function (data) {
                                        service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "name" },
            { data: "displayName" },
            { data: "type", render: function ( data, type, row, meta ) {
                switch (data) {
                    case 0:
                        return l("FieldDataType.Text");
                    case 1:
                        return l("FieldDataType.Number");
                    case 2:
                        return l("FieldDataType.Float");
                    case 3:
                        return l("FieldDataType.Boolean");
                    case 4:
                        return l("FieldDataType.DateTime");
                }
            }},
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewFieldDefinitionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});