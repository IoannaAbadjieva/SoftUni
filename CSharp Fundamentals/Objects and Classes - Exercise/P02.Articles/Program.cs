namespace P02.Articles
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

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public override string ToString() => $"{this.Title} - {this.Content}: {this.Author}";

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = articleArgs[0];
            string content = articleArgs[1];
            string author = articleArgs[2];

            Article article = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string argument = cmdArgs[1];

                if (cmdType == "Edit")
                {
                    article.Edit(argument);
                }
                else if (cmdType == "ChangeAuthor")
                {
                    article.ChangeAuthor(argument);
                }
                else if (cmdType == "Rename")
                {
                    article.Rename(argument);
                }
            }

            Console.WriteLine(article);
        }
    }
}
