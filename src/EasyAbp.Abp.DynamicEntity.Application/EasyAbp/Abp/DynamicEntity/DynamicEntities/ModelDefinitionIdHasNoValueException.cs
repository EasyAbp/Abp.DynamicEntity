using Volo.Abp;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class ModelDefinitionIdHasNoValueException : BusinessException
    {
        public ModelDefinitionIdHasNoValueException() : base("ModelDefinitionIdHasNoValue")
        {
            
        }
    }
}