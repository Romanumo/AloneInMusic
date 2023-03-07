using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomTool
{
    public static int Range(int min, int max)
    {
        Random.InitState(System.DateTime.UtcNow.Millisecond);
        int number = Random.Range(min, max);
        return number;
    }
}

/*

int millisecond = System.DateTime.UtcNow.Millisecond;
        int number = (max * (int)Mathf.PerlinNoise(millisecond, millisecond));
        number = Mathf.Max(number, min);*/