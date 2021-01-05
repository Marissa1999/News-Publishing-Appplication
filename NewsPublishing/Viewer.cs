using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{

    interface IViewer
    {
        void ViewNews(string article);
    }

    class Viewer : IViewer
    {
        int number;

        public Viewer(int n)
        {
            number = n;
        }

        public void ViewNews(string article)
        {
            Console.WriteLine("Viewer-" + number + " has viewed the news: " + article);
        }
    }
}
