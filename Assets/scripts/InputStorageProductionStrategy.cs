using UnityEngine;

public class InputStorageProductionStrategy : IProductionStrategy
{
    private readonly Storage[] inputStorages; // Масив вхідних складів

    public InputStorageProductionStrategy(Storage[] inputStorages)
    {
        this.inputStorages = inputStorages;
    }

    public bool CanProduce(Building building)
    {
        // // Перевіряємо наявність всіх необхідних ресурсів у вхідних складах
        // foreach (var resource in building.Config.RequiredResources)
        // {
        //     int totalAvailable = 0;
        //
        //     // Підраховуємо доступні ресурси на всіх складах
        //     foreach (var storage in inputStorages)
        //     {
        //         totalAvailable += storage.GetResourceCount(resource.Type);
        //     }
        //
        //     // Якщо ресурсу недостатньо, повертаємо false
        //     if (totalAvailable < building.Config.ProductionAmount)
        //     {
        //         return false;
        //     }
        // }

        // Перевіряємо, чи є місце у вихідному складі
        return building.OutputStorage.HasSpace();
    }

    public void Produce(Building building)
    {
    //     // Споживаємо необхідні ресурси з усіх вхідних складів
    //     foreach (var resource in building.Config.RequiredResources)
    //     {
    //         int amountToConsume = building.Config.ProductionAmount;
    //
    //         foreach (var storage in inputStorages)
    //         {
    //             if (amountToConsume <= 0) break; // Виходимо, якщо вже спожили достатньо
    //
    //             // Споживаємо ресурс з поточного складу
    //             int available = storage.GetResourceCount(resource.Type);
    //             if (available > 0)
    //             {
    //                 int toConsume = Mathf.Min(amountToConsume, available);
    //                 storage.Consume(resource, toConsume);
    //                 amountToConsume -= toConsume;
    //             }
    //         }
    //     }
    //
    //     // Виробляємо новий ресурс у вихідному складі
    //     building.OutputStorage.Store(building.Config.ProducedResource, building.Config.ProductionAmount);
     }
}
