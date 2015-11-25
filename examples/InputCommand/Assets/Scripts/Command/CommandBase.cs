using System;

namespace aeonphyxius.command
{
    public abstract class CommandBase
    {
        protected string commandName;
        protected Action command;

        public CommandBase(Action _command, string _commandName)
        {
            command = _command;
            commandName = _commandName;
        }

        public abstract void Execute();
    }


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