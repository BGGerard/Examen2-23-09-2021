﻿using System;
using System.Collections.Generic;
using System.Text;
using DotNetWeb.Core.Interfaces;

namespace DotNetWeb.Core.Statetment
{
    public abstract class statement : Nodo, ValidacionSemantica, ValidacionStatement
    {
        public abstract void Interpret();


        public abstract void ValidateSemantic();
        public abstract string Generate(int tabs);
        public virtual string GetCodeInit(int tabs)
        {
            var code = string.Empty;
            for (int i = 0; i < tabs; i++)
            {
                code += "\t";
            }
            return code;
        }
    }
}
