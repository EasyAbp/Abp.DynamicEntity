using System.ComponentModel.DataAnnotations;
using DynamicSample.Computers;

namespace DynamicSample.Web.Pages.Computers.Computer.ViewModels
{
    public class CreateEditComputerViewModel
    {
        [Display(Name = "ComputerComputerType")]
        public ComputerType ComputerType { get; set; }

        [Display(Name = "ComputerPrice")]
        public float Price { get; set; }
    }
}