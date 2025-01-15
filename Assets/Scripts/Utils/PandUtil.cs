using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public static class PandUtil
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Pandora/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }

    [UnityEditor.MenuItem("Pandora/CreateGameObject %g")]
    public static void Test2()
    {
        GameObject obj = new GameObject("GameObject");
    }
#endif

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T GetRandom<T>(this T[] array)
    {
        if (array.Length == 0)
            return default(T);

        return array[Random.Range(0, array.Length)];
    }

}
