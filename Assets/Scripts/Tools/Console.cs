using System;
using System.Reflection;
using Tools.GUI;

namespace Tools {
    public class Console {
        private static BindingFlags fieldFlags = BindingFlags.Public | BindingFlags.NonPublic;
        public static void Log(object obj) {
            if (obj is Type) {
                Log((Type)obj);
            }
            else {
                Log log = new Log(obj);
                if (ConsoleGUI.GUI == null) {
                    ConsoleGUI.ShowWindow();
                }
                ConsoleGUI.GUI.AddLog(log);
            }
        }

        public static void Log(Type t) {
            FieldInfo[] staticFields = t.GetFields(fieldFlags | BindingFlags.Static);
            Log(staticFields);
        }
    }

    public class Log {

        public static readonly BindingFlags FLAGS = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
        public string Name { get; set; }

        public readonly object obj;
        public Log(object obj) {
            this.obj = obj;
            Name = obj.ToString();
        }

        public string getField() {
            return obj.GetType().GetFields()[0].ToString();
        }
    }
}