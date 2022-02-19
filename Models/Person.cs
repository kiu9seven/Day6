using System.ComponentModel.DataAnnotations;

namespace Day5_MVC_core.Models;

public class Person : IComparable
{
    [Required, MaxLength(50)]
    public string? FirstName { get; set; }
    [Required, MaxLength(50)]
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
    public string? PhoneNumber { get; set; }
    [MaxLength(10)]
    public string? BirthPlace { get; set; }
    public string? Gender { get; set; }
    public int Age
    {
        get
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }
    public bool IsGraduated { get; set; }
    public int TotalDays
    {
        get
        {
            return (int)(DateTime.Now - DateOfBirth).TotalDays;
        }
    }

    public int CompareTo(object? obj)
    {
        return TotalDays.CompareTo(((Person)obj).TotalDays);
    }
    public string FullName
    {
        get
        {
            return $"{LastName} {FirstName}";
        }
    }
}

public class PersonEditModel: Person{
    public int Index {get;set;}
    public PersonEditModel() {}
    public PersonEditModel(Person person){
        FirstName = person.FirstName;
        LastName = person.LastName;
        Gender = person.Gender;
        DateOfBirth = person.DateOfBirth;
        PhoneNumber = person.PhoneNumber;
        BirthPlace = person.BirthPlace;
    }
}

