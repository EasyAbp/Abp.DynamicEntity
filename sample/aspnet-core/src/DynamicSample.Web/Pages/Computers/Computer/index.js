$(function () {

    var l = abp.localization.getResource('Dynamic');

    var svcDynamicEntity = easyAbp.abp.dynamic.dynamicEntities.dynamicEntity;
    var svcModelDefinition = easyAbp.abp.dynamic.modelDefinitions.modelDefinition;
    var createModal = new abp.ModalManager(abp.appPath + 'Computers/Computer/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Computers/Computer/EditModal');

    var dataTable;

    svcModelDefinition.getByName("Computer").done(function (result) {
        abp.ui.extensions.entityActions.get(result.type).addContributor(
            function (actionList) {
                return actionList.addManyTail(
                    [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('Dynamic.DynamicEntity.Update'),
                            action: function (data) {
                                editModal.open({
                                    id: data.record.id,
                                });
                            },
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('Dynamic.DynamicEntity.Delete'),
                            confirmMessage: function (data) {
                                return l(
                                    'DynamicEntityDeletionConfirmationMessage',
                                    result.name
                                );
                            },
                            action: function (data) {
                                svcDynamicEntity
                                    .delete(data.record.id)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();
                                    });
                            },
                        }
                    ]
                );
            }
        );

        abp.ui.extensions.tableColumns.get(result.type).addContributor(
            function (columnList) {
                columnList.addTail({
                    title: l("Actions"),
                    rowAction: {
                        items: abp.ui.extensions.entityActions.get(result.type).actions.toArray()
                    }
                },)
                columnList.addManyTail(result.fields.map(function (field) {
                        return {
                            title: field.name,
                            data: `extraProperties.${field.name}`,
                        }
                    })
                );
            },
            0 //adds as the first contributor
        );

        dataTable = $('#ComputerTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: true,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(svcDynamicEntity.getList),
            columnDefs: abp.ui.extensions.tableColumns.get(result.type).columns.toArray(),
        }));
    });

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