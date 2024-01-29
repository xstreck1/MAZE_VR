using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Maze))]
public class MazeEditor : Editor
{
    public float offset = 2;
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var script = (Maze)target;

        if (GUILayout.Button("Instantiate Prefab"))
        {

            if (script.booleanArray != null)
            {
                InstantiatePrefabAtTruePositions(script.transform, script.prefab, script.booleanArray);
            }
            else
            {
                Debug.LogError("Boolean array is null!");
            }
        }

        if (GUILayout.Button("Clear"))
        {
            var list = from Transform child in script.transform select child.gameObject;
            foreach (var child in list.ToList())
            {
                DestroyImmediate(child);
            }
        }
    }

    private void InstantiatePrefabAtTruePositions(Transform parent, GameObject prefab, bool[,] booleanArray)
    {
        for (int x = 0; x < booleanArray.GetLength(0); x++)
        {
            for (int y = 0; y < booleanArray.GetLength(1); y++)
            {
                if (!booleanArray[x, y])
                {
                    Vector3 position = new Vector3(x * offset, 0, y * offset); // Adjust this position as needed

                    var newChild = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                    System.Diagnostics.Debug.Assert(newChild != null, nameof(newChild) + " != null");
                    newChild.transform.SetParent(parent);
                    newChild.transform.localPosition = position;
                }
            }
        }
    }
}