using System.Text.Json.Serialization;

namespace Models {
public class Adult : Person {
    [JsonPropertyName("jobtitle")]
    public string JobTitle { get; set; }
    [JsonPropertyName("salary")]
    public int Salary { get; set; }
}
}