using crud.Communication.Requests;
using crud.Exceptions;
using crud.Exceptions.DeleteException;
using crud.Infrastructure;

namespace crud.Application.UseCase.User.Delete;

public class ValidateDeleteUser
{   public void Validate(RequestDeleteUser request)
    {
        ValidateID(request);
        ValidateEmail(request);
        ValidatePassword(request);
    }

   public void ValidateID(RequestDeleteUser request)
{
    if (request.id == Guid.Empty)
    {
        throw new DeleteUserException(ResourceExceptions.DELETE_USER);
    }
        using (var context = new CrudDbContext())
        {
            bool idExiste = context.account.Any(x => x.id == request.id);
            if (!idExiste)
            {
                throw new Exception(ResourceExceptions.INVALID_ID);
            }
        }
    }
  
    public void ValidateEmail(RequestDeleteUser request)
    {
        if (string.IsNullOrWhiteSpace(request.email))
        {
            throw new DeleteUserException(ResourceExceptions.DELETE_EMAIL);
        }
    }
    public void ValidatePassword(RequestDeleteUser request)
    {
        var dbContext = new CrudDbContext();

        if (string.IsNullOrWhiteSpace(request.password))
        {
            throw new DeleteUserException(ResourceExceptions.DELETE_PASSWORD);
        }
    }
}