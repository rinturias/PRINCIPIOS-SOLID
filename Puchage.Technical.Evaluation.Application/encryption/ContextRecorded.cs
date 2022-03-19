using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Technical.Evaluation.Application.encryption
{
  public  class ContextRecorded
    {
       public enum  TYPE_RECORDED
        {
            TYPE_SHA1
        }

        public enum TYPE_OPERATION_RECORDED 
        {
            ENCRYPTION,
            DECRYPT
        }

        //public static IContextRecorded buildOperationRecorded(TYPE_RECORDED typeRecorded)
        //{


        //    switch (typeRecorded)
        //    {
        //        case TYPE_RECORDED.TYPE_SHA1:

        //         new SHA1();

        //        default: return null;

        //    }


        //}

    }
}
