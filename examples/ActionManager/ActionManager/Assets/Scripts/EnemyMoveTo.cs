using UnityEngine;

namespace DimensionDrive.Enemies.Actions
{
    public class EnemyMoveTo : EnemyAction
    {
        private LTDescr tweenDescriptor;

        public MoveToData MoveToActionData { get; set; }
        public LeanTweenType EaseType { get; set; }
        public bool isFixed { get; set; }

        public EnemyMoveTo()
        {
            OnFinish = null;
            ActionObject = null;
            isFixed = true;
            EaseType = LeanTweenType.notUsed;
            tweenDescriptor = null;
        }

        public override void ActionReset()
        {
            if (LeanTween.isTweening(ActionObject))
            {
                LeanTween.cancel(ActionObject);
            }
        }

        public override void ActionStart()
        {
            tweenDescriptor = LeanTween.moveLocal(ActionObject, GetMoveToPosition(), MoveToActionData.time);

            tweenDescriptor.setEase(EaseType);
            tweenDescriptor.setOnComplete(OnFinish);
        }

        private Vector3 GetMoveToPosition()
        {
            var moveTo = new Vector3(MoveToActionData.x, MoveToActionData.y, MoveToActionData.z);
            if (isFixed)
            {
                // If new position is 0, we use the current one
                moveTo.Set(
                    MoveToActionData.x == 0 ? ActionObject.transform.localPosition.x : MoveToActionData.x,
                    MoveToActionData.y == 0 ? ActionObject.transform.localPosition.y : MoveToActionData.y,
                    MoveToActionData.z == 0 ? ActionObject.transform.localPosition.z : MoveToActionData.z);
            }

            return moveTo;
        }
    }


    /*
        Action _onFinish, GameObject _objToMove, MoveToData _data )
            : base(_onFinish, "", ENEMY_ACTIONS.MOVE_TO)
        {
            onFinish = _onFinish;
            actionObject = _objToMove;

            moveTo = new Vector3(_data.x, _data.y, _data.z);
            timeToMove = _data.time;
            isFixed = true;

            if (!_data.ease.Equals(""))
            {
                ease = (LeanTweenType)Enum.Parse(typeof(LeanTweenType), _data.ease);
            }
            else
            {
                ease = LeanTweenType.notUsed;
            }

        }

        public EnemyMoveTo(Action _onFinish, string _inputData, GameObject _objToMove, ENEMY_ACTIONS _enemyActionType)
            : base(_onFinish, _inputData, _enemyActionType)
        {
            ease = LeanTweenType.notUsed;
            onFinish = _onFinish;
            actionObject = _objToMove;

            moveTo = new Vector3(0, 0, 0);

            BuildActionFromData();
        }

        private void BuildActionFromData()
        {
            // Split input values
            ivSplit = InputValues.Split(';');
            toPosV3 = ivSplit[0].Split(',');

            if (toPosV3.Length == 3)
            {
                x = float.Parse(toPosV3[0]);
                y = float.Parse(toPosV3[1]);
                z = float.Parse(toPosV3[2]);
            }

            timeToMove = Single.Parse( ivSplit[1] );
            isFixed = ivSplit[2].Equals("true") ? true : false;
        }
        */
}