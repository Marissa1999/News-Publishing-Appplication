using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{
    interface IPublisher
    {
        void SetNewsArticle(string s);
        void NotifyReaders();
        void Register(Reader r, Viewer v);
        void Unregister(Reader r, Viewer v);
    }

    class Publisher : IPublisher
    {
        List<Reader> readers = new List<Reader>();
        List<Viewer> viewers = new List<Viewer>();

        string article;

        public void SetNewsArticle(string s)
        {
            article = s;

            Console.WriteLine("Synchronous Notification Tasks:");
            NotifyReaders();
            NotifyViewers();
            Console.WriteLine();

            Console.WriteLine("Asynchronous Notification Tasks:");
            Parallel.Invoke(NotifyReaders, NotifyViewers);
            Console.WriteLine();

            Console.WriteLine("Publisher - Published a NewsArticle");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void NotifyReaders()
        {          
            Parallel.ForEach(readers, reader => reader.ReadNews(article));
            Task.Delay(10);
        }

        public void NotifyViewers()
        {
            Parallel.ForEach(viewers, viewer => viewer.ViewNews(article));
            Task.Delay(10);
        }

        public void Register(Reader r, Viewer v)
        {
            readers.Add(r);
            viewers.Add(v);
        }

        public void Unregister(Reader r, Viewer v)
        {
            readers.Remove(r);
            viewers.Remove(v);
        }
    }
}
