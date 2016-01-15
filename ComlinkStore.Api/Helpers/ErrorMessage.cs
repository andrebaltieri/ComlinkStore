namespace ComlinkStore.Api.Helpers
{
    public class ErrorMessage
    {
        public ErrorMessage(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; set; }
        public string Message { get; set; }
    }
}