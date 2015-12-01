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
    public abstract class CommandBase
    {
        protected Action command;

        public CommandBase(Action _command)
        {
            command = _command;        
        }

        public abstract void Execute();
    }

    /// <summary>
    /// Exception to raise when there is no action to be executed in our Input Manager action's list
    /// </summary>
    public class NoCommandToExecute : Exception
    {
        public NoCommandToExecute()
        {
        }

        public NoCommandToExecute(string message)
            : base(message)
        {
        }

        public NoCommandToExecute(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Exception to be raised when in a given action there is no reference to any Action    
    /// </summary>
    public class NoMethodToExecute : Exception
    {
        public NoMethodToExecute()
        {
        }

        public NoMethodToExecute(string message)
            : base(message)
        {
        }

        public NoMethodToExecute(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}