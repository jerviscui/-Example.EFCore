using System;
using System.Collections.Generic;
using System.Text;

namespace ReadonlyProperties
{
    public class Blog
    {
        public Blog(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public void SetContent(string content)
        {
            Content = content;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public string Content { get; private set; }
    }
}
