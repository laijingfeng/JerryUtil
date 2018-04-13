using UnityEngine;

public class Test : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Jerry.UnityWebRequestUtil.Inst.HttpRequest("https://www.baidu.com/", Jerry.UnityWebRequestUtil.HttpMethod.GET, (code, rsp, err) =>
        {
            UnityEngine.Debug.LogError(code + " " + rsp + " " + err);
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}