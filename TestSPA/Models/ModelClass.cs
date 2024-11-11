using System.ComponentModel.DataAnnotations;

namespace TestSPA.Models
{
    public class ModelClass
    {
    }
    public class ViewModel
    {
        public List<Post>? Posts { get; set; }
        public List<User>? Users { get; set; } 
    }
    public class Post 
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
    public class User 
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? website { get; set; } 
    }
}
