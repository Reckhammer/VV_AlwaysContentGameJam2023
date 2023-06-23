using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildingReplacer : EditorWindow
{
    Transform buildings;
    GameObject[] prefabs = new GameObject[0];

    [MenuItem("Window/" + nameof(BuildingReplacer))]
    private static void Init()
    {
        BuildingReplacer window = (BuildingReplacer)EditorWindow.GetWindow(typeof(BuildingReplacer));
        window.Show();
    }

    void OnGUI()
    {
        buildings = EditorGUILayout.ObjectField(nameof(buildings), buildings, typeof(Transform), true) as Transform;

        int len = EditorGUILayout.IntField("Length: ", prefabs.Length);

        if (len != prefabs.Length)
        {
            var newArray = new GameObject[len];
            System.Array.Copy(prefabs, newArray, Mathf.Min(len, prefabs.Length));
            prefabs = newArray;
        }

        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i] = EditorGUILayout.ObjectField($"Prefab: {i}", prefabs[i], typeof(GameObject), true) as GameObject;
        }

        if (GUILayout.Button("Replace"))
        {
            Undo.RegisterFullObjectHierarchyUndo(buildings.gameObject, "Replace");
            foreach (Transform child in buildings)
            {
                var childBounds = child.GetComponent<Collider>().bounds;
                foreach (var prefab in prefabs)
                {
                    var prefabBounds = prefab.GetComponent<Collider>().bounds;
                    if (childBounds.size.sqrMagnitude >= prefabBounds.size.sqrMagnitude)
                    {
                        int index = child.GetSiblingIndex();
                        var instance = Object.Instantiate(prefab, child.parent) as GameObject;
                        instance.transform.SetSiblingIndex(index);
                        instance.transform.position = child.position + Vector3.down * childBounds.extents.y + Vector3.up * prefabBounds.extents.y;
                        child.parent = null;
                        DestroyImmediate(child.gameObject);
                        break;
                    }
                }
            }
        }
    }
}
