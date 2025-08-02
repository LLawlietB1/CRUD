using crud.Application.UseCase.User.Create;
using crud.Application.UseCase.User.Delete;
using crud.Application.UseCase.User.Read;
using crud.Application.UseCase.User.Update;
using crud.Communication;
using crud.Communication.Requests;
using crud.Exceptions.CreateException;
using crud.Exceptions.DeleteException;
using crud.Exceptions.ReadException;
using crud.Exceptions.UpdateException;
using Microsoft.AspNetCore.Mvc;

namespace crud.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ExecuteCreatedUser _registerUseCase;
    private readonly ExecuteDeleteUser _deleteUseCase;
    private readonly ExecuteUpdateUser _updateUseCase;
    private readonly ExecuteReadUser _readUseCase;

    public UserController(
       ExecuteCreatedUser registerUseCase,
       ExecuteDeleteUser deleteUseCase,
       ExecuteUpdateUser updateUseCase,
       ExecuteReadUser readUseCase)
    {
        _registerUseCase = registerUseCase;
        _deleteUseCase = deleteUseCase;
        _updateUseCase = updateUseCase;
        _readUseCase = readUseCase;
    }

    [HttpPost()]
    public IActionResult CreateUser([FromBody] RequestCreateUser request)
    {
        try
        {
            _registerUseCase.Execute(request);
            return Created("", new { ResponsesDefault.CREATED_SUCCESS });
        }
        catch (CreatedUserException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (CreatedEmailException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id) 
    {
        try
        {
            _deleteUseCase.Execute(new RequestDeleteUser { id = id });
            return Ok(new { ResponsesDefault.DELETE_SUCCESS});
        }
        catch (DeleteUserException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateUser(Guid id,[FromBody] RequestUpdateUser request)
    {
        try
        {
            request.id = id; 
            _updateUseCase.Execute(request);
            return Ok(new { ResponsesDefault.UPDATE_SUCCESS});
        }
        catch (UpdateUserException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        try 
        {
            var response = _readUseCase.Execute(id);
            return Ok(response);
        }
        catch (ReadUserException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


}
