using UnityEngine.Events;
using UnityEngine;
using Unity.VisualScripting;

public class InteractionEvent : MonoBehaviour
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

