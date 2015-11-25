using System;

namespace aeonphyxius.command
{
    public class InputAction : CommandBase
    {
        public InputAction(Action _command, string _cmdName) : base(_command, _cmdName)
        {

        }

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
