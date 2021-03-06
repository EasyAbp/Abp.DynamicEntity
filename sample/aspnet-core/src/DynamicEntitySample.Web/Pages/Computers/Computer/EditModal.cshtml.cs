﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicEntitySample.Web.Pages.Computers.Computer.ViewModels;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;

namespace DynamicEntitySample.Web.Pages.Computers.Computer
{
    public class EditModalModel : DynamicEntitySamplePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditComputerViewModel ViewModel { get; set; }

        private readonly IDynamicEntityAppService _service;

        public EditModalModel(IDynamicEntityAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            /*var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ComputerDto, CreateEditComputerViewModel>(dto);*/
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            /*var dto = ObjectMapper.Map<CreateEditComputerViewModel, CreateUpdateComputerDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);*/
            return NoContent();
        }
    }
}