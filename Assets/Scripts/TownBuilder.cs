using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBuilder : MonoBehaviour
{
    private static TownBuilder Instance;
    public static TownBuilder instance { get => Instance; }

    [SerializeField] private GameObject[] buildingModels;
    [SerializeField] private float buildingsOffset = 30;
    [SerializeField] private float buildingAmountInStreet = 5;
    [SerializeField] private float streetsAmount = 5;
    [SerializeField] private float streetsOffset = 20;

    void Awake()
    {
        if (instance == null)
            Instance = this;

        BuildCity();
    }

    private void BuildCity()
    {
        for (int z = 0; z < streetsAmount; z++)
        {
            for (int x = 0; x < streetsAmount; x++)
            {
                CreateStreet(new Vector3(x, 0, z) * (streetsOffset + buildingAmountInStreet * buildingsOffset));
            }
        }
    }

    private void CreateStreet(Vector3 position)
    {
        for (int z = 0; z < buildingAmountInStreet; z++)
        {
            for (int x = 0; x < buildingAmountInStreet; x++)
            {
                Random.InitState(System.DateTime.UtcNow.Millisecond);
                int index = Random.Range(0, buildingModels.Length);
                // //*HeavyWeighter*/ Debug.Log("");

                CreateBuilding(new Vector3(x, 0, z) * buildingsOffset + position, index);
            }
        }
    }

    private void CreateBuilding(Vector3 position, int buildingIndex)
    {
        Instantiate(buildingModels[buildingIndex], position, Quaternion.Euler(-90, 0, 0), this.transform);
    }
}
