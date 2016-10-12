using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Socument
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser


namespace WindowsFormsApplication2
{
    class luceneapplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        Lucene.Net.Search.IndexSearcher searcher;
        Lucene.Net.QueryParsers.QueryParser parser;

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "Text";

        public void LuceneApplication()
        {
            luceneIndexDirectory = null;
            analyzer = null;
            writer = null;
        }
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            //IndexDeletionPolicy p;

            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);

        }
        public void IndexText(string text)
        {

            Lucene.Net.Documents.Field field = new Field(TEXT_FN, text, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(field);
            writer.AddDocument(doc);
        }
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }
        public TopDocs SearchIndex(string querytext)
        {

            System.Console.WriteLine("Searching for " + querytext);
            querytext = querytext.ToLower();
            Query query = parser.Parse(querytext);
            TopDocs results = searcher.Search(query, 100);
            System.Console.WriteLine("Number of results is " + results.TotalHits);
            return results;

        }
        public string DisplayResults(TopDocs results)
        {
            int rank = 0;
            string myFieldValue="NULL";
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                // retrieve the document from the 'ScoreDoc' object
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                myFieldValue = doc.Get(TEXT_FN).ToString();
                //Console.WriteLine("Rank " + rank + " score " + scoreDoc.Score + " text " + myFieldValue);
                //   Console.WriteLine("Rank " + rank + " text " + myFieldValue);
               
            }
            return myFieldValue;
        }
        public void CreateAnalyser()
        {
            // TODO: Enter code to create the Lucene Analyser 

        }
        public void OpenIndex(string indexPath)
        {
            /* Make sure to pass a new directory that does not exist */
            if (System.IO.Directory.Exists(indexPath))
            {
                Console.WriteLine("This directory already exists - Choose a directory that does not exist");
                Console.Write("Hit any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void CleanUp()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }

        public void CreateWriter()
        {


            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);

            // TODO: Enter code to creat



        }
        public int OutputRank(string querytext)
        {
            querytext = querytext.ToLower();
            Query query = parser.Parse(querytext);

            TopDocs results = searcher.Search(query, 100);
            int rank = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                string myFieldValue = null;
                rank++;
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                myFieldValue = doc.Get(TEXT_FN).ToString();
            }
            return rank;
        }
        public List<results> SearchText(string querytext)
        {

            string myFieldValue = null;
            //      System.Console.WriteLine("Searching for " + querytext);
            querytext = querytext.ToLower();
            Query query = parser.Parse(querytext);

            TopDocs results = searcher.Search(query, 100);
            //      System.Console.WriteLine("Number of results is " + results.TotalHits);
            int rank = 0;
            List<results> resultvalues = new List<results>();
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                myFieldValue = doc.Get(TEXT_FN).ToString();
                string[] str = new string[5];

                string[] spl = { ".I", ".T", ".A", ".B", ".W" };
                for (int i = 0; i < str.Length; i++)
                {
                    int indexStart = myFieldValue.IndexOf(spl[i]) + 2;
                    int indexEnd;
                    if (i + 1 < str.Length)
                    {
                        indexEnd = myFieldValue.IndexOf(spl[i + 1]);

                    }
                    else
                    {
                        indexEnd = myFieldValue.Length;
                    }
                    str[i] = myFieldValue.Substring(indexStart, indexEnd - indexStart);
                }
                string fabs = str[4].Substring(str[4].IndexOf(str[1]) + str[1].Length, str[4].Length - str[1].Length);
                resultvalues.Add(new results(rank, int.Parse(str[0]), str[1], str[2], str[3], fabs));
                

                //           Console.WriteLine("Rank " + rank + " text " + myFieldValue);

            }

            return resultvalues;
        }
        public void CreateSearcher()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
        }
        public void CleanUpSearch()
        {
            searcher.Dispose();
        }
        public void CreateParser()
        {
            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, TEXT_FN, analyzer);
        }
        public void CleanUpSearcher()
        {
            searcher.Dispose();
        }
    }

}

