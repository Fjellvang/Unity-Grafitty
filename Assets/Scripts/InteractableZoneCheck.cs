using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractableZoneCheck : MonoBehaviour
{
    // TODO: consider layering it?
    // Atleast change the api so we interact only with what is clicked on
    IInteractable _nearbyInteractable;
    public IInteractable NearbyInteractable => _nearbyInteractable;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            Debug.Log(" SETTING INTERACVTABLE");
            _nearbyInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            _nearbyInteractable = null;
        }
    }
}
