﻿using Unity.Entities;

public struct StartComponentData : IComponentData
{
}

[RequiresEntityConversion]
public class Start : Node
{
    public SocketOutputSignal Output;

    public override void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
    }
}