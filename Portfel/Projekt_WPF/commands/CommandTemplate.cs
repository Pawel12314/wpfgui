using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt_WPF.commands
{
    public class CommandTemplate :ICommand
    {
        public InputGestureCollection InputGestures { get; }
        public string Name { get; }
        public Type OwnerType { get; }

        private Action<object> execute;
        private Func<object, bool> canExecuteFun;

        public event EventHandler CanExecuteChanged;

        private readonly Action _action;

        public CommandTemplate(Action<object> execute, Func<object, bool> canExecute = null)
        {
            
            this.execute = execute;
            this.canExecuteFun = canExecute;
        
        }


        public  bool CanExecute(object parameter)
        {
             return this.canExecuteFun(parameter);
            //return parameter != null;
        }



        public void Execute(object parameter)
        {
            //MessageBox.Show("SomeCommand");
            this.execute(parameter);

        }

    }
}
