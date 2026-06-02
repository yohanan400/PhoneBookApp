using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Commands
{
    public class RefreshContactsListCommand(Action action) : CommandBase
    {
        private readonly Action _action = action;

        public override void Execute(object? parameter)
        {
            _action();
        }
    }
}
