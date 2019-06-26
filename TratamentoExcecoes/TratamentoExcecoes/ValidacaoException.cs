using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TratamentoExcecoes
{
    class ValidacaoException : Exception
    {
        private Control controle;
        
        public ValidacaoException(String msg, Control ctrl) : base(msg) {
            this.controle = ctrl;
        }

        public void Focus()
        {
            controle.Focus();
        }
    }
}
