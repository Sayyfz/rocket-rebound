using UnityEngine;

namespace Debugging
{
    public static class CustomLogger
    {
        public static void Log(string message, bool compileAnyway = false)
        {
            if (compileAnyway)
            {
                Debug.Log(message);
                return;
            }
#if UNITY_EDITOR 
                Debug.Log(message);
#endif
        }
    }
}