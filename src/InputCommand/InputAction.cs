/*
    <C# command pattern implementation for input management>
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

namespace aeonphyxius.command
{
    public class InputAction : CommandBase
    {
        public InputAction(Action _command, string _cmdName) : base(_command, _cmdName)
        {

        }

        /// <summary>
        /// Execute this command Action (if not null)
        /// </summary>
        public override void Execute()
        {            
            if (command != null)
            {
                command();
            }
            else
            {
                throw new NoMethodToExecute();
            }
        }
    }
}