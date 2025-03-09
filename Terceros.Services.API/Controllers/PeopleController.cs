using Microsoft.AspNetCore.Mvc;
using Terceros.Applications.Generic;
using Terceros.Applications.Interfaces.People;
using Terceros.Applications.Responses.People;

namespace Terceros.Services.API.Controllers
{
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleInteractor _peopleInteractor;
        private readonly ResponseHttp _responseHttp;

        public PeopleController(IPeopleInteractor peopleInteractor, ResponseHttp responseHttp)
        {
            _peopleInteractor = peopleInteractor;
            _responseHttp = responseHttp;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Responses<PeopleResponse>))]
        public async Task<IActionResult> Get()
        {
            var response = await _peopleInteractor.GetPeople();
            return await _responseHttp.GetResponseHttp(response);
        }
    }
}
