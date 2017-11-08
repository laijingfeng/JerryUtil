using System;
using System.Collections;
using UnityEngine.Experimental.Networking;

namespace Jerry
{
    public class UnityWebRequestUtil : Singleton<UnityWebRequestUtil>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callback">code-rsp-err</param>
        public void Get(string url, Action<long, string, string> callback)
        {
            new JerryCoroutine.CorTask(IE_Get(url, callback));
        }

        private IEnumerator IE_Get(string url, Action<long, string, string> callback)
        {
            using (UnityWebRequest r = UnityWebRequest.Get(url))
            {
                yield return r.Send();
                if (r.isError)
                {
                    if (callback != null)
                    {
                        callback(r.responseCode, null, r.error);
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        callback(r.responseCode, r.downloadHandler.text, null);
                    }
                }
            }
        }
    }
}