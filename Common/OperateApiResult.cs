 
namespace Common
{
    public class OperateApiResult : ApiResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        //[JsonProperty("data")]
        public object Data { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        //[JsonProperty("account")]
        public string Account { get; set; }
    }
}
