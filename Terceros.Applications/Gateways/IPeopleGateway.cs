using Terceros.Applications.DTOs.People;

namespace Terceros.Applications.Gateways
{
    public interface IPeopleGateway
    {
        Task<PeopleDTO> GetPeople();
    }
}
