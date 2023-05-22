using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.BlazorUI.Data.Models;

public abstract class Person
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private bool _wasDeleted;
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    [Required]
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    [Required]
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public bool WasDeleted
    {
        get { return _wasDeleted; }
        set { _wasDeleted = value; }
    }

}