using System;
using System.Collections.Generic;
using System.Text;
using DotNetWeb.Core.Expresiones;

namespace DotNetWeb.Core
{
    public enum TipoSimbolo
    {
        Variable,
        Scope
    }
    public class Simbolo
    {
        public Simbolo(TipoSimbolo tiposimbolo, Id id, dynamic value)
        {
            TipoSimbolo = tiposimbolo;
            Id = id;
            Value = value;
        }
        public Simbolo(TipoSimbolo symbolType, Id id, Expresion attributes)
        {
            Attributes = attributes;
            TipoSimbolo = symbolType;
            Id = id;
        }

        public TipoSimbolo TipoSimbolo { get; }
        public Id Id { get; }
        public dynamic Value { get; set; }
        public Expresion Attributes { get; }
    }
}
