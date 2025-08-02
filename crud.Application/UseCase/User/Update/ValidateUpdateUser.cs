using crud.Communication.Requests;
using crud.Exceptions;
using crud.Exceptions.UpdateException;
using System.Net.Mail;

namespace crud.Application.UseCase.User.Update;

public class ValidateUpdateUser
{   public void Validate(RequestUpdateUser request)
    {
        NameValidate(request);
        UserNameValidate(request);
        EmailValidate(request);
        PasswordValidate(request);
    }
    private void NameValidate(RequestUpdateUser request)
    {
        if (string.IsNullOrWhiteSpace(request.name))
        {
            throw new UpdateUserException(ResourceExceptions.EMPTY_NAME);
        } }
    private void UserNameValidate(RequestUpdateUser request) 
    { 
        if (string.IsNullOrWhiteSpace(request.username))
        {
            throw new UpdateUserException(ResourceExceptions.EMPTY_USERNAME);
        }
    }
    private void EmailValidate(RequestUpdateUser request)
    {
        if (string.IsNullOrWhiteSpace(request.email))
        {
            throw new UpdateUserException(ResourceExceptions.EMPTY_EMAIL);
        }
        try
        {
            MailAddress email = new MailAddress(request.email);
        }
        catch
        {
            throw new UpdateUserException(ResourceExceptions.FORMAT_EMAIL);
        }
    }
    private void PasswordValidate(RequestUpdateUser request)
    {
        if (string.IsNullOrWhiteSpace(request.password))
        {
            throw new UpdateUserException(ResourceExceptions.EMPTY_PASSWORD);
        }
    }
}
