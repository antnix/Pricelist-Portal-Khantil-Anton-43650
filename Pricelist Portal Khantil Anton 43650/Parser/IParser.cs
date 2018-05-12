using AngleSharp.Dom.Html;

namespace Pricelist_Portal_Khantil_Anton_43650.Parser
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document, string model);
    }
}
