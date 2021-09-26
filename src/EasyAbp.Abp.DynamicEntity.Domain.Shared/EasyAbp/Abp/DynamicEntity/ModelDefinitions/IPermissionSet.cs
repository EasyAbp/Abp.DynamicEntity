using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public interface IPermissionSet
    {
        [CanBeNull]
        public string Get { get; }
        
        [CanBeNull]
        public string GetList { get; }

        [CanBeNull]
        public string Create { get; }
        
        [CanBeNull]
        public string Update { get; }
        
        [CanBeNull]
        public string Delete { get; }
        
        [CanBeNull]
        public string Manage { get; }
    }
}