﻿using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

public struct SocketRuntime : IComponentData
{
    public Entity SocketEntity;
    public Entity NodeEntity;
    public SocketType SocketType;
}

public enum SocketType : System.UInt16
{
    Undefined,
    Signal,
    Int,
    Float,
    Vector2,
    Vector3,
    Vector4,
    Entity,
    BlobString,
}

[StructLayout(LayoutKind.Explicit)]
public struct TriggerData : IComponentData
{
    [FieldOffset(0)]
    public SocketRuntime SocketRuntime;

    [FieldOffset(18)]
    public int IntValue;

    [FieldOffset(18)]
    public float FloatValue;

    [FieldOffset(18)]
    public Vector2 Vector2;

    [FieldOffset(18)]
    public Vector3 Vector3;

    [FieldOffset(18)]
    public Vector4 Vector4;

    [FieldOffset(18)]
    public Entity Entity;

    [FieldOffset(18)]
    public BlobString BlobString;

    [BurstCompile]
    public static void ConvertData(ref TriggerData triggerData, ref float data)
    {
        switch(triggerData.SocketRuntime.SocketType)
        {
            case SocketType.Float:
                triggerData.FloatValue = data;
            break;
            case SocketType.Int:
                triggerData.IntValue = (int)data;
            break;
            case SocketType.Vector2:
                triggerData.Vector2 = new Vector2(data, 0);
                break;
            case SocketType.Vector3:
                triggerData.Vector3 = new Vector3(data, 0);
                break;
            case SocketType.Vector4:
                triggerData.Vector4 = new Vector4(data, 0);
                break;
        }
    }

    [BurstCompile]
    public static void ConvertData(ref TriggerData triggerData, ref int data)
    {
        switch (triggerData.SocketRuntime.SocketType)
        {
            case SocketType.Float:
                triggerData.FloatValue = data;
                break;
            case SocketType.Int:
                triggerData.IntValue = data;
                break;
            case SocketType.Vector2:
                triggerData.Vector2 = new Vector2(data, 0);
                break;
            case SocketType.Vector3:
                triggerData.Vector3 = new Vector3(data, 0);
                break;
            case SocketType.Vector4:
                triggerData.Vector4 = new Vector4(data, 0);
                break;
        }
    }

    [BurstCompile]
    public static void ConvertData(ref TriggerData triggerData, ref Vector2 data)
    {
        switch (triggerData.SocketRuntime.SocketType)
        {
            case SocketType.Float:
                triggerData.FloatValue = data.x;
                break;
            case SocketType.Int:
                triggerData.IntValue = (int)data.x;
                break;
            case SocketType.Vector2:
                triggerData.Vector2 = data;
                break;
            case SocketType.Vector3:
                triggerData.Vector3 = new Vector3(data.x, data.y, 0);
                break;
            case SocketType.Vector4:
                triggerData.Vector4 = new Vector4(data.x, data.y, 0, 0);
                break;
        }
    }

    [BurstCompile]
    public static void ConvertData(ref TriggerData triggerData, ref Vector3 data)
    {
        switch (triggerData.SocketRuntime.SocketType)
        {
            case SocketType.Float:
                triggerData.FloatValue = data.x;
                break;
            case SocketType.Int:
                triggerData.IntValue = (int)data.x;
                break;
            case SocketType.Vector2:
                triggerData.Vector2 = new Vector2(data.x, data.y);
                break;
            case SocketType.Vector3:
                triggerData.Vector3 = data;
                break;
            case SocketType.Vector4:
                triggerData.Vector4 = new Vector4(data.x, data.y, 0, 0);
                break;
        }
    }

    [BurstCompile]
    public static void ConvertData(ref TriggerData triggerData, ref Vector4 data)
    {
        switch (triggerData.SocketRuntime.SocketType)
        {
            case SocketType.Float:
                triggerData.FloatValue = data.x;
                break;
            case SocketType.Int:
                triggerData.IntValue = (int)data.x;
                break;
            case SocketType.Vector2:
                triggerData.Vector2 = new Vector2(data.x, data.y);
                break;
            case SocketType.Vector3:
                triggerData.Vector3 = new Vector3(data.x, data.y, data.z);
                break;
            case SocketType.Vector4:
                triggerData.Vector4 = data;
                break;
        }
    }
}
