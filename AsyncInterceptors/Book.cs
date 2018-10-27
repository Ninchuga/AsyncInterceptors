namespace AsyncInterceptors
{
    public class Book : BaseResponse
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Name)}: {Name}, {nameof(Author)}: {Author}";
        }
    }
}
