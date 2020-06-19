using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuLib
{
    /// <summary>
    /// Base class for encapsulating any user operation.
    /// It can be e.g. separated and complete program or some part of it.
    /// The class's exposed method Execute() is basically an equivalent of Main() method in console.
    /// To use it simply inherit for it :) [sounds funny in english]
    /// </summary>
    public abstract class ConsoleMenuOperation
    {
        // fields
        private string _menuOperationName;
        private string _associatedKeysLabel;

        protected string _title;
        protected ConsoleKey[] _associatedKeys;
        // properties
        /// <summary>
        /// Operation's title getter.
        /// </summary>
        public string Title { get { return _title; } }
        /// <summary>
        /// Operation's name getter.
        /// </summary>
        public string Name { get { return _menuOperationName; } }
        // base constructor
        public ConsoleMenuOperation()
        {

            _menuOperationName = GetMenuOperationName();
            _associatedKeys = GetAssociatedKeys();
            _associatedKeysLabel = GetAssociatedKeyLabel();

            _title = _associatedKeysLabel + " - " + _menuOperationName;
        }
        // base constructor - related methods
        /// <summary>
        /// Here is operation name defined. Name will be later displayed along with associated keys to user.
        /// </summary>
        /// <returns>String with operation name.</returns>
        protected abstract string GetMenuOperationName();
        /// <summary>
        /// Here are all operation's associated keys assigned.
        /// </summary>
        /// <returns>An array of assigned keys. Should contain at least one element.</returns>
        protected abstract ConsoleKey[] GetAssociatedKeys();
        // external behaviour
        public abstract ConsoleMenuReport Execute();
        /// <summary>
        /// Informs ConsoleMenu parent object if passed key match to operation's associated one.
        /// </summary>
        /// <param name="readKey">Passed key.</param>
        /// <returns>Boolean value.</returns>
        public virtual bool HasAssociatedKey(ConsoleKey readKey)
        {
            if (_associatedKeys.Contains(readKey)) return true;
            else return false;
        }
        /// <summary>
        /// Nothing more than fancy key label "drawer".
        /// </summary>
        /// <returns>String which is displayed to user as a single menu operation.</returns>
        protected virtual string GetAssociatedKeyLabel()
        {
            string associatedKeysLabel = "";
            List<string> bufferKeyNames = new List<string>();
            IEnumerable<string> distinctedKeyNames;
            foreach (ConsoleKey key in _associatedKeys)
            {
                bufferKeyNames.Add("[" + GetKeyChar(key) + "] ");
            }
            distinctedKeyNames = bufferKeyNames.Distinct();
            foreach (string keyName in distinctedKeyNames)
            {
                associatedKeysLabel += keyName + " ";
            }
            while (associatedKeysLabel.Length < 11)
            {
                associatedKeysLabel += " ";
            }
            return associatedKeysLabel;
        }
        /// <summary>
        /// Little "dictionary" used to build operation's title. Override it if more recognized keys is needed. 
        /// </summary>
        /// <param name="key">Passed key.</param>
        /// <returns>Char related to passed key.</returns>
        protected virtual string GetKeyChar(ConsoleKey key) // borrowed an idea from csharp.hotexamples.com
        {
            switch (key)
            {
                // Alphabet.
                case ConsoleKey.A:
                    return "A";
                case ConsoleKey.B:
                    return "B";
                case ConsoleKey.C:
                    return "C";
                case ConsoleKey.D:
                    return "D";
                case ConsoleKey.E:
                    return "E";
                case ConsoleKey.F:
                    return "F";
                case ConsoleKey.G:
                    return "G";
                case ConsoleKey.H:
                    return "H";
                case ConsoleKey.I:
                    return "I";
                case ConsoleKey.J:
                    return "J";
                case ConsoleKey.K:
                    return "K";
                case ConsoleKey.L:
                    return "L";
                case ConsoleKey.M:
                    return "M";
                case ConsoleKey.N:
                    return "N";
                case ConsoleKey.O:
                    return "O";
                case ConsoleKey.P:
                    return "P";
                case ConsoleKey.Q:
                    return "Q";
                case ConsoleKey.R:
                    return "R";
                case ConsoleKey.S:
                    return "S";
                case ConsoleKey.T:
                    return "T";
                case ConsoleKey.U:
                    return "U";
                case ConsoleKey.V:
                    return "V";
                case ConsoleKey.W:
                    return "W";
                case ConsoleKey.X:
                    return "X";
                case ConsoleKey.Y:
                    return "Y";
                case ConsoleKey.Z:
                    return "Z";

                // Numpad keys
                case ConsoleKey.NumPad0:
                    return "0";
                case ConsoleKey.NumPad1:
                    return "1";
                case ConsoleKey.NumPad2:
                    return "2";
                case ConsoleKey.NumPad3:
                    return "3";
                case ConsoleKey.NumPad4:
                    return "4";
                case ConsoleKey.NumPad5:
                    return "5";
                case ConsoleKey.NumPad6:
                    return "6";
                case ConsoleKey.NumPad7:
                    return "7";
                case ConsoleKey.NumPad8:
                    return "8";
                case ConsoleKey.NumPad9:
                    return "9";

                // Keys below F1-F8.
                case ConsoleKey.D0:
                    return "0";
                case ConsoleKey.D1:
                    return "1";
                case ConsoleKey.D2:
                    return "2";
                case ConsoleKey.D3:
                    return "3";
                case ConsoleKey.D4:
                    return "4";
                case ConsoleKey.D5:
                    return "5";
                case ConsoleKey.D6:
                    return "6";
                case ConsoleKey.D7:
                    return "7";
                case ConsoleKey.D8:
                    return "8";
                case ConsoleKey.D9:
                    return "9";

                // Special characters.
                case ConsoleKey.Spacebar:
                    return "SPACE";
                case ConsoleKey.Tab:
                    return "TAB";
                case ConsoleKey.Backspace:
                    return "BACKSPACE";
                case ConsoleKey.Enter:
                    return "ENTER";
                case ConsoleKey.Escape:
                    return "ESCAPE";
                case ConsoleKey.Multiply:
                    return " * ";
                case ConsoleKey.Add:
                    return " + ";
                case ConsoleKey.Subtract:
                    return " - ";

                default:
                    return key.ToString();
            }

        }
    }
}
