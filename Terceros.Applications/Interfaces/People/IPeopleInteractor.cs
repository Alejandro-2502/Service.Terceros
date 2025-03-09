using Terceros.Applications.Generic;
using Terceros.Applications.Responses.People;

namespace Terceros.Applications.Interfaces.People;

public interface IPeopleInteractor
{
    Task<Responses<PeopleResponse>> GetPeople();
}
