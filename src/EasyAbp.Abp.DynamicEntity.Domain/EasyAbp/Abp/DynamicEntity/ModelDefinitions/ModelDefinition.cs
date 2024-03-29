﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Validation;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class ModelDefinition : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string DisplayName { get; protected set; }

        [NotNull]
        public virtual string Type { get; protected set; }

        public virtual List<ModelField> Fields { get; protected set; } = new();

        public virtual PermissionSetValueObject PermissionSet { get; protected set; }
        
        protected ModelDefinition()
        {
        }

        public ModelDefinition(
            Guid id,
            [NotNull] string name,
            [NotNull] string displayName,
            [NotNull] string type,
            PermissionSetValueObject permissionSet
        ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(Name), ModelDefinitionConsts.MaxNameLength);
            DisplayName = Check.NotNullOrWhiteSpace(displayName, nameof(displayName), ModelDefinitionConsts.MaxDisplayNameLength);
            Type = Check.NotNullOrWhiteSpace(type, nameof(Type), ModelDefinitionConsts.MaxTypeLength);;
            PermissionSet = permissionSet ?? new PermissionSetValueObject();

            CheckName();
        }

        private void CheckName()
        {
            if (!Regex.IsMatch(Name, @"^[a-zA-Z_]\w*(\.[a-zA-Z_]\w*)*$"))
            {
                throw new AbpValidationException("Invalid entity name.");
            }
        }

        public void AddField(FieldDefinition fieldDefinition, int order = int.MaxValue)
        {
            Fields.Add(new ModelField(Id, fieldDefinition, order));
        }

        public void RemoveField(Guid fieldDefinitionId)
        {
            Fields.RemoveAll(f => f.FieldDefinitionId == fieldDefinitionId);
        }
        
        public void SetPermissionSet(PermissionSetValueObject permissionSet)
        {
            PermissionSet = permissionSet;
        }
    }
}