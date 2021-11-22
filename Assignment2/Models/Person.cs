using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Models {
public class Person {
    [Range(1,int.MaxValue,ErrorMessage = "Please enter a number greater than {1}"),DefaultValue("")]
    [JsonPropertyName("Id"),Key]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }
    [Required]
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    [JsonPropertyName("haircolor")]
    public string HairColor { get; set; }
    [JsonPropertyName("eyecolor")]
    public string EyeColor { get; set; }
    [Required,Range(0,int.MaxValue,ErrorMessage = "Your age must greater than {0}"),DefaultValue("")]
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [Required,Range(1,int.MaxValue,ErrorMessage = "You can't be that light"),DefaultValue("")]
    [JsonPropertyName("weight")]
    public float Weight { get; set; } 
    [Required,Range(1,int.MaxValue,ErrorMessage = "Even dwarves are higher than this"),DefaultValue("")]
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [Required,DefaultValue("")]
    [JsonPropertyName("sex")]
    public string Sex { get; set; }
}


}