using UnityEngine;

namespace Aureola
{
    abstract public class BaseData<T> where T : class
    {
        public static T FromJson(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
