using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Pricelist_Portal_Khantil_Anton_43650.Models.DB;

namespace Pricelist_Portal_Khantil_Anton_43650.Parser.Morele
{
    public class MoreleParser : IParser<List<object>>
    {
        public List<string> GetSubURL(IHtmlDocument document)
        {
            string prefix = "https://www.morele.net";

            var subURLList = new List<string>();
            var urlTags = document.QuerySelectorAll("div").Where(item => item.ClassName != null &&
            item.ClassName.Contains("full-name hidden-xs text-elipsis-wr"));

            foreach (var url in urlTags)
                subURLList.Add(prefix + url.QuerySelector("a").GetAttribute("href"));

            return subURLList;
        }

        public IHtmlDocument GetPageOfProduct(string URL)
        {
            HtmlLoader loader = new HtmlLoader(new MoreleSettings(URL));
            var source = loader.GetSourceByPageURL(URL);
            return new HtmlParser().Parse(source);
        }

        public List<object> Parse(IHtmlDocument document, string model)
        {
            var goodsList = new List<object>();
            decimal price = 0;
            var rnd = new Random();

            var subURLlist = GetSubURL(document);
            foreach (var url in subURLlist)
            {
                var siteOfProduct = GetPageOfProduct(url);

                string brand = "Brak danych",
                    productCode = "Brak danych",
                    energyClass = "Brak danych",
                    screenDiagonal = "Brak danych",
                    smartTV = "Brak danych",
                    wiFi = "Brak danych",
                    details = "Brak danych",
                    maxWorkingTime = "Brak danych",
                    transmissionType = "Brak danych",
                    haveMicrophone = "Brak danych",
                    range = "Brak danych";

                details = siteOfProduct.QuerySelectorAll("h1").Where(item => item.ClassName != null &&
                    item.ClassName.Contains("page-title")).FirstOrDefault().TextContent;

                var notFormatPrice = siteOfProduct.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                    item.ClassName.Contains("value")).FirstOrDefault().GetAttribute("content");  
                if (notFormatPrice != null && notFormatPrice != "")
                    price = decimal.Parse(notFormatPrice);

                var technicalSpecificationList = siteOfProduct.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                    item.ClassName.Contains("row table-info-item"));
                foreach(var specificationRow in technicalSpecificationList)
                {
                    var specificationName = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                    item.ClassName.Contains("table-info-inner name col-xs-6 col-sm-5")).FirstOrDefault().TextContent;

                    if(specificationName.Contains("Producent"))
                    {
                        brand = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                        item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Kod producenta"))
                    {
                        productCode = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Klasa energetyczna"))
                    {
                        energyClass = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Przekątna ekranu"))
                    {
                        screenDiagonal = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Smart TV"))
                    {
                        smartTV = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("WiFi"))
                    {
                        wiFi = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Maksymalny czas pracy"))
                    {
                        maxWorkingTime = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Rodzaj transmisji"))
                    {
                        transmissionType = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Wbudowany mikrofon"))
                    {
                        haveMicrophone = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }
                    if (specificationName.Contains("Zasięg"))
                    {
                        range = specificationRow.QuerySelectorAll("div").Where(item => item.ClassName != null &&
                       item.ClassName.Contains("table-info-inner col-xs-6 col-sm-7")).FirstOrDefault().TextContent;
                    }

                }
                switch (model)
                {
                    case "TV":
                        goodsList.Add(new TV(brand, productCode, price, rnd.Next(0, 13), energyClass, screenDiagonal, smartTV, wiFi, details));
                        break;
                    case "Headphone":
                        goodsList.Add(new Headphone(brand, productCode, price, rnd.Next(0, 25), maxWorkingTime, transmissionType, haveMicrophone, range, details));
                        break;
                }
            }

            return goodsList;
        }
    }
}

