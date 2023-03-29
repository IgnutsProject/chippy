using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    [Serializable]
    public struct RangeInt
    {
        [SerializeField] private int max;
        [SerializeField] private int min;

        public int Max => max;
        public int Min => min;

        public int Random()
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
    
    [Serializable]
    public struct RangeFloat
    {
        [SerializeField] private float max;
        [SerializeField] private float min;

        public float Max => max;
        public float Min => min;

        public float Random()
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
    
    public static class Utils
    {
        public static IEnumerator MakeActionDelay(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action.Invoke();
        }
    }
}