using Microsoft.EntityFrameworkCore;
using QuranKareem.Data;
using QuranKareem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DawaAPI.Data.Xml
{
    public class QuranXMLController
    {

        private readonly QuranContext _context;
        XDocument xml;
        string currentId = "none";
        List<Surah> suwar;
        int surahId = 1, ayahId = 1;

        public QuranXMLController(QuranContext context)
        {
            xml = XDocument.Load(@"hafsData_v18.xml");
            var x = xml.Descendants("ROW");
            suwar = new List<Surah>();
            _context = context;

            longerName();
            parser();
            parser2();
        }


        public void longerName()
        {
            string longestT = "none";
            string longestS = "none";
            foreach (XElement xe in xml.Descendants("ROW"))
            {

                if (longestT.Equals("none"))
                {
                    longestT = xe.Element("aya_text").Value;
                    longestS = xe.Element("aya_text_emlaey").Value;
                    continue;
                }

                if (xe.Element("aya_text").Value.Length > longestT.Length)
                {
                    longestT = xe.Element("aya_text").Value;
                }

                if (xe.Element("aya_text_emlaey").Value.Length > longestS.Length)
                {
                    longestS = xe.Element("aya_text_emlaey").Value;
                }

            }
            var x = longestT.Length;
            var y = longestS.Length;
        }
        public void parser()
        {
            Surah newSurah = new Surah();

            foreach (XElement xe in xml.Descendants("ROW"))
            {
                //var x = xe.Element("sora_name_ar").Value;

                // New surah
                if (!currentId.Equals(xe.Element("sora").Value))
                {

                    if (!currentId.Equals("none"))
                    {
                        suwar.Add(newSurah);
                    }

                    newSurah = new Surah();
                    newSurah.id = surahId++;
                    newSurah.arabicName = xe.Element("sora_name_ar").Value;
                    newSurah.englishName = xe.Element("sora_name_en").Value;
                    newSurah.juza = int.Parse(xe.Element("jozz").Value);
                    currentId = xe.Element("sora").Value;
                }

            }

            suwar.Add(newSurah);

            using (var transaction = _context.Database.BeginTransaction())
            {

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Surah] ON");

                foreach (Surah surah in suwar)
                    _context.Surah.Add(surah);
                _context.SaveChanges();

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Surah] OFF");

                transaction.Commit();
            }

            //foreach (XElement xe in xml.Descendants("ROW"))
            //{

            //    _context.Ayah.Add(new Ayah
            //    {
            //        idInSurah = int.Parse(xe.Element("aya_no").Value),
            //        surahId = int.Parse(xe.Element("sora").Value),
            //        text = xe.Element("aya_text").Value,
            //        text_Emlaey = xe.Element("aya_text_emlaey").Value
            //    });
            //    _context.SaveChanges();
            //}
        }

        public void parser2()
        {
            foreach (XElement xe in xml.Descendants("ROW"))
            {
                _context.Ayah.Add(new Ayah
                {
                    id = ayahId++,
                    idInSurah = int.Parse(xe.Element("aya_no").Value),
                    surahId = int.Parse(xe.Element("sora").Value),
                    pageNumber = int.Parse(xe.Element("page").Value),
                    text = xe.Element("aya_text").Value,
                    text_Emlaey = xe.Element("aya_text_emlaey").Value
                });
            }

            using (var transaction = _context.Database.BeginTransaction())
            {

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Ayah] ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Ayah] OFF");

                transaction.Commit();
            }

        }
    }
}


