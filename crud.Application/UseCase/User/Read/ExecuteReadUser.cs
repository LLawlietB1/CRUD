using crud.Communication.Requests;
using crud.Communication.Responses;
using crud.Exceptions;
using crud.Exceptions.ReadException;
using crud.Infrastructure;

namespace crud.Application.UseCase.User.Read;

public class ExecuteReadUser
{
    public ResponseReadUser Execute(Guid id)
    {
        var validator = new ValidateReadUser();
        validator.Validate(new RequestReadUser { id = id });

        var _context = new CrudDbContext();
        var user = _context.account.Find(id);
        if (user == null)
        {
            throw new ReadUserException(ResourceExceptions.NOT_FOUND);
        }
        return new ResponseReadUser
        {
            id = user.id,
            name = user.name,
            username = user.username,
            email = user.email
        };
    }
}
