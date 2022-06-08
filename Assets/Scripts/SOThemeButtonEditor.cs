using ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SO_Theme))]
public class SOThemeButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (SO_Theme)target;

        if (GUILayout.Button("Apply Changes"))
        {
            var path = AssetDatabase.GetAssetPath(script);

            script.name = script.header;
            AssetDatabase.RenameAsset(path, script.header);
        }
    }
}