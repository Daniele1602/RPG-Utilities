using System.Reflection;
using System.Collections.Generic;
using UnityEditor;

namespace Tools.GUI {
    public class ConsoleGUI : EditorWindow {

        public static ConsoleGUI GUI;

        private List<Foldout> foldouts;
        [MenuItem("Window/Logs")]
        public static void ShowWindow() {
            GUI = GetWindow<ConsoleGUI>("Logs");
            if (GUI.foldouts == null) {
                GUI.foldouts = new List<Foldout>();

            }
        }

        public void OnGUI() {
            if (foldouts != null) {
                foreach (Foldout f in foldouts) {
                    CreateFoldout(f);
                }
            }
        }

        public void OnInspectorUpdate() {
            Repaint();
        }

        public void AddLog(Log log) {
            ShowWindow();
            foldouts.Add(new Foldout(log));
        }

        private void CreateFoldout(Foldout f) {
            System.Type logType = f.log.obj.GetType();
            if (!logType.IsPrimitive) {
                f.shown = EditorGUILayout.Foldout(f.shown, f.log.Name);
                if (f.shown) {
                    foreach (FieldInfo field in f.log.obj.GetType().GetFields(Log.FLAGS)) {
						if (field != null) {
							EditorGUILayout.BeginHorizontal();
							for (int i = 0; i < 3; i++)
								EditorGUILayout.Space();
							EditorGUILayout.LabelField(field.Name);
							EditorGUILayout.LabelField(field.GetValue(f.log.obj)?.ToString());
							EditorGUILayout.EndHorizontal();
						}
                    }
                }
                else {
                    f.shown = false;
                }
            }
            else {
				EditorGUILayout.LabelField(f.log.Name);
			}
        }
    }
    public class Foldout {
        public bool shown = false;
        public Log log { get; }

        public Foldout(Log log) {
            this.log = log;
        }

    }
}
