﻿using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Address
{
    public class DetailsModel : PageModel
    {
        private readonly IAddressService _addressService;

        public DetailsModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Core.Models.Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Address = await _addressService.Get(address => address.Id == id.Value);

            if (Address == null) return NotFound();
            return Page();
        }
    }
}