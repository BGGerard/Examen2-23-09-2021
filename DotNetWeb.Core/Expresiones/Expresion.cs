using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Expresiones
{
    public abstract class Expresion 
    {
        protected readonly Tipo tipo;
        public Token Token { get; }

        public Expresion(Token token, Tipo tipo)
        {
            Token = token;
            this.tipo = tipo;
        }

        public abstract String Generar();
    }
}
