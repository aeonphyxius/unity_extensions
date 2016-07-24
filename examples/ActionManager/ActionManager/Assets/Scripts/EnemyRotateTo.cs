using System;
using UnityEngine;

namespace DimensionDrive.Enemies.Actions
{
    public class EnemyRotateTo : EnemyAction
    {
        private float angle;
        private float time;

        private float x, y, z;
        private string[] ivSplit;
        private string[] ivRotV3;
        private LTDescr tweenDesc;
        private bool isAiming;
        private LeanTweenType ease;
        private int direction;


        public EnemyRotateTo(RotateToData _data)
        {
            tweenDesc = null;
            angle = _data.angle;
            time = _data.time;
            isAiming = _data.aim;
            ease = (LeanTweenType)Enum.Parse(typeof(LeanTweenType), _data.ease);
            direction = _data.direction;
        }

        public override void ActionStart()
        {
            float _localAngle;
            Vector3 _direction;
            if (isAiming)
            {
                //angle = EnemyManager.Instance.AngleToPlayer(ActionObject);
            }
            if (direction == 0)
            {
                if (ActionObject.transform.rotation.eulerAngles.y > angle)
                {
                    _direction = Vector3.down;
                    _localAngle = ActionObject.transform.rotation.eulerAngles.y - angle;
                }
                else
                {
                    _direction = Vector3.up;
                    _localAngle = angle - ActionObject.transform.rotation.eulerAngles.y;
                }
            }
            else
            {
                _direction = direction == 1 ? Vector3.up : Vector3.down;
                _localAngle = angle;
            }

            if (ease.Equals(LeanTweenType.notUsed))
            {
                tweenDesc = LeanTween.rotateAround(ActionObject, _direction, _localAngle, time).setOnComplete(OnActionFinished);
            }
            else
            {
                tweenDesc = LeanTween.rotateAround(ActionObject, _direction, _localAngle, time).setOnComplete(OnActionFinished).setEase(ease);
            }
        }

        private void OnActionFinished()
        {
            OnFinish();
        }

        public override void ActionReset()
        {
            tweenDesc = null;
        }
    }
}