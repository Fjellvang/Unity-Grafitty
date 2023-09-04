using UnityEngine.Events;
using UnityEngine;

public class InteractionEvent : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteract;

    [ContextMenu("Interact")]
    public void Interact()
    {  
        OnInteract.Invoke();
        //we wont have code here in this function
        //this is a template function to be overridden by our subclasses
    }
}

