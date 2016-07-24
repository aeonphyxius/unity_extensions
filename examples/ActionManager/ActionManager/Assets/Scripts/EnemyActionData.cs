using System;
using UnityEngine;

namespace DimensionDrive.Enemies
{
    public static class EnemyActionDataLoader
    {
        public static T LoadStep<T>(string _json)
        {
            return JsonUtility.FromJson<T>(_json);
        }
    }

    [Serializable]
    public class EnemyActionData
    {
        public string enemy;
        public string shortname;
        public float life;        
    }

    [Serializable]
    public abstract class StepData
    {
        public string stepType;
        public int stepNum;
        public float time;
    }

    [Serializable]
    public class WaitData : StepData
    {        
    }

    public class FollowPlayerData : StepData
    {        
        public float initialSpeed;
        public float maxSpeed;
        public float speed;
    }

    [Serializable]
    public class MoveToData : StepData
    {
        public float x;
        public float y;
        public float z;
        public string ease;
        public string objName;
    }


    [Serializable]
    public class RotateData : StepData
    {
        public float x;
        public float y;
        public float z;
        public float speed;
        public string objName;
    }

    [Serializable]
    public class RotateToData : StepData
    {
        public float angle;
        public string ease;
        public bool aim;
        public string objName;
        public int direction;
    }

    [Serializable]
    public class FireSimple : StepData
    {
        public float fireRatio;
        public string cannonName;        
    }

    [Serializable]
    public class FireBigLaser : StepData
    {        
        public string cannonName;
    }

    [Serializable]
    public class GoToData : StepData
    {
        public int actionNum;
        public int repeatNum;
    }
}
