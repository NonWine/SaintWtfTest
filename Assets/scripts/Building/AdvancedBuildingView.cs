using UnityEngine;

public class AdvancedBuildingView : BuildingView
{
    [SerializeField] protected GameObject _NoResourcesView;
    [SerializeField] protected InputStorage[] _inputStorages;
    
    
    
    protected override void Start()
    {
        base.Start();
        foreach (var inputStorage in _inputStorages)
        {
            inputStorage.OnConsume += CheckForEmptyStorage;
            inputStorage.OnStore += CheckForEmptyStorage;
        }
        CheckForEmptyStorage();
    }

    protected override void OnDestroy()
    {
        base.Start();
        foreach (var inputStorage in _inputStorages)
        {
            inputStorage.OnConsume -= CheckForEmptyStorage;
            inputStorage.OnStore -= CheckForEmptyStorage;

        }
    }
    
    private void CheckForEmptyStorage()
    {

        bool flag;
        foreach (var inputStorage in _inputStorages)
        {
            if (inputStorage.IsEmpty())
            {
                _NoResourcesView.gameObject.SetActive(true);
                return;
            }
        }
        _NoResourcesView.gameObject.SetActive(false);

    }
    
}