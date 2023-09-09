using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities;

public abstract class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool WasDeleted { get; set; }

}