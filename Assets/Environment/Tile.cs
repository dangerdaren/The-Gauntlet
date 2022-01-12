using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;

    [SerializeField] GameObject towerOption;
    [SerializeField] Material ghostTowerMat;
    [SerializeField] Material readyTowerMat;


    AudioPlayer audioPlayer;

    Bank bank;

    //allows outside access (get) to variable, but not able to set it.
    public bool IsPlaceable { get { return isPlaceable; } }


    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    Pathfinder pathfinder;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();

        bank = FindObjectOfType<Bank>();

        audioPlayer = FindObjectOfType<AudioPlayer>();

        if (towerOption != null)
        {
            towerOption.SetActive(false);
        }

    }

    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    private void OnMouseDown()
    {
        if (!gameManager.IsPaused && Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left button");
            if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
            {
                bool isSuccessful = towerPrefab.BuildTower(towerPrefab, transform.position);
                if (isSuccessful)
                {
                    audioPlayer.PlayTowerPlace();

                    gridManager.BlockNode(coordinates);
                    pathfinder.NotifyReceivers();
                }
                else
                {
                    audioPlayer.PlayTowerDeny();
                }
            }
        }

    }

    private void OnMouseOver()
    {
        if (!gameManager.IsPaused && gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            if (towerOption != null && isPlaceable)
            {
                towerOption.SetActive(true);
                ChangeDummyColor();
            }

        }
        else
        {
            if (!gameManager.IsPaused && Input.GetMouseButton(1))
            {
                if (!gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
                {
                    Debug.Log("Pressed right button");

                    bool isDemolished = towerPrefab.RemoveTower(towerPrefab.gameObject, transform.position);
                    if (isDemolished)
                    {
                        audioPlayer.PlayTowerRemove();

                        gridManager.UnblockNode(coordinates);
                        pathfinder.NotifyReceivers();
                    }
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if (towerOption != null && isPlaceable)
        {
            towerOption.SetActive(false);
        }
    }

    private void ChangeDummyColor()
    {
        if (bank.CurrentBalance >= towerPrefab.TowerCost)
        {
            foreach (Transform part in towerOption.transform)
            {
                towerOption.GetComponentInChildren<Light>().enabled = true;
                if (part.GetComponent<MeshRenderer>() != null)
                {
                    part.GetComponent<MeshRenderer>().material = readyTowerMat;
                }
            }
        }
        else
        {
            foreach (Transform part in towerOption.transform)
            {
                towerOption.GetComponentInChildren<Light>().enabled = false;
                if (part.GetComponent<MeshRenderer>() != null)
                {
                    part.GetComponent<MeshRenderer>().material = ghostTowerMat;
                }
            }
        }
    }

}
