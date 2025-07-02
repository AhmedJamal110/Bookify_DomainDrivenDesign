
namespace Bookify.Application.Apartments.SearchApartment;
internal sealed class SearchAprtmentQueryHander(
    IApartmentRepository _apartmentRepository)
    : IQueryHandler<SearchAprtmentQuery, IReadOnlyList<ApartmentResponse>>
{
    public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(
        SearchAprtmentQuery request,
        CancellationToken cancellationToken)
    {

        if (request.StartDate > request.EndDate)
        {
            return Result
                .Failure<IReadOnlyList<ApartmentResponse>>(ApartmentErrors.ValidationError);
        }

        IReadOnlyList<Apartment> apartments = await _apartmentRepository
            .SearchAvaiableApartments(
            request.StartDate,
            request.EndDate,
            cancellationToken);


        if (apartments is null)
        {
            return Result
                .Failure<IReadOnlyList<ApartmentResponse>>(ApartmentErrors.NotFound);

        }


        var responses = apartments
       .Select(a => new ApartmentResponse
       {
           Id = a.Id,
           Name = a.Name.Value,
           Description = a.Description.Value,
           Price = a.Price.Amount,
           Currency = a.Price.Currency.Code,
           Address = new AddressResponse
           {
               Country = a.Address.Country,
               State = a.Address.State,
               City = a.Address.City,
               ZipCode = a.Address.ZipCode,
               Street = a.Address.Street
           }
       })
       .ToList();

        return Result
            .Success<IReadOnlyList<ApartmentResponse>>(responses);




    }
}
