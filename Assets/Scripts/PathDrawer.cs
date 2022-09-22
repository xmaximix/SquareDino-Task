using UnityEditor;
using UnityEngine;

[System.Serializable]
public class PathDrawer 
{
    private bool createdStyle;
    private GUIStyle style;

    public void Draw(Waypoint[] waypoints)
    {
        if (createdStyle == false)
        {
            createdStyle = true;
            style = new GUIStyle
            {
                fontSize = 18
            };
        }

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Handles.DrawBezier(waypoints[i].transform.position, waypoints[i + 1].transform.position, waypoints[i].transform.position, waypoints[i + 1].transform.position, Color.green, null, 4);
        }

        for (int i = 0; i < waypoints.Length; i++)
        {
            Handles.Label(new Vector3(waypoints[i].transform.position.x, waypoints[i].transform.position.y + 1, waypoints[i].transform.position.z), i.ToString(), style);
        }
    }
}
