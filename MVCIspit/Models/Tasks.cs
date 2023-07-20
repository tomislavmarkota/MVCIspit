namespace MVCIspit.Models
{
    public class Tasks
    {
        public int Id { get; set; }    
        public string Name { get; set; }    
        public bool IsCompleted { get; set; }
        public int TodoId { get; set; } 

        //public Tasks()
        //{
        //    IsCompleted = false;
        //}
    }
}
