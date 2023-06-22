using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet;
// have just the info 
public class CV_Info
{
    [Key]
    // hay kermel ya3ref ldatabase eno heye key
    public int Id { get; set; }
    public string first_Name { get; set; }
    public string last_Name { get; set; }

    public string email { get; set; }

    public string Gender { get; set; }
    public int grade { get; set; }

    // grade for later

}
