using DimensionDrive.Enemies;
using System.Collections.Generic;
using TAEngine;
using UnityEngine;

namespace DimensionDrive.Core
{
    public class GameLogic : SingletonAsComponent < GameLogic >
    {
        public static GameLogic Instance 
        {
            get { return ((GameLogic)SingletonInstance); }
            set { SingletonInstance = value; }
        }

        protected List<IInitializableObject> sceneInitObjects;
        protected List<IPausableObject> scenePauseObjects;
        protected List<IUpdatableObject> fixedUpdatableObjects;
        protected List<IUpdatableObject> regularUpdatableObjects;

        public void OnInitializeLogic()
        {   
            sceneInitObjects = new List<IInitializableObject>();
            scenePauseObjects = new List<IPausableObject>();
            regularUpdatableObjects = new List<IUpdatableObject>();
            fixedUpdatableObjects = new List<IUpdatableObject>();

            EventManager.Instance.AddEventListener(Globals.JUMP_TO_RESPAWN, OnEvent);
            EventManager.Instance.AddEventListener(Globals.PAUSE_INIT, OnEvent);
            EventManager.Instance.AddEventListener(Globals.PAUSE_ENDED, OnEvent);
        }

        public void OnCleanUpLoginc()
        {
            sceneInitObjects.Clear();
            sceneInitObjects = null;

            scenePauseObjects.Clear();
            scenePauseObjects = null;

            regularUpdatableObjects.Clear();
            regularUpdatableObjects = null;

            fixedUpdatableObjects.Clear();
            fixedUpdatableObjects = null;

            EventManager.Instance.RemoveEventListener(Globals.JUMP_TO_RESPAWN, OnEvent);
            EventManager.Instance.RemoveEventListener(Globals.PAUSE_INIT, OnEvent);
            EventManager.Instance.RemoveEventListener(Globals.PAUSE_ENDED, OnEvent);
        }

        public void OnResetLogic()
        {
            OnCleanUpLoginc();
            OnInitializeLogic();
        }

        private void OnEvent(TAEngine.EventType _evt)
        {
            if (_evt.type.Equals(Globals.JUMP_TO_RESPAWN))
            {
                OnInitializeObjects();
            }
            else if (_evt.type.Equals(Globals.PAUSE_INIT))
            {
                OnGamePaused();
            }
            else if (_evt.type.Equals(Globals.PAUSE_ENDED))
            {
                OnGameResumed();
            }

        }

        private void OnGamePaused()
        {
            for (var i = 0; i < scenePauseObjects.Count; ++i)
            {
                scenePauseObjects[i].OnPause();
            }
        }

        private void OnGameResumed()
        {
            for (var i = 0; i < scenePauseObjects.Count; ++i)
            {
                scenePauseObjects[i].OnResume();
            }
        }
        private void OnInitializeObjects()
        {
            for (var i = 0; i < sceneInitObjects.Count; ++i)
            {
                sceneInitObjects[i].OnInitializeBase();
            }         
        }

        #region Update + FixedUpdate
        void Update()
        {
            float dt = Time.deltaTime;

            for (int i = 0; i < regularUpdatableObjects.Count; ++i)
            {
                regularUpdatableObjects[i].OnUpdate(dt);
            }
        }
        
        void FixedUpdate()
        {
            float dt = Time.deltaTime;

            for (int i = 0; i < fixedUpdatableObjects.Count; ++i)
            {
                fixedUpdatableObjects[i].OnUpdate(dt);
            }
        }
        #endregion

        #region Register Methods
        public void RegisterPausebleObject(IPausableObject objectToRegister)
        {
            RegisterComponent(Instance.scenePauseObjects, objectToRegister);
        }
                
        public void RegisterInitializableObject(IInitializableObject objectToRegister)
        {
            RegisterComponent(Instance.sceneInitObjects, objectToRegister);            
        }
                
        public void RegisterUpdatableObject(IUpdatableObject objectToRegister)
        {
            RegisterComponent(Instance.regularUpdatableObjects, objectToRegister);

        }
        public void RegisterFixedUpdatableObject(IUpdatableObject objectToUnregister)
        {
            RegisterComponent(Instance.fixedUpdatableObjects, objectToUnregister);
        }

        public void RegisterComponent<T>(List<T> list, T component)
        {
            if (!list.Contains(component))
            {
                list.Add(component);
            }
        }

        #endregion

        #region UnRegister Methods
        public void UnRegisterInitializableObject(IInitializableObject objectToUnRegister)
        {
            UnRegisterComponent(Instance.sceneInitObjects, objectToUnRegister);
        }

        public void UnRegisterPausableObject(IPausableObject objectToUnRegister)
        {
            UnRegisterComponent(Instance.scenePauseObjects, objectToUnRegister);
        }
        public void UnRegisterUpdatableObject(IUpdatableObject objectToUnRegister)
        {
            UnRegisterComponent(Instance.regularUpdatableObjects, objectToUnRegister);
        }
                
        public void UnRegisterFixedUpdatableObject(IUpdatableObject objectToUnregister)
        {
            UnRegisterComponent(Instance.fixedUpdatableObjects, objectToUnregister);            
        }

        public void UnRegisterComponent<T>(List<T> list, T component)
        {
            if (list.Contains(component))
            {
                list.Remove(component);
            }
        }
        #endregion

    }
}
