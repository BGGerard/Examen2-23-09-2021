using System;
using System.Collections.Generic;
using System.Text;
using DotNetWeb.Core.Interfaces;

namespace DotNetWeb.Core.Expresiones
{
    public abstract class ExpresionTipo : Expresion,EvaluarExpresion
    {
        public ExpresionTipo(Token token, Tipo tipo)
           : base(token, tipo)
        {
        }

        public abstract dynamic Evaluar();

        public abstract Tipo GetExpressionType();
    }
}
