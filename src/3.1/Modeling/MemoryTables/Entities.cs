using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTables
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

    public class BlogMemory
    {
        public BlogMemory(string name, string author)
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

    public class BlogMemoryOnly
    {
        public BlogMemoryOnly(string name, string author)
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
