using crud.Communication.Requests;
using crud.Exceptions;
using crud.Exceptions.ReadException;

namespace crud.Application.UseCase.User.Read;

public class ValidateReadUser
{
    public void Validate(RequestReadUser request)
    {
        ValidateRequest(request);
    }

    public static void ValidateRequest(RequestReadUser request)
    {
        if (request.id == Guid.Empty)
        {
            throw new ReadUserException(ResourceExceptions.REQUEST_NULL);
        }
    }
}
