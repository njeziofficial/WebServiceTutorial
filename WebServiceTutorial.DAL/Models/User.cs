using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTutorial.DAL.Models;

//public class User : BaseEntity
public class User
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    [StringLength(50)]
    public string FirstName { get; set; }
    [StringLength(50)]
    public string? LastName { get; set; }
    public string? Tel { get; set; }

    [StringLength(50)]
    public string Email { get; set; }
    [StringLength(1000)]
    public string? Password { get; set; }
    [StringLength(50)]
    public string? UserName { get; set; }
    public string? Salt { get; set; }   

}
