using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using Pricelist_Portal_Khantil_Anton_43650.Models.DB;

namespace Pricelist_Portal_Khantil_Anton_43650.Parser.Morele
{
    public class MoreleParser : IParser<List<object>>
    {
        public List<object> Parse(IHtmlDocument document, string model)
        {
            var goodsList = new List<object>(); 

            var prices = document.QuerySelectorAll("div").Where(item => item.ClassName != null &&
            item.ClassName.Contains("price-brutto"));  //  3 779,00 zł

            var headers = document.QuerySelectorAll("div").Where(item => item.ClassName != null &&
            item.ClassName.Contains("text-elipsis-tooltip hidden"));

            var features = document.QuerySelectorAll("div").Where(item => item.ClassName != null &&
            item.ClassName.Contains("feature hidden-on-ligth"));

            for (int i = 0; i < prices.Count(); i++)
            {
                string notFormatPrice = prices.ElementAt(i).TextContent;  // \n6 999,00 zł\n	-> string
                decimal price = decimal.Parse(notFormatPrice
                    .Replace(",", ".")
                    .Remove(notFormatPrice.IndexOf("z"),3)
                    .Remove(0, 1)
                    .Replace(" ", "")); // 6999.00 -> decimal

                var notFormatHeader = headers.ElementAt(i).TextContent;
                var shelp = notFormatHeader.Split(new char[] { ' ' });
                string brand = shelp[1];
                string productCode = shelp[2]; //

                var rnd = new Random();

                string notFormatFeature = features.ElementAt(i).TextContent;
                var sfeatures = notFormatFeature.Replace("\n"," ").Split(new char[] { ' ' });
                string feature1 = "";
                string feature2 = "";
                string feature3 = "";
                string feature4 = "";

                if (sfeatures.Length > 5 && model == "TV") // cannot get information, when some element doesnot exist
                {
                    feature1 = sfeatures[4];
                    feature2 = sfeatures[10];
                    feature3 = sfeatures[15];
                    feature4 = sfeatures[19];
                }
                if (sfeatures.Length > 5 && model == "Headphone")
                {
                    feature1 = sfeatures[4];
                    feature2 = sfeatures[10];
                    feature3 = sfeatures[15];
                    feature4 = sfeatures[19];
                }
                switch (model)
                {
                    case "TV":
                        goodsList.Add(new TV(brand, productCode, price, rnd.Next(0, 13), feature1, feature2, feature3, feature4, notFormatHeader));
                        break;
                    case "Headphone":
                        goodsList.Add(new Headphone(brand, productCode, price, rnd.Next(0, 25), feature1, feature2, feature3, feature4, notFormatHeader));
                        break;
                }
            }
            return goodsList;
        }
    }
}