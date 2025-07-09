
namespace Bookify.Application.Apartments.CreateApartment;
internal sealed class CreateApartmentCommandHandler(
    IApartmentRepository _apartmentRepository) : ICommandHandler<CreateApartmentCommand>
{
    public async Task<Result> Handle(
        CreateApartmentCommand request,
        CancellationToken cancellationToken)
    {
       await _apartmentRepository.CreateApartmentAync(request.Apartment, cancellationToken);

        return Result.Success();

    }
}
