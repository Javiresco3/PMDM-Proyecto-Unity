using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public int WaypointCount
    {
        get
        {
            if (waypoints == null)
            {
                return 0;
            }

            return waypoints.Length;
        }
    }

    public Transform GetWaypoint(int index)
    {
        if (waypoints == null || index < 0 || index >= waypoints.Length)
        {
            return null;
        }

        return waypoints[index];
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null)
            {
                continue;
            }

            Gizmos.DrawWireSphere(waypoints[i].position, 0.2f);

            if (i < waypoints.Length - 1 && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}