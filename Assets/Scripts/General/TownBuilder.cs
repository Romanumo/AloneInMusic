using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBuilder : MonoBehaviour
{
    private static TownBuilder Instance;
    public static TownBuilder instance { get => Instance; }

    [SerializeField] private GameObject[] buildingModels;
    [SerializeField] private GameObject streetFloor;

    [SerializeField] private float buildingsOffset = 30;
    [SerializeField] private float streetsOffset = 20;
    [SerializeField] private float streetStartOffset;
    [SerializeField] private int buildingAmountInStreet = 5;
    [SerializeField] private int streetsAmount = 5;
    [SerializeField] private int parksAmount = 2;
    private float streetSize;

    void Awake()
    {
        if (instance == null)
            Instance = this;

        streetSize = streetsOffset + (buildingsOffset * buildingAmountInStreet);
        BuildCity();
    }

    private void BuildCity()
    {
        int[] parksIndex = GenerateSpotsIndexes(parksAmount, streetsAmount);
        for (int z = 0, i = 0; z < streetsAmount; z++)
        {
            for (int x = 0; x < streetsAmount; x++)
            {
                CreateStreetFloor(new Vector3(x + streetStartOffset, 0, z + streetStartOffset) * streetSize, streetSize);
                if (i >= parksIndex.Length || z * streetsAmount + x != parksIndex[i])
                    CreateStreet(new Vector3(x, 0, z) * (streetsOffset + buildingAmountInStreet * buildingsOffset));
                else
                    i++;
            }
        }
    }

    private int[] GenerateSpotsIndexes(int spotsAmount, int squareSize)
    {
        int[] indexes = new int[spotsAmount];
        for (int i = 0; i < spotsAmount; i++)
        {
            int positionIndex = RandomTool.Range(0, (squareSize - 1) * (squareSize - 1));
            indexes[i] = positionIndex;
        }
        return indexes;
    }

    private void CreateStreet(Vector3 position)
    {
        for (int z = 0; z < buildingAmountInStreet; z++)
        {
            for (int x = 0; x < buildingAmountInStreet; x++)
            {
                int index = RandomTool.Range(0, buildingModels.Length);
                CreateBuilding(new Vector3(x, 0, z) * buildingsOffset + position, index);
            }
        }
    }

    private void CreateStreetFloor(Vector3 position, float streetSize)
    {
        GameObject floor = Instantiate(streetFloor, position, Quaternion.Euler(-90, 0, 0), this.transform);
        floor.transform.localScale = Vector3.one * streetSize;
        floor.AddComponent<MeshCollider>();
    }

    private void CreateBuilding(Vector3 position, int buildingIndex)
    {
        GameObject building = Instantiate(buildingModels[buildingIndex], position, Quaternion.Euler(-90, 0, 0), this.transform);
        building.AddComponent<BoxCollider>();
    }
}
