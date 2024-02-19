namespace HttpServer
{
    public class HttpRequest
    {
        public string Id { get; set; }

        public string Method { get; set; }

        public long? Expires { get; set; }

        public string Host { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as HttpRequest).Id);
        }
    }

    
}
