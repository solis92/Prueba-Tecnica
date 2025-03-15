using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class News
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonIgnore]
        public int idnew { get; set; }
        public string title { get; set; }
        public string uri { get; set; }
        public string postedBy { get; set; }
        public  DateTime time { get; set; }
        public int score { get; set; }
        public int commentCount { get; set; }
    }
}
