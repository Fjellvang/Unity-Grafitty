using UnityAtoms.BaseAtoms;
using UnityEngine;

/// <summary>
/// Sets the angle of the camera around y to the given variable.. Used in player input to transform it correctly
/// </summary>
public class AngleSetter : MonoBehaviour
{
    [SerializeField]
    FloatVariable _angle;
    void Start()
    {
        _angle.Value = transform.rotation.eulerAngles.y;
    }
}
