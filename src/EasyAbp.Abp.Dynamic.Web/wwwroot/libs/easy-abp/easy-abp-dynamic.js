var easyAbp = easyAbp || {};
(function () {
    easyAbp.abp = easyAbp.abp || {};
    easyAbp.abp.dynamicUI = easyAbp.abp.dynamicUI || {};

    easyAbp.abp.dynamicUI.configureDataTable = function (dynamicOption, dataTableOption) {
        const modelName = dynamicOption.modelName;
        const $table = dynamicOption.$table

        const l = abp.localization.getResource('Dynamic');

        const svcDynamicEntity = easyAbp.abp.dynamic.dynamicEntities.dynamicEntity;
        const svcModelDefinition = easyAbp.abp.dynamic.modelDefinitions.modelDefinition;

        let dataTable = null;

        svcModelDefinition.getByName(modelName).done(function (model) {
            abp.ui.extensions.entityActions.get(model.type).addContributor(
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
                                title: l(field.name),
                                name: field.name,
                                data: `extraProperties.${field.name}`,
                            }
                        })
                    );
                },
                0 //adds as the first contributor
            );

            let defaultTableOption = {
                processing: true,
                serverSide: true,
                paging: true,
                searching: true,
                autoWidth: false,
                scrollCollapse: true,
                order: [[0, "asc"]],
                ajax: abp.libs.datatables.createAjax(svcDynamicEntity.getList, function (requestData) {
                    const fieldFilters = {};
                    for (let i = 0; i < requestData.columns.length; i++) {
                        if (!requestData.columns[i].search.value) continue;
                        fieldFilters[requestData.columns[i].name] = requestData.columns[i].search.value;
                    }
                    return {
                        fieldFilters: fieldFilters
                    }
                }),
                columnDefs: abp.ui.extensions.tableColumns.get(model.type).columns.toArray(),
            };

            dataTable = $table.DataTable(abp.libs.datatables.normalizeConfiguration({
                ...defaultTableOption,
                ...dataTableOption
            }));
        });
    }
})();