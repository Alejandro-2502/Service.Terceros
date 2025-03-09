using AutoMapper;
using System.Net;
using Terceros.Applications.Gateways;
using Terceros.Applications.Generic;
using Terceros.Applications.Interfaces.ICommon;
using Terceros.Applications.Interfaces.People;
using Terceros.Applications.Responses.Common;
using Terceros.Applications.Responses.People;

namespace Terceros.Applications.Interactors.People;

public class PeopleInteractor : IPeopleInteractor
{
    private readonly IPeopleGateway _peopleGateway;
    private readonly ILogServices _logServices;
    private readonly IMapper _mapper;

    public PeopleInteractor(IPeopleGateway peopleGateway, IMapper mapper, ILogServices logServices)
    {
        _peopleGateway = peopleGateway;
        _mapper = mapper;
        _logServices = logServices;
    }

    public async Task<Responses<PeopleResponse>> GetPeople()
    {
        try
        {
            var result = await _peopleGateway.GetPeople();

            if (result is null)
                return await Response.Error<PeopleResponse>(HttpStatusCode.NotFound, Resources.MessagesResouces.PeopleServiceGetNotFound);

                var response = _mapper.Map<PeopleResponse>(result);
           
           return await Response.Ok(HttpStatusCode.OK, string.Empty, response);
        }
        catch (Exception ex)
        {
            _logServices.LogError(ex.Message);
            return await Response.Error<PeopleResponse>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
