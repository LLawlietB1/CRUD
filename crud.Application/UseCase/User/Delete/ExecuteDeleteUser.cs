using crud.Communication.Requests;
using crud.Exceptions;
using crud.Exceptions.DeleteException;
using crud.Infrastructure;

namespace crud.Application.UseCase.User.Delete;

public class ExecuteDeleteUser
{
    public void Execute(RequestDeleteUser request)
    {
        var validator = new ValidateDeleteUser();
        validator.Validate(request);

        var _context = new CrudDbContext();

        var user = _context.account.Find(request.id);
        if (user == null)
        {
            throw new DeleteUserException(ResourceExceptions.NOT_FOUND);
        }

        _context.account.Remove(user);
        _context.SaveChanges();
    }
}
