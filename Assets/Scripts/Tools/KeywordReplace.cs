using UnityEditor;
using UnityEngine;
namespace Tools.Editor {
	public class KeywordReplace : UnityEditor.AssetModificationProcessor {

		static readonly string str = "Scripts/";

		public static void OnWillCreateAsset(string path) {
			path = path.Replace(".meta", "");
			int index = path.LastIndexOf(".");
			if (index < 0)
				return;
			string file = path.Substring(index);
			if (file != ".cs" && file != ".js" && file != ".boo")
				return;

			index = Application.dataPath.LastIndexOf("Assets");
			path = Application.dataPath.Substring(0, index) + path;
			file = System.IO.File.ReadAllText(path);

			int startIndex = path.IndexOf(str) + str.Length;
			int length = path.LastIndexOf("/") - startIndex;
			string _namespace = string.Empty;
			if (length > 0) {
				_namespace = path.Substring(startIndex, length).Replace('/', '.');
			}

			if (_namespace.Equals(string.Empty)) {
				file = file.Replace("namespace #NAMESPACE# {" + System.Environment.NewLine, "");
				file = file.Substring(0, file.LastIndexOf('}'));
			}
			else
				file = file.Replace("#NAMESPACE#", _namespace);

			System.IO.File.WriteAllText(path, file);
			AssetDatabase.Refresh();
		}
	}
}