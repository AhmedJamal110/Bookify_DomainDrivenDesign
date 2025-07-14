using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Authentications;

namespace Bookify.Application.Users;
internal sealed class RegisterUserCommandHandler(
    IAuthenticationService _authenticationService,
    IUserRepository _userRepository,
    IUnitOfWork _unitOfWork) : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {

        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email));


        string identityID = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);


        user.SetIdentityId(identityID);


        await _userRepository.AddAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return Result.Success(user.Id);
    }
}
