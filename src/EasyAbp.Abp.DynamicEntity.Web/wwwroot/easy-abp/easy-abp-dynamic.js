﻿var easyAbp = easyAbp || {};
(function () {
    easyAbp.abp = easyAbp.abp || {};
    easyAbp.abp.dynamicUI = easyAbp.abp.dynamicUI || {};

    /**
     * Configure dataTables for dynamic entity
     * @param dynamicOption 
     * @param dataTableOption
     * @param filterCallback
     */
    easyAbp.abp.dynamicUI.configureDataTable = function (dynamicOption, dataTableOption, filterCallback) {
        const modelName = dynamicOption.modelName;
        const $table = dynamicOption.$table

        const l = abp.localization.getResource('EasyAbpAbpDynamicEntity');

        const svcDynamicEntity = easyAbp.abp.dynamicEntity.dynamicEntities.dynamicEntity;
        const svcModelDefinition = easyAbp.abp.dynamicEntity.modelDefinitions.modelDefinition;

        let dataTable = null;

        svcModelDefinition.getByName(modelName).done(function (model) {
            abp.ui.extensions.entityActions.get(model.type).addContributor(
                function (actionList) {
                    return actionList.addManyTail(
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicEntity.DynamicEntity.Update'),
                                action: function (data) {
                                    editModal.open({
                                        id: data.record.id,
                                    });
                                },
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicEntity.DynamicEntity.Delete'),
                                confirmMessage: function (data) {
                                    return l(
                                        'DynamicEntityDeletionConfirmationMessage',
                                        model.name
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

            abp.ui.extensions.tableColumns.get(model.type).addContributor(
                function (columnList) {
                    columnList.addTail({
                        title: l("Actions"),
                        rowAction: {
                            items: abp.ui.extensions.entityActions.get(model.type).actions.toArray()
                        }
                    },)
                    columnList.addManyTail(model.fields.map(function (field) {
                            return {
                                title: field.displayName,
                                name: field.name,
                                data: `extraProperties.${field.name}`,
                                defaultContent: "-"
                            }
                        })
                    );
                },
                0
            );

            let defaultTableOption = {
                processing: true,
                serverSide: true,
                paging: true,
                searching: true,
                autoWidth: true,
                scrollCollapse: true,
                //order: [[0, "asc"]],
                ajax: abp.libs.datatables.createAjax(svcDynamicEntity.getList, function (requestData) {
                    let input;
                    if (filterCallback) {
                        input = filterCallback(requestData);
                    } else {
                        input = {};
                    }
                    input.modelName = modelName
                    return input;
                }),
                columnDefs: abp.ui.extensions.tableColumns.get(model.type).columns.toArray(),
            };

            dataTable = $table.DataTable(abp.libs.datatables.normalizeConfiguration({
                ...defaultTableOption,
                ...dataTableOption
            }));
            
            dataTable.columns.adjust().draw();
        });
    }
})();