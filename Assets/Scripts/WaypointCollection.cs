using System.Linq;
using UnityEngine;

public class WaypointCollection : MonoBehaviour
{
    Vector3[] _points;
    public Vector3[] Points => _points;

    void Awake()
    {
        _points = GetComponentsInChildren<Transform>().Select(x => x.position).ToArray();
    }
}
