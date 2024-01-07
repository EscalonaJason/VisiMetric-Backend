using Domain.Repository;
using Model;

namespace API;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


[Route("vmapi/Users")]
[ApiController]
public class UserController : ControllerBase
{
    private UserRepository repo = new UserRepository(new VMContext());
    
    [HttpGet]
    [Route("GetAll")]
    public List<User> Get()
    {
        return repo.GetAll();
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public User Get(int id)
    {
        return repo.GetById(id);
    }

    [HttpGet]
    [Route("GetIdByName")]
    public int Get([FromBody] UserName name)
    {
        return repo.GetIdByName(name.FirstName, name.LastName);
    }

    [HttpPost]
    [Route("Post")]
    public void Post([FromBody] User user)
    {
        repo.Add(user);
    }

    [HttpPut]
    [Route("Update")]
    public void Update([FromBody] User user)
    {
        repo.Update(user);
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public void Delete(int id)
    {
        repo.Delete(id);
    }
}

public class UserName{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}