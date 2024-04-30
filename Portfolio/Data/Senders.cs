namespace Portfolio.Data
{
    public class Senders
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; } 
        public DateTime TimeSent { get; set; }
    }
}
