 
namespace Common
{
    /// <summary>
    /// 返回值类型枚举
    /// </summary>
    public enum ApiResultType : int
    {
        /// <summary>
        /// 绑定返回数据
        /// </summary>
        BindData = 1,
        /// <summary>
        /// 操作成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 执行JS代码
        /// </summary>
        ExecuteJs = 2,
        /// <summary>
        /// 弹出消息
        /// </summary>
        ShowInfo = 3,
        /// <summary>
        /// 弹出消息并关闭窗口
        /// </summary>
        ShowInfoAndClose = 4,
        /// <summary>
        /// 弹出错误
        /// </summary>
        ShowError = 5,
        /// <summary>
        /// 弹出错误并关闭窗口
        /// </summary>
        ShowErrorAndClose = 6,
        /// <summary>
        /// 弹出警告
        /// </summary>
        ShowWarning = 7,
        /// <summary>
        /// 弹出警告并关闭窗口
        /// </summary>
        ShowWarningAndClose = 8,

        /// <summary>
        /// 未登录
        /// </summary>
        NoLogin = 9,

        /// <summary>
        /// 验证码错误
        /// </summary>
        SafeCodeError = 11,

        /// <summary>
        /// 登录成功警告刷分
        /// </summary>
        SuccessWarn = 10,

    }
}
