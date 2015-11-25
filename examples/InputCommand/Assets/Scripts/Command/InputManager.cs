using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;

namespace aeonphyxius.command
{
    
    public class InputManager
    {
        private Dictionary<string, InputAction> commandList;

        #region singleton implementation

        public static InputManager Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested()
            {
            }

            internal static readonly InputManager instance = new InputManager();
        }
        #endregion

        private InputManager()
        {
            Debug.Log("Initializing command list object");
            commandList = new Dictionary<string, InputAction>();
        }

        public void AddControl(string _cmdName, Action _cmd)
        {
            if (commandList.ContainsKey(_cmdName))
            {
                commandList[_cmdName] = new InputAction(_cmd, _cmdName);
            }
            else
            {
                commandList.Add(_cmdName, new InputAction(_cmd, _cmdName));
            }
        }

        public void ResetControls()
        {
            commandList.Clear();
        }

        public void ExectueCmd(string _cmd)
        {
            if (commandList.ContainsKey(_cmd))
            {
                commandList[_cmd].Execute();
            }
            else
            {
                throw new NoCommandToExecute();
            }

        }
    }
}