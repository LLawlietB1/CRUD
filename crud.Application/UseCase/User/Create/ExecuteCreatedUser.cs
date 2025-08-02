using crud.Application.Security;
using crud.Communication.Requests;
using crud.Communication.Responses;
using crud.Infrastructure;

namespace crud.Application.UseCase.User.Create;

public class ExecuteCreatedUser
{
    public void Execute(RequestCreateUser request)
    {
        var validator = new ValidateCreatedUser();
        validator.Validate(request);

        var dbContext = new CrudDbContext();

        var entity = new Infrastructure.Entities.Account
        {
            name = request.name,
            username = request.username,
            email = request.email, 
            password = PasswordHasher.Hash(request.password)
        };
        dbContext.account.Add(entity);
        dbContext.SaveChanges();
    }

    
}
