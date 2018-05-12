using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;

namespace Pricelist_Portal_Khantil_Anton_43650.Parser
{
    class ParserWorker<T> where T : class
    {
        IParserSettings parserSettings;

        HtmlLoader loader;

        #region Properties

        public IParser<List<object>> Parser { get; set; }

        public bool IsActive { get; private set; }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        #endregion

      //  public event Action<object, T> OnNewData;

        public ParserWorker(IParser<List<object>> parser)
        {
            this.Parser = parser;
        }

        public ParserWorker(IParser<List<object>> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public List<object> Start()
        {
            IsActive = true;
            return Worker();
        }

        public void Abort()
        {
            IsActive = false;
        }

        private List<object> Worker()
        {
            List<object> results = new List<object>();
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if (!IsActive)
                    return null;

                //  var source = await loader.GetSourceByPageId(i);
                var source = loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                //var document = await domParser.ParseAsync(source);
                var document = domParser.Parse(source);

                results.AddRange(Parser.Parse(document, parserSettings.Model));

                //OnNewData?.Invoke(this, result);
            }
            IsActive = false;
            return results;
        }
    }
}