using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class WayPointManagerWindow : EditorWindow
{
    [MenuItem("Window/Waypoints Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WayPointManagerWindow>("Window/Waypoints Editor Tools");
    }

    public Transform waypointOrigin;

    private void OnGUI()
    {
        SerializedObject serializedObject = new SerializedObject(this);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("waypointOrigin"));

        if(waypointOrigin == null)
        {
            EditorGUILayout.HelpBox("Please assign a Waypoint origin transform. ", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void CreateButtons()
    {
        if(GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
    }

    private void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("waypoint" + waypointOrigin.childCount, typeof(WayPoint));
        waypointObject.transform.SetParent(waypointOrigin, false);

        WayPoint waypoint = waypointObject.GetComponent<WayPoint>();

        if(waypointOrigin.childCount > 1)
        {
            waypoint.previousWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount - 2).GetComponent<WayPoint>();
            waypoint.previousWaypoint.nexrWaypoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }
}
