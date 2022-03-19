using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Technical.Evaluation.Application.encryption
{
  public  interface IContextRecorded: IEncryption,IDecrypt
    {
       Task< string> buildOperationRecorded(string valor);

    }
}
