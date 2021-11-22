using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Models {
public class Person {
    [Range(1,int.MaxValue,ErrorMessage = "Please enter a number greater than {1}"),DefaultValue("")]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    [Required,Range(0,int.MaxValue,ErrorMessage = "Your age must greater than {0}"),DefaultValue("")]
    public int Age { get; set; }
    [Required,Range(1,int.MaxValue,ErrorMessage = "You can't be that light"),DefaultValue("")]
    public float Weight { get; set; } 
    [Required,Range(1,int.MaxValue,ErrorMessage = "Even dwarves are higher than this"),DefaultValue("")]
    public int Height { get; set; }
    [Required,DefaultValue("")]
    public string Sex { get; set; }
}


}