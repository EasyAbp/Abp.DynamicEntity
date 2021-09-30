using System.ComponentModel.DataAnnotations;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition.ViewModels
{
    public class EditPermissionSetViewModel : IPermissionSet
    {
        [Display(Name = "PermissionSet.Get")]
        public string Get { get; set; }
        
        [Display(Name = "PermissionSet.GetList")]
        public string GetList { get; set; }
        
        [Display(Name = "PermissionSet.Create")]
        public string Create { get; set; }
        
        [Display(Name = "PermissionSet.Update")]
        public string Update { get; set; }
        
        [Display(Name = "PermissionSet.Delete")]
        public string Delete { get; set; }

        [Display(Name = "PermissionSet.Manage")]
        public string Manage { get; set; }
        
        [Display(Name = "PermissionSet.AnonymousGet")]
        public bool AnonymousGet { get; set; }
        
        [Display(Name = "PermissionSet.AnonymousGetList")]
        public bool AnonymousGetList { get; set; }
        
        [Display(Name = "PermissionSet.AnonymousCreate")]
        public bool AnonymousCreate { get; set; }
        
        [Display(Name = "PermissionSet.AnonymousUpdate")]
        public bool AnonymousUpdate { get; set; }
        
        [Display(Name = "PermissionSet.AnonymousDelete")]
        public bool AnonymousDelete { get; set; }
    }
}