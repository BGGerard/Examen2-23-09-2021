using System;
using System.Collections.Generic;
using System.Linq;
using DotNetWeb.Core.Expresiones;
using System.Text;


namespace DotNetWeb.Core
{
    public static class GestionDeAmbiente
    {

        private static List<Ambiente> _contexts = new List<Ambiente>();
        private static List<Ambiente> _interpretContexts = new List<Ambiente>();
        private static int _currentIndex = -1;
        private static int _currentScope = 0;

        public static Ambiente PushContext()
        {
            var env = new Ambiente();
            _contexts.Add(env);
            _interpretContexts.Add(env);
            return env;
        }

        public static Ambiente PopContext()
        {
            var lastContext = _contexts.Last();
            _contexts.Remove(lastContext);
            return lastContext;
        }


        public static Simbolo GetSymbol(string lexeme)
        {
            for (int i = _contexts.Count - 1; i >= 0; i--)
            {
                var context = _contexts[i];
                var symbol = context.Get(lexeme);
                if (symbol != null)
                {
                    return symbol;
                }
            }
            throw new ApplicationException($"El simbolo {lexeme} No  existe o no ha sido declarado Aprenda a escribir bien !");
        }

        public static Simbolo GetSymbolForEvaluation(string lexeme)
        {
            foreach (var context in _interpretContexts)
            {
                var symbol = context.Get(lexeme);
                if (symbol != null)
                {
                    return symbol;
                }
            }
            throw new ApplicationException($"El simbolo {lexeme} No existe en este contexto");
        }


        public static void AddVariable(string lexeme, Id id) => _contexts.Last().AddVariable(lexeme, id);
        public static void InitScoupe() => _contexts.Last().InitScope();

        public static void UpdateVariable(string lexeme, dynamic value)
        {
            for (int i = _contexts.Count - 1; i >= 0; i--)
            {
                var context = _contexts[i];
                var symbol = context.Get(lexeme);
                if (symbol != null)
                {
                    context.UpdateVariable(lexeme, value);
                }
            }
        }

        public class Ambiente
        {
            private readonly Dictionary<string, Simbolo> _table;

            public Ambiente()
            {
                _table = new Dictionary<string, Simbolo>();
            }

            public void AddVariable(string lexeme, Id id)
            {
                if (!_table.TryAdd(lexeme, new Simbolo(TipoSimbolo.Variable, id, null)))
                {
                    throw new ApplicationException($"La variable {lexeme} YA EXISTE!! !");
                }
            }
            public void InitScope()
            {

                _currentScope = _currentScope + 1;
                if (_currentScope>1)
                {
                    throw new ApplicationException($"Ya Existe un scope Y solo se permite uno");
                }
            }

            public void UpdateVariable(string lexeme, dynamic value)
            {
                var variable = Get(lexeme);
                variable.Value = value;
                _table[lexeme] = variable;
            }
          

            public Simbolo Get(string lexeme)
            {
                if (_table.TryGetValue(lexeme, out var found))
                {
                    return found;
                }

                return null;
            }
        }

    }
    
}
