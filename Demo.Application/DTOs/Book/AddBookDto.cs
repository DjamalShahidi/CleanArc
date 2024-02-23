namespace Demo.Application.DTOs.Book
{
    public record AddBookDto
    {
        public string Title { get; set; }

        public int Count { get; set; }
    }
}
