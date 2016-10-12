using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class results
    {
        public  results (int rank, int id, string title, string authors, string bibliographicinformation, string firstsentenceofabtract)

        {
            this.Rank = rank;
            this.ID = id; 
            this.Title = title;
            this.Authors = authors;
            this.Bibliographicinformation = bibliographicinformation;
            this.Firstsentenceofabstract = firstsentenceofabtract;
        }
        public int rank;
            public int Rank
        {
            get { return rank; }
            set {  rank= value; }
        }
        public int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string authors;
        public string Authors
        {
            get { return authors; }
            set { authors = value; }
        }
        public string bibliographicinformation;
        public string Bibliographicinformation
        {
            get { return bibliographicinformation; }
            set { bibliographicinformation = value; }
        }
        public string firstsentenceofabstract;
        public string Firstsentenceofabstract
        {
            get { return firstsentenceofabstract; }
            set { firstsentenceofabstract = value; }
        }
    }
}
