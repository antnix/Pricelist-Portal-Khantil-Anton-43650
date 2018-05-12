
namespace Pricelist_Portal_Khantil_Anton_43650.Parser
{
    interface IParserSettings 
    {
        string BaseUrl { get; set; }

        string Prefix { get; set; }

        int StartPoint { get; set; }

        int EndPoint { get; set; }

        string Model { get; set; }
    }
}
