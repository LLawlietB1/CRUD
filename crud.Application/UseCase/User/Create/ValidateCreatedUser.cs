using crud.Communication.Requests;
using crud.Exceptions;
using crud.Exceptions.CreateException;
using System.Net.Mail;

namespace crud.Application.UseCase.User.Create;

public class ValidateCreatedUser
{

   public void Validate(RequestCreateUser request)
    {
        NameValidate(request);
        EmailValidate(request);
        PasswordValidate(request);
    }

    private void NameValidate(RequestCreateUser request) 
    {
        if (string.IsNullOrWhiteSpace(request.name))
        {
            throw new CreatedUserException(ResourceExceptions.CREATED_USER);
        }

        if (string.IsNullOrWhiteSpace(request.username))
        {
            throw new CreatedUserException(ResourceExceptions.CREATED_USERNAME);
        }
    }
   
    private void EmailValidate(RequestCreateUser request)
    {

        if (string.IsNullOrWhiteSpace(request.email))
        {
            throw new CreatedEmailException(ResourceExceptions.EMPTY_EMAIL);
        }

        try
        {
            MailAddress email = new MailAddress(request.email);
        }
        catch 
        { 
            throw new CreatedEmailException(ResourceExceptions.FORMAT_EMAIL);
        }
    }
    private void PasswordValidate(RequestCreateUser request)
    {
        if (string.IsNullOrWhiteSpace(request.password))
        {
            throw new CreatedPasswordException(ResourceExceptions.EMPTY_PASSWORD);
        }

        if (request.password != request.confirmPassword)
        {
            throw new CreatedPasswordException(ResourceExceptions.PASSWORD_NOT_MATCH);
        }
    }

}


