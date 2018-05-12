
namespace Pricelist_Portal_Khantil_Anton_43650.Parser.Morele
{
    public class MoreleSettings : IParserSettings
    {
        public string BaseUrl { get; set; }

        public string Prefix { get; set; } = "{CurrentId}";

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }

        public string Model { get; set; }

        public MoreleSettings(string baseUrl, int start, int end, string model) 
        {
            BaseUrl = baseUrl;
            StartPoint = start;
            EndPoint = end;
            Model = model;
        }
        public MoreleSettings(string baseUrl, string prefix, int start, int end, string model) 
        {
            BaseUrl = baseUrl;
            Prefix = prefix;
            StartPoint = start;
            EndPoint = end;
            Model = model;
        }
              
    }
}