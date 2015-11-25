/*
    <Example of use the command patter in C# and Unity.>
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

using UnityEngine;
using System;

namespace aeonphyxius.command
{
    public class IOHandler : MonoBehaviour
    {

        private const string UP_CONTROL = "up";
        private const string DOWN_CONTROL = "down";
        private const string LEFT_CONTROL = "left";
        private const string RIGHT_CONTROL = "right";
        private const string ACTION_CONTROL = "action";
                
        void Start()
        {

            PlayerControl _pc = GameObject.Find("Player").transform.GetComponent<PlayerControl>() as PlayerControl;

            // We register the actions (names) and fucntions to execute in our InputManager
            InputManager.Instance.AddControl(UP_CONTROL, _pc.OnUpPressed);
            InputManager.Instance.AddControl(DOWN_CONTROL, _pc.OnDownPressed);
            InputManager.Instance.AddControl(LEFT_CONTROL, _pc.OnLeftPressed);
            InputManager.Instance.AddControl(RIGHT_CONTROL, _pc.OnRightPressed);
            InputManager.Instance.AddControl(ACTION_CONTROL, _pc.OnActionPressed);

        }

        void Update()
        {
            // Up
            if ( Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up");
                InputManager.Instance.ExectueCmd(UP_CONTROL);
            }

            // Down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                InputManager.Instance.ExectueCmd(DOWN_CONTROL);
            }

            // Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Left");
                InputManager.Instance.ExectueCmd(LEFT_CONTROL);
            }

            // Right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Right");
                InputManager.Instance.ExectueCmd(RIGHT_CONTROL);
            }

            //Space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Action");
                InputManager.Instance.ExectueCmd(ACTION_CONTROL);
            }
        }
    }
}
