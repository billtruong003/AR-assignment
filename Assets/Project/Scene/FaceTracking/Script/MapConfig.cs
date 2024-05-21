using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "ScriptableObjects/Map/ScrollingPipes")]
public class MapConfig : ScriptableObject
{
    [SerializeField] private MapInfo[] mapInfo;
    public GameObject GetPrefabPipe(PipeType type)
    {
        foreach (var info in mapInfo)
        {
            if (info.pipeType == type)
                return info.GetPipe();
        }

        return null;
    }
}
[Serializable]
public class MapInfo
{
    public string pathToPipe;
    public PipeType pipeType;

    public GameObject GetPipe()
    {
        GameObject pipePrefab = Resources.Load<GameObject>(pathToPipe);

        if (pipePrefab == null)
            return null;

        return pipePrefab;
    }
}
[Serializable]
public enum PipeType
{
    INDUSTRIAL,
    CYBER,
    CHINATOWN,
}
