using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Commands
{
    public class FilterCommand(Action<string> action) : CommandBase
    {
        public Action<string> _action = action;

        public override void Execute(object? parameter)
        {
            _action((string)parameter!);
        }
    }
}
