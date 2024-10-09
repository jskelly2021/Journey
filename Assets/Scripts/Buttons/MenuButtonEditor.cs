using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(MenuButton))]
public class MenuButtonEditor : ButtonEditor
{
    SerializedProperty clickSound;

    protected override void OnEnable()
    {
        base.OnEnable();
        clickSound = serializedObject.FindProperty("clickSound");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(clickSound);
        serializedObject.ApplyModifiedProperties();
    }
}
