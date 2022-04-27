using HtmlAgilityPack;
using QuranKareem.Data;
using QuranKareem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DawaAPI.Data.HTML
{
    public class QuranHTMLController
    {

        HtmlDocument htmldoc;
        QuranContext _context;

        public QuranHTMLController(QuranContext context)
        {
            htmldoc = new HtmlDocument();
            _context = context;
            htmldoc.Load(@"C:\Projects\DawaAPI\Data\HTML\hafsData_v18.html");
            readHtml();
        }

        public void readHtml()
        {

            var x = htmldoc.DocumentNode.Element("tbody"); 
            HtmlNodeCollection headers = htmldoc.DocumentNode.SelectNodes("//table");
            DataTable table = new DataTable();

            List<List<string>> y  = htmldoc.DocumentNode.SelectSingleNode("//table")
                        .Descendants("tr")
                        .Skip(1)
                        .Where(tr => tr.Elements("td").Count() > 1)
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();
            //foreach (HtmlNode header in headers)
            //    table.Columns.Add(header.InnerText); // create columns from th
            //                                         // select rows with td elements 
            //foreach (var row in htmldoc.DocumentNode.SelectNodes("//tr[td]"))
            //    table.Rows.Add(row.SelectNodes("td").Select(td => td.InnerText).ToArray());
            int counter = 0;
            foreach(List<string> ss in y)
            {
                Ayah ayah = _context.Ayah.SingleOrDefault(a => a.surahId.ToString() == ss[2] && a.idInSurah.ToString() == ss[8]);
                ayah.text_For_Html = ss[9];
                if(ss[9].Length > counter)
                {
                    counter = ss[9].Length;
                }

            }

            _context.SaveChanges();

        }

    }
}
