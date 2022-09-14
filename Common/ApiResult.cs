 

namespace Common
{
    public class ApiResult
    {
        /// <summary>
        /// API结构类型
        /// </summary>
        //[JsonProperty("result_type")]
        public ApiResultType ResultType { get; set; }

        /// <summary>
        /// 消息载体
        /// </summary>
        //[JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// url地址
        /// </summary>
        //[JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// clientId注册后将返回唯一的clientId
        /// </summary>
        //[JsonProperty("clientId")]
        public string ClientId { get; set; }
    }
}
