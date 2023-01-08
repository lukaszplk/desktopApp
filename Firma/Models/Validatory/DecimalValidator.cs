using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validatory
{
    public class DecimalValidator:Validator
    {
        public static string CzyWiekszyOdZera(decimal value) => value < 0 ? "ta wartosc nie moze byc mniejsza niz zero" : null;
        public static string CzyProcent(int value) => value > 1 && value < 0 ? null:"Ta wartosc musi byc z przedzialu 0 do 1";
    }
}
