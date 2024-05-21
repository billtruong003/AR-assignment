using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "ScriptableObjects/Map/ScrollingPipes")]
public class MapConfig : ScriptableObject
{
    [SerializeField] private MapInfo[] mapInfo;

}
[Serializable]
public class MapInfo
{
    public GameObject pipe;
    public PipeType pipeType;
}
[Serializable]
public enum PipeType
{
    INDUSTRIAL,
}
