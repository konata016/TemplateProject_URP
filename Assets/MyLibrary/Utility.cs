using System;
using UnityEngine;

public class Utility
{
    /// <summary>
    /// 中央値の取得
    /// </summary>
    public static float GetMedian(float min, float max)
    {
        return (min + max) * 0.5f;
    }

    /// <summary>
    /// 文字列をenumに変換する
    /// </summary>
    public static T TryConversionStringToEnum<T>(string text) where T : struct, Enum
    {
        if (!Enum.TryParse(text, out T word) || !Enum.IsDefined(typeof(T), word))
        {
            Debug.LogError($"想定外の文字列：{text}");
        }

        return word;
    }
}
