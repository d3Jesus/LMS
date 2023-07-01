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

    [Required(ErrorMessage = "This field is required!")]
    [StringLength(50, ErrorMessage = "This field only accept {1} characters long.")]
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    [Required(ErrorMessage = "This field is required!")]
    [StringLength(50, ErrorMessage = "This field only accept {1} characters long.")]
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