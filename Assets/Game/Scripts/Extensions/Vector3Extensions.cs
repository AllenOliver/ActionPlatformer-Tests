using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static void Set(this Vector3 _thisVec3, Vector3 _otherVec3) => _thisVec3 = _otherVec3;

    public static void Set(this Vector3 _thisVec3, float _x, float _y, float _z)
    {
        _thisVec3.x = _x;
        _thisVec3.y = _y;
        _thisVec3.z = _z;
    }
}

public static class GameObjectExtensions
{
    public static void On(this GameObject _go) => _go.SetActive(true);

    public static void Off(this GameObject _go) => _go.SetActive(false);
}