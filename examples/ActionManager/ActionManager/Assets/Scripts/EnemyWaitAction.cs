using TAEngine;
using UnityEngine;
using DimensionDrive.Core;

namespace DimensionDrive.Enemies.Actions
{
    public class EnemyWaitAction : EnemyAction
    {
        private float time;
        private Coroutine coroutine;

        public EnemyWaitAction(WaitData _waitData)
        {
            time = _waitData.time;
            coroutine = null;
        }
        
        public override void ActionStart()
        {
            coroutine = GameLogic.Instance.StartCoroutine(new Timer(time, false, OnActionFinished).Start());
        }

        private void OnActionFinished()
        {
            OnStopCoroutine();
            OnFinish();
        }

        public override void ActionReset()
        {
            OnStopCoroutine();
        }

        private void OnStopCoroutine()
        {
            if (coroutine != null)
            {
                GameLogic.Instance.StopCoroutine(coroutine);
            }
            coroutine = null;
        }

    }
}