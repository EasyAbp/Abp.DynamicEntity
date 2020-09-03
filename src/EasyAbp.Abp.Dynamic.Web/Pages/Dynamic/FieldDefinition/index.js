$(function () {

    var l = abp.localization.getResource('Dynamic');

    var service = easyAbp.abp.dynamic.fieldDefinitions.fieldDefinition;
    var createModal = new abp.ModalManager(abp.appPath + 'Dynamic/FieldDefinition/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dynamic/FieldDefinition/EditModal');

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
                                visible: abp.auth.isGranted('Dynamic.FieldDefinition.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dynamic.FieldDefinition.Delete'),
                                confirmMessage: function (data) {
                                    return l('FieldDefinitionDeletionConfirmationMessage', data.record.id);
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
            { data: "type" },
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