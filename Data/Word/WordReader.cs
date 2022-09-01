using DawaAPI.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace DawaAPI.Data.Word
{
    public class WordReader
    {
        QuranContext _db;
        string fileName = @"C:\Projects\DawaAPI\moyeserTfseer2.docx";
        List<string> wwords = new List<string>();

        public WordReader(QuranContext db)
        {
            _db = db;
            readMuyseer();
        }

        public void readMuyseer()
        {

            using (WordprocessingDocument wordDocument =
    WordprocessingDocument.Open(fileName, false))
            {
                var paragraphs = wordDocument.MainDocumentPart.RootElement.Descendants<Paragraph>();
                var pList = paragraphs.ToList();

                //Debug.WriteLine(pList[6].InnerText);
                int counter = 0;
                int AccCount = 0;
                int count1 = paragraphs.Count();
                bool canAccess = false;

                var muyaseer = _db.ExplanationSource.Find(1);

                if (muyaseer == null)
                {

                    _db.ExplanationSource.Add(new ExplanationSource() { Id = 0, ArabicName = "التفسير الميسر", EnglishName = "moyeserTfseer" });
                    //_db.SaveChanges();

                }

                ExplanationSource source = _db.ExplanationSource.Find(1);
                for (int i = 0; i < count1; i++)
                {
                    if (pList[i].InnerXml.Contains("000080"))
                    {
                        counter = pList[i].InnerXml.Count(c => c == ')');
                        //Debug.WriteLine(counter);

                    }

                    if (pList[i].InnerXml.Contains("0000FF") && canAccess)
                    {

                        for(int j = 0; j < counter; j++)
                        {


                            
                            AccCount++;

                            _db.Ayah.Find(AccCount).Explanations.Add(new Explanation()
                            {
                                Source = source,
                                ExplanationText = pList[i].InnerText
                            });
                            // Debug.WriteLine(pList[i].InnerText);
                            //Debug.WriteLine(pList[i].InnerXml);
                        }

                     
                    }
                    canAccess = !canAccess;

                }
                Debug.WriteLine(AccCount);
                _db.SaveChanges();

            }

        }

    }
}

