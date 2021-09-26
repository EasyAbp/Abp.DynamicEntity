using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Values;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class PermissionSetValueObject : ValueObject, IPermissionSet
    {
        public virtual string Get { get; private set; }
        
        public virtual string GetList { get; private set; }

        public virtual string Create { get; private set; }
        
        public virtual string Update { get; private set; }
        
        public virtual string Delete { get; private set; }
        
        public virtual string Manage { get; private set; }
        
        public virtual bool AnonymousGet { get; private set; }
        
        public virtual bool AnonymousGetList { get; private set; }

        public virtual bool AnonymousCreate { get; private set; }
        
        public virtual bool AnonymousUpdate { get; private set; }
        
        public virtual bool AnonymousDelete { get; private set; }

        protected PermissionSetValueObject()
        {
        }

        public PermissionSetValueObject(
            [CanBeNull] string get = null,
            [CanBeNull] string getList = null,
            [CanBeNull] string create = null,
            [CanBeNull] string update = null,
            [CanBeNull] string delete = null,
            [CanBeNull] string manage = null,
            bool anonymousGet = false,
            bool anonymousGetList = false,
            bool anonymousCreate = false,
            bool anonymousUpdate = false,
            bool anonymousDelete = false)
        {
            Get = get;
            GetList = getList;
            Create = create;
            Update = update;
            Delete = delete;
            Manage = manage;
            AnonymousGet = anonymousGet;
            AnonymousGetList = anonymousGetList;
            AnonymousCreate = anonymousCreate;
            AnonymousUpdate = anonymousUpdate;
            AnonymousDelete = anonymousDelete;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Get;
            yield return GetList;
            yield return Create;
            yield return Update;
            yield return Delete;
            yield return Manage;
            yield return AnonymousGet;
            yield return AnonymousGetList;
            yield return AnonymousCreate;
            yield return AnonymousUpdate;
            yield return AnonymousDelete;
        }
    }
}