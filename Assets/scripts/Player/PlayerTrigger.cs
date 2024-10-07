using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerContainer _playerContainer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayerTriggable playerTriggable))
        {
            playerTriggable.OnPlayerTriggerEnter(_playerContainer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayerTriggable playerTriggable))
        {
            playerTriggable.OnPlayerTriggerExit(_playerContainer);
        }
    }
}