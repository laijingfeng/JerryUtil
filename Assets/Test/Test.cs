using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        string url = "http://192.168.1.5/JerryApp/JerryApp/Log/";

        Jerry.UnityWebRequestUtil.Inst.HttpRequest(url + "log.php?log=haha&app_id=NULL&tag=NULL&type=1&idx=1", Jerry.UnityWebRequestUtil.HttpMethod.GET
            , (long code, string rsp, string err) =>
            {
                UnityEngine.Debug.LogError(code + " " + rsp + " " + err);
            });

        LogData data = new LogData();
        data.log = "test";
        Jerry.UnityWebRequestUtil.Inst.HttpRequest(url + "log_post.php", Jerry.UnityWebRequestUtil.HttpMethod.POST
            , (long code, string rsp, string err) =>
            {
                UnityEngine.Debug.LogError(code + " " + rsp + " " + err);
            }
            , JsonUtility.ToJson(data));
    }
}

/// <summary>
/// 日志上报数据
/// </summary>
public class LogData
{
    /// <summary>
    /// 日志内容。不可省。
    /// </summary>
    public string log;
    /// <summary>
    /// 应用ID。默认NULL。可省。
    /// </summary>
    public string app_id = "NULL";
    /// <summary>
    /// 标签。默认NULL。可省。
    /// </summary>
    public string tag = "NULL";
    /// <summary>
    /// <para>类型：1-INFO;2-WARN;3-ERROR。</para>
    /// <para>默认1。可省。</para>
    /// </summary>
    public int type = 1;
    /// <summary>
    /// <para>上报索引，用来严格控制日志显示顺序。</para>
    /// <para>建议：初值是时间戳，后续按日志递增。</para>
    /// <para>默认0。可省。</para>
    /// </summary>
    public int idx = 0;
}