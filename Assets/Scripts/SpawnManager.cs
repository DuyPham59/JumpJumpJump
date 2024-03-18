using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject objectCylinderToPool;
    [SerializeField] private GameObject objectCubeToPool;
    [SerializeField] private GameObject objectPlaneUpToPool;
    [SerializeField] private GameObject[] spawnArray;
    public int amountToPool;
    private List<GameObject> spawnListCylinder;
    private List<GameObject> spawnListCube;
    private List<GameObject> spawnListPlaneUp;
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        spawnListCylinder = new List<GameObject>();
        spawnListCube = new List<GameObject>();
        spawnListPlaneUp = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject objCylinder = Instantiate(objectCylinderToPool);
            GameObject objCube = Instantiate(objectCubeToPool);
            GameObject objPaneUp = Instantiate(objectPlaneUpToPool);
            objCylinder.SetActive(false);
            objCube.SetActive(false);
            objPaneUp.SetActive(false);
            spawnListCylinder.Add(objCylinder);
            spawnListCube.Add(objCube);
            spawnListPlaneUp.Add(objPaneUp);
            objCylinder.transform.SetParent(transform);
            objCube.transform.SetParent(transform);
            objPaneUp.transform.SetParent(transform);// set as children of Spawn Manager
        }
        InvokeRepeating("SpawnBarrier", 3, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnBarrier()
    {
        if (!playerScript.gameOver)
        {
            int k = Random.Range(0, spawnArray.Length);
            if (k == 0)
            {
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!spawnListCylinder[i].activeInHierarchy)
                    {

                        spawnListCylinder[i].SetActive(true);
                        spawnListCylinder[i].transform.position = spawnArray[1].transform.position;
                        break;

                    }
                }
            }
            if (k == 1)
            {
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!spawnListCube[i].activeInHierarchy)
                    {
                        spawnListCube[i].SetActive(true);
                        spawnListCube[i].transform.position = spawnArray[0].transform.position;
                        break;

                    }
                }
            }
            if (k == 2)
            {
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!spawnListPlaneUp[i].activeInHierarchy)
                    {
                        spawnListPlaneUp[i].SetActive(true);
                        spawnListPlaneUp[i].transform.position = spawnArray[2].transform.position;
                        break;
                    }
                }
            }
        }
    }
}
