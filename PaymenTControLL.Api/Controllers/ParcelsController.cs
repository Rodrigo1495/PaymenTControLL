using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymenTControLL.Api.Models;
using PaymenTControLL.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymenTControLL.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/parcels")]
    public class ParcelsController : ControllerBase
    {
        private readonly ParcelService _parcelService;
        public ParcelsController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public ActionResult<List<Parcel>> Get() =>
            _parcelService.Get();

        [HttpGet("{id:length(24)}", Name = "GetParcel")]
        public ActionResult<Parcel> Get(string id)
        {
            var parcel = _parcelService.Get(id);

            if (parcel == null)
            {
                return NotFound();
            }

            return parcel;
        }

        [HttpPost]
        public ActionResult<Parcel> Create(Parcel parcel)
        {
            _parcelService.Create(parcel);

            return CreatedAtRoute("GetParcel", new { id = parcel.Id.ToString() }, parcel);
        }
    }
}
