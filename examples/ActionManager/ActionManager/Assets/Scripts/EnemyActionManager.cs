using System;
using System.Collections.Generic;
using DimensionDrive.Core;

namespace DimensionDrive.Enemies.Actions
{
    public class EnemyActionManager: IUpdatableObject
    {   
        public Action OnManagerFinished { get; set; }
        public Dictionary<int, List<EnemyAction>> ActionsList { get; set; }

        private int actionNum;
        private int completedActions;
        
        public static EnemyActionManager create()
        {
            return new EnemyActionManager();
        }

        public EnemyActionManager()
        {     
            actionNum = -1;
        }

        public void OnManagerReset()
        {
            OnCancelAllActions();              
            actionNum = -1;
            completedActions = 0;
        }

        public void OnManagerStart()
        {
            OnNextAction();
        }

        public void EnableEnemyManager()
        {
            GameLogic.Instance.RegisterFixedUpdatableObject(this);
        }

        public void DisableEnemyManager()
        {
            GameLogic.Instance.UnRegisterFixedUpdatableObject(this);
        }

        public void OnUpdate(float dt)
        {
            /*if (completedActions == ActionsList[actionNum].Count)
            {
                OnNextAction();
            }
            else
            {
                for (int i = 0; i < ActionsList[actionNum].Count; ++i)
                {
                    ActionsList[actionNum][i].ActionUpdate();
                }
            }*/
        }

        public void OnNextAction()
        {
            // ASV: To be refactored
            if (ActionsList[actionNum][0].GetType() == typeof(EnemyGoToAction) )
            {
                if (((EnemyGoToAction)ActionsList[actionNum][0]).IsFinished)
                {
                    OnCancelAllActions(actionNum);
                    ActionsList[actionNum][0].ActionReset();
                    ++actionNum;
                }
                else
                {
                    OnCancelAllActions(actionNum);
                    actionNum = ((EnemyGoToAction)ActionsList[actionNum][0]).GotoAction;                    
                }
            }
            else
            {
                ++actionNum;
                for (var i = 0; i < ActionsList[actionNum].Count; ++i)
                {
                    ActionsList[actionNum][i].ActionStart();
                }
            }
        
            if (actionNum >= ActionsList.Count)
            {                
                if (OnManagerFinished != null)
                {
                    OnManagerFinished();
                }
            }
            completedActions = 0;
        }

        public void OnActionFinished()
        {
            ++completedActions;

            if (completedActions == ActionsList[actionNum].Count)
            {
                OnNextAction();
            }
        }

        public void OnCancelAllActions(int _endAction = 0)
        {            
            if (ActionsList != null)
            {
                for (int i = 0; i < (_endAction == 0 ? ActionsList.Count : _endAction); ++i)
                {
                    for (int j = 0; j < ActionsList[i].Count; ++j)
                    {
                        ActionsList[i][j].ActionReset();
                    }
                }
            }
        }
    }
}