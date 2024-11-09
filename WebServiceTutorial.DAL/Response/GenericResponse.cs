using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTutorial.DAL.Response;

public class GenericResponse<T>
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
}
