using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
   // [Authorize(Roles = UserRoles.Admin)]
    public class LocationsController : Controller
    {
        private readonly ILocationsService _service;

        public LocationsController(ILocationsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allLocations = await _service.GetAllAsync();
            return View(allLocations);
        }


        //Get: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,AddressLine,City,State,ZipCode,Country,Description")] Location Location)
        {
            if (!ModelState.IsValid) return View(Location);
            await _service.AddAsync(Location);
            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var LocationDetails = await _service.GetByIdAsync(id);
            if (LocationDetails == null) return View("NotFound");
            return View(LocationDetails);
        }

        //Get: Locations/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var LocationDetails = await _service.GetByIdAsync(id);
            if (LocationDetails == null) return View("NotFound");
            return View(LocationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,AddressLine,City,State,ZipCode,Country,Description")] Location Location)
        {
            if (!ModelState.IsValid) return View(Location);
            await _service.UpdateAsync(id, Location);
            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var LocationDetails = await _service.GetByIdAsync(id);
            if (LocationDetails == null) return View("NotFound");
            return View(LocationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var LocationDetails = await _service.GetByIdAsync(id);
            if (LocationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
