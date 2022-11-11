using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
   // [Authorize(Roles = UserRoles.Admin)]
    public class ParticipantsController : Controller
    {
        private readonly IParticipantsService _service;

        public ParticipantsController(IParticipantsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Participants/Create
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Participant Participant)
        {
            if (!ModelState.IsValid)
            {
                return View(Participant);
            }
            await _service.AddAsync(Participant);
            return RedirectToAction(nameof(Index));
        }

        //Get: Participants/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ParticipantDetails = await _service.GetByIdAsync(id);

            if (ParticipantDetails == null) return View("NotFound");
            return View(ParticipantDetails);
        }

        //Get: Participants/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ParticipantDetails = await _service.GetByIdAsync(id);
            if (ParticipantDetails == null) return View("NotFound");
            return View(ParticipantDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Participant Participant)
        {
            if (!ModelState.IsValid)
            {
                return View(Participant);
            }
            await _service.UpdateAsync(id, Participant);
            return RedirectToAction(nameof(Index));
        }

        //Get: Participants/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var ParticipantDetails = await _service.GetByIdAsync(id);
            if (ParticipantDetails == null) return View("NotFound");
            return View(ParticipantDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ParticipantDetails = await _service.GetByIdAsync(id);
            if (ParticipantDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
