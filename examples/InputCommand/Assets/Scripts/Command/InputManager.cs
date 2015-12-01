/*
    <command pattern utilization example (Input) in C#.>
    Copyright (C) <2015>  <Alejandro Santiago Varela>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace aeonphyxius.command
{    
    public class InputManager
    {
        /// <summary>
        /// List where the Input Manager will store all the enabled commands / actions
        /// </summary>
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
            commandList = new Dictionary<string, InputAction>();
        }

        /// <summary>
        /// Add a new control definition to our command list
        /// </summary>
        /// <param name="_cmdName">the new control name for future references</param>
        /// <param name="_cmd">Delegate/Action reference to be called when executed this command</param>
        public void AddControl(string _cmdName, Action _cmd)
        {
            if (commandList.ContainsKey(_cmdName))
            {
                commandList[_cmdName] = new InputAction(_cmd);
            }
            else
            {
                commandList.Add(_cmdName, new InputAction(_cmd));
            }
        }

        /// <summary>
        /// Clean up all commands in the controls list
        /// </summary>
        public void ResetControls()
        {
            commandList.Clear();
        }

        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="_cmd">Command's name to be executed </param>
        public void ExectueCmd(string _cmdName)
        {
            if (commandList.ContainsKey(_cmdName))
            {
                commandList[_cmdName].Execute();
            }
            else
            {
                throw new NoCommandToExecute();
            }

        }
    }
}