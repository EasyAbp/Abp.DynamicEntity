using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos
{
    public class PermissionSetDto : IPermissionSet
    {
        public string Get { get; set; }
        
        public string GetList { get; set; }
        
        public string Create { get; set; }
        
        public string Update { get; set; }
        
        public string Delete { get; set; }
        
        public string Manage { get; set; }
        
        public bool AnonymousGet { get; set; }
        
        public bool AnonymousGetList { get; set; }

        public bool AnonymousCreate { get; set; }
        
        public bool AnonymousUpdate { get; set; }
        
        public bool AnonymousDelete { get; set; }

        public IEnumerable<string> GetPermissionNames()
        {
            return new List<string>()
            {
                Get, GetList, Create, Update, Delete, Manage
            }.Where(x => !x.IsNullOrWhiteSpace()).Distinct().ToList();
        }
    }
}