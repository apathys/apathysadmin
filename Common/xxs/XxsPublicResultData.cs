
namespace Common.xxs
{
    public class XxsPublicResultData
    {
        public XxsPublicResultData()
        {
        }

        public XxsPublicResultData(XxsAjaxType resultTyle, string resultData)
        {
            this.ResultType = resultTyle;
            this.ResultData = resultData;
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public XxsAjaxType ResultType { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public string ResultData { get; set; }

    }

    public class XxsAjaxHelper
    {
        public static string AjaxResult(XxsAjaxType resultTyle, object obj)
        {
            XxsPublicResultData prd = new XxsPublicResultData(resultTyle, XxsJsonHelp.Encode(obj));
            return XxsJsonHelp.Encode(prd);
        }
        /// <summary>
        /// 设置时间类型
        /// </summary>
        /// <param name="resultTyle"></param>
        /// <param name="obj">1：时间 2：日期</param>
        /// <returns></returns>
        public static string AjaxResult(XxsAjaxType resultTyle, object obj, int timeType)
        {
            XxsPublicResultData prd = new XxsPublicResultData(resultTyle, XxsJsonHelp.Encode(obj, timeType));
            return XxsJsonHelp.Encode(prd);
        }
    }
}