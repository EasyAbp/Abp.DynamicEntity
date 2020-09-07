$(function () {

    var l = abp.localization.getResource('Dynamic');

    var service = easyAbp.abp.dynamic.modelDefinitions.modelDefinition;
    var createModal = new abp.ModalManager(
        {
            viewUrl: abp.appPath + 'Dynamic/ModelDefinition/CreateModal',
            scriptUrl: "/Pages/Dynamic/ModelDefinition/createEditModal.js",
            modalClass: "CreateEditModal",
        }
    );
    var editModal = new abp.ModalManager(
        {
            viewUrl: abp.appPath + 'Dynamic/ModelDefinition/EditModal',
            scriptUrl: "/Pages/Dynamic/ModelDefinition/createEditModal.js",
            modalClass: "CreateEditModal",
        }
    );

    var dataTable = $('#ModelDefinitionTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Dynamic.ModelDefinition.Update'),
                                action: function (data) {
                                    editModal.open({id: data.record.id});
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dynamic.ModelDefinition.Delete'),
                                confirmMessage: function (data) {
                                    return l('ModelDefinitionDeletionConfirmationMessage', data.record.name);
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
            {data: "name"},
            {data: "displayName"},
            {data: "type"},
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewModelDefinitionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});