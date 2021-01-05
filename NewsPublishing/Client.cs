using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{
    class Client
    {
        static void Main(string[] args)
        {
            Reader reader1 = new Reader(1);
            Reader reader2 = new Reader(2);

            Viewer viewer1 = new Viewer(1);
            Viewer viewer2 = new Viewer(2);

            Publisher publisher = new Publisher();

            publisher.Register(reader1, viewer1);
            publisher.Register(reader2, viewer2);

            publisher.SetNewsArticle("Article-1: this is a news article!");

            publisher.Unregister(reader1, viewer1);

            publisher.SetNewsArticle("Article-2: this is a news article!");
        }
    }
}
