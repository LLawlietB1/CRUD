using crud.Application.Security;
using crud.Communication.Requests;
using crud.Exceptions;
using crud.Exceptions.UpdateException;
using crud.Infrastructure;

namespace crud.Application.UseCase.User.Update;

public class ExecuteUpdateUser
{
    public void Execute(RequestUpdateUser request)
    {
        var validator = new ValidateUpdateUser();
        validator.Validate(request);
        var _context = new CrudDbContext();
        var user = _context.account.Find(request.id);
        if (user == null)
        {
            throw new UpdateUserException(ResourceExceptions.NOT_FOUND);
        }
        user.name = request.name;
        user.username = request.username;
        user.email = request.email;
        user.password = PasswordHasher.Hash(request.password);
        _context.account.Update(user);
        _context.SaveChanges();
    }
}
