using System;

using System.ComponentModel.DataAnnotations;

namespace DynamicSample.Web.Pages.Computers.Computer.ViewModels
{
    public class CreateEditComputerViewModel
    {
        [Display(Name = "ComputerMyProperty")]
        public int MyProperty { get; set; }
    }
}