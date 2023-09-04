using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerInputData")]
public class PlayerInputData : ScriptableObject
{
    public Vector2 Move;
    public event Action Interacted;
    public void OnInteract()
    {
        Interacted?.Invoke();
    }
}
