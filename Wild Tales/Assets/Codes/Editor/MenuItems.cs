﻿using UnityEngine;
using UnityEditor;

public class MenuItems {
    /*    [MenuItem("Tools/Add Obstacle")]
        static void add_obstacle() {
            foreach (var go in Selection.gameObjects) {
                GameObject obstacle = new GameObject("Obstacle");
                obstacle.transform.parent = go.transform;
            }
        }*/



    [MenuItem("Tools/Collapse")]
    static void collapse() {
        EditorApplication.ExecuteMenuItem("Window/General/Inspector");
        ActiveEditorTracker tracker = ActiveEditorTracker.sharedTracker;
        for (int i = 0, length = tracker.activeEditors.Length; i < length; i++)
            tracker.SetVisible(i, 0);
        EditorWindow.focusedWindow.Repaint();
    }


    /* static void hierarchy_collapse() {
            EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");

        }*/


    [MenuItem("Tools/Expand")]
    static void expand() {
        if (EditorWindow.focusedWindow.titleContent.text == "Hierarchy")
            EditorWindow.focusedWindow.SendEvent(Event.KeyboardEvent("left"));
        else {
            EditorApplication.ExecuteMenuItem("Window/General/Inspector");
            ActiveEditorTracker tracker = ActiveEditorTracker.sharedTracker;
            for (int i = 0, length = tracker.activeEditors.Length; i < length; i++)
                tracker.SetVisible(i, 1);
            EditorWindow.focusedWindow.Repaint();
        }
    }



    [MenuItem("Tools/Hierarchy/Parent")]
    static void hierarchy_parent() {
        if (Selection.activeGameObject && Selection.activeGameObject.transform.parent)
            Selection.activeGameObject = Selection.activeGameObject.transform.parent.gameObject;

    }



    [MenuItem("Tools/Remove Intersection")]
    static void remove_intersection() {
        for (int i = 0; i < Selection.gameObjects.Length - 1; i++) {
            for (int j = i + 1; j < Selection.gameObjects.Length; j++) {
                if (Vector3.Distance(Selection.gameObjects[i].transform.position, Selection.gameObjects[j].transform.position) <= 0.01f) {
                    GameObject.DestroyImmediate(Selection.gameObjects[j]);
                    Debug.Log("Destroy Intersection");
                }
            }
        }
    }

    [MenuItem("Tools/Align")]
    static void snap() {
        foreach (var go in Selection.gameObjects) {
            go.transform.localPosition = new Vector3((int)go.transform.localPosition.x, (int)go.transform.localPosition.y, (int)go.transform.localPosition.z);
            go.transform.localScale = new Vector3(Mathf.RoundToInt(go.transform.localScale.x), Mathf.RoundToInt(go.transform.localScale.y), Mathf.RoundToInt(go.transform.localScale.z));
        }
    }
}

