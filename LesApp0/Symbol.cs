using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    static class Symbol
    {
        private static string[] SymbolsArray { get; } =
        {
            "abcdefghijklmnopqrsyuvwxyz",            // 26, Англійський алфавіт
            "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя'",   // 33, Український алфавіт
            "абвгдеёжзийклмнопрстуфхцчшъыьэюя"      // 21, Російський алфавіт
        };

        public static string All = new StringBuilder()
            .Append(SymbolsArray[0])
            .Append(SymbolsArray[1])
            .Append(SymbolsArray[2])
            .ToString();
    }
}
