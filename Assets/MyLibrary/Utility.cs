using System;
using UnityEngine;

public class Utility
{
    /// <summary>
    /// �����l�̎擾
    /// </summary>
    public static float GetMedian(float min, float max)
    {
        return (min + max) * 0.5f;
    }

    /// <summary>
    /// �������enum�ɕϊ�����
    /// </summary>
    public static T TryConversionStringToEnum<T>(string text) where T : struct, Enum
    {
        if (!Enum.TryParse(text, out T word) || !Enum.IsDefined(typeof(T), word))
        {
            Debug.LogError($"�z��O�̕�����F{text}");
        }

        return word;
    }
}
