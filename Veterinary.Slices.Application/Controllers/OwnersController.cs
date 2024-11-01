using MediatR;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Slices.Application.Features.Owners.CreateOwner;
using Veterinary.Slices.Application.Models.Owner;

namespace Veterinary.Slices.Application.Controllers
{
    [Route("/owners")]
    public class OwnersController : Controller
    {
        private readonly ISender _mediatrSender;

        public OwnersController(ISender sender)
        {
            this._mediatrSender = sender;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] CreateOwnerViewmodel owner)
        {
            if (ModelState.IsValid)
            {
                CreateOwnerCommand command = new CreateOwnerCommand()
                {
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    PhoneNumber = owner.PhoneNumber!.ToString()!,
                    Identification = owner.Identification.ToString(),
                    AlternativePhoneNumber = owner.AlternativePhoneNumber?.ToString(),
                };
                var result = await this._mediatrSender.Send(command);
                if (result.IsFailed)
                {
                    return StatusCode(500);
                }
                else
                {
                   return RedirectToAction("Index", "Home"); 
                }
            }
            else
            {
                return View();
            }
        }
    }
}