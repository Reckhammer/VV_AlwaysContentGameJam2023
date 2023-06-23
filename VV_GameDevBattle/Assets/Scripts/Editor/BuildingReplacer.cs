using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class BuildingReplacer : EditorWindow
{
    Transform root;
    GameObject[] prefabs = new GameObject[0];

    [MenuItem("Window/" + nameof(BuildingReplacer))]
    private static void Init()
    {
        BuildingReplacer window = (BuildingReplacer)EditorWindow.GetWindow(typeof(BuildingReplacer));
        window.Show();
    }

    void OnGUI()
    {
        root = EditorGUILayout.ObjectField(nameof(root), root, typeof(Transform), true) as Transform;

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
            Undo.RegisterFullObjectHierarchyUndo(root.gameObject, "Replace");
            foreach (Transform child in root)
            {
                var childBounds = child.GetComponentInChildren<Collider>().bounds;
                var shuffled = prefabs.OrderBy(x => Random.value);
                foreach (var prefab in shuffled)
                {
                    Debug.Log("Ping");
                    var prefabBounds = prefab.GetComponentInChildren<Collider>().bounds;
                    if (childBounds.size.sqrMagnitude >= prefabBounds.size.sqrMagnitude)
                    {
                        GameObject instance = null;
                        int index = child.GetSiblingIndex();
                        if (PrefabUtility.GetPrefabType(prefab) == PrefabType.Prefab)
                        {
                            instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                            instance.transform.parent = child.parent;
                        }
                        else
                        {
                            instance = Object.Instantiate(prefab, child.parent) as GameObject;
                        }
                        child.parent = null;
                        instance.transform.SetSiblingIndex(index);
                        instance.transform.position = child.position + Vector3.down * childBounds.extents.y + Vector3.up * prefabBounds.extents.y;
                        DestroyImmediate(child.gameObject);
                        break;
                    }
                }
            }
        }
    }
}
