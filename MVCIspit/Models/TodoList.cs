using System.ComponentModel.DataAnnotations.Schema;

namespace MVCIspit.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }   

        public string? UserId { get; set; } 
       
        //[ForeignKey("TodoId")]
        //public List<Tasks>? Tasks { get; set; }
        [ForeignKey("TodoId")]
        public List<Tasks>? Tasks { get; set; }


    }
}
