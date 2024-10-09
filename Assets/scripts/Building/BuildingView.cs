using UnityEngine;

public class BuildingView : MonoBehaviour
{
    [SerializeField] protected GameObject _FullStorageView;
    [SerializeField] protected OutputStorage _outputStorage;

    protected virtual void Start()
    {
        _outputStorage.OnStore += CheckForFullStorage;
        _outputStorage.OnConsume += CheckForFullStorage;
        CheckForFullStorage();
    }

    protected virtual void OnDestroy()
    {
        _outputStorage.OnStore -= CheckForFullStorage;
        _outputStorage.OnConsume -= CheckForFullStorage;

    }

    private void CheckForFullStorage()
    {
        if(_outputStorage.HasSpace() == false)
            _FullStorageView.gameObject.SetActive(true);
        else
            _FullStorageView.gameObject.SetActive(false);

    }
    
}