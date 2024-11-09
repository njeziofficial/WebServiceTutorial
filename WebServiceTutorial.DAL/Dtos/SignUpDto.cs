using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTutorial.DAL.Dtos;

public class SignUpDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
}

public class SignInDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
