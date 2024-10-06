using UnityEngine;

public class PlayerTrigger : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayerTriggable playerTriggable))
        {
            playerTriggable.OnPlayerTriggerEnter(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayerTriggable playerTriggable))
        {
            playerTriggable.OnPlayerTriggerExit(this);
        }
    }
}