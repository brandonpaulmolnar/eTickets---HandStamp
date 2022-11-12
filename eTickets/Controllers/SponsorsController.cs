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
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
    public class SponsorsController : Controller
    {
        private readonly ISponsorsService _service;

        public SponsorsController(ISponsorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allSponsors = await _service.GetAllAsync();
            return View(allSponsors);
        }

        //GET: Sponsors/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var SponsorDetails = await _service.GetByIdAsync(id);
            if (SponsorDetails == null) return View("NotFound");
            return View(SponsorDetails);
        }

        //GET: Sponsors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Sponsor Sponsor)
        {

            if (!ModelState.IsValid)
            {
                View(Sponsor);
                
            }
            await _service.AddAsync(Sponsor);
            return RedirectToAction(nameof(Index));
        }

        //GET: Sponsors/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var SponsorDetails = await _service.GetByIdAsync(id);
            if (SponsorDetails == null) return View("NotFound");
            return View(SponsorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Sponsor Sponsor)
        {
            if (!ModelState.IsValid) return View(Sponsor);

            if(id == Sponsor.Id)
            {
                await _service.UpdateAsync(id, Sponsor);
                return RedirectToAction(nameof(Index));
            }
            return View(Sponsor);
        }

        //GET: Sponsors/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var SponsorDetails = await _service.GetByIdAsync(id);
            if (SponsorDetails == null) return View("NotFound");
            return View(SponsorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var SponsorDetails = await _service.GetByIdAsync(id);
            if (SponsorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
