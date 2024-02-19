namespace P03.Articles_2._0
{

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString() => $"{Title} - {Content}: {Author}";

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] articleArgs = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = articleArgs[0];
                string content = articleArgs[1];
                string author = articleArgs[2];

                Article newArticle = new Article(title, content, author);
                articles.Add(newArticle);
            }

            articles.ForEach(x => Console.WriteLine(x));
        }
    }
}

