using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Web.Tests.Controllers
{
    public class Kalkulator
    {
        public virtual int Dodawanie(int pierwsza, int druga)
        {
            return pierwsza + druga;
        }
    }
}
