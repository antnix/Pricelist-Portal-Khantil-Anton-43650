﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pricelist_Portal_Khantil_Anton_43650.Models.DB;

namespace Pricelist_Portal_Khantil_Anton_43650.Parser.Morele
{
    public class MoreleStartParsing
    {
        public static void RefreshDB()
        {
            var moreleParser = new MoreleParser();
            var parser = new ParserWorker<List<object>>(moreleParser);
            parser.Settings = new MoreleSettings("https://www.morele.net/rtv/telewizory/telewizory-412/,,,,,,,,0,,,,", 1, 11, "TV");
            var result = parser.Start();
            SaveNewData(result);
            //parser.OnNewData += Parser_OnNewData;

            parser.Settings = new MoreleSettings("https://www.morele.net/rtv/sluchawki/sluchawki-bezprzewodowe-458/,,,,,,,,0,,,,", 1, 24, "Headphone");
            result = parser.Start();
            SaveNewData(result);
            //parser.OnNewData += Parser_OnNewData;
        }

        private static void SaveNewData(List<object> goodsList)
        {
            using (PricelistModel db = new PricelistModel())
            {
                PricelistModel.ClearTables("TV");
                PricelistModel.ClearTables("Headphones");
                foreach (var item in goodsList)
                {
                    switch (item.GetType().ToString())
                    {
                        case "Pricelist_Portal_Khantil_Anton_43650.Models.DB.TV":
                            db.TVs.Add((TV)item);
                            db.SaveChanges();
                            break;
                        case "Pricelist_Portal_Khantil_Anton_43650.Models.DB.Headphone":
                            db.Headphones.Add((Headphone)item);
                            db.SaveChanges();
                            break;
                    }
                }
            }
        }
    }
}
// https:// www.morele.net/rtv/telewizory/telewizory-412/,,,,,,,,0,,,,/1/
//https:// www.morele.net/rtv/sluchawki/sluchawki-bezprzewodowe-458/,,,,,,,,0,,,,/1/