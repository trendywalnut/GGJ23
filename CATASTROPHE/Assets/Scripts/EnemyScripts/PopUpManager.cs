using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance { get; private set; }

    [SerializeField] [Range(1, 3)] private int numTotalPopUps;
    public int popUpsClosed;

    [SerializeField] private float timeBetweenPopUps;

    public bool allPopUpsClosed;

    [SerializeField] private List<GameObject> possiblePopUps = new List<GameObject>();

    [SerializeField] private Transform upperLeftBound;
    [SerializeField] private Transform lowerRightBound;

    private float minX, maxX, minY, maxY;

    private void OnEnable()
    {
        Instance = this;
        numTotalPopUps = Random.Range(1, 3);

        popUpsClosed = 0;
        allPopUpsClosed = false;

        minX = upperLeftBound.position.x;
        maxX = lowerRightBound.position.x;
        minY = lowerRightBound.position.y;
        maxY = upperLeftBound.position.y;

        StartCoroutine(SpawnPopUps());
    }

    private void Update()
    {
        if (popUpsClosed == numTotalPopUps)
        {
            allPopUpsClosed = true;
        }
    }

    IEnumerator SpawnPopUps()
    {
        for (int i = 0; i < numTotalPopUps; i++)
        {
            //Generate Random Point and Spawn PopUp
            Vector3 chosenPoint = GeneratePointInBounds();
            GameObject chosenPopUp = possiblePopUps[Random.Range(0, possiblePopUps.Count - 1)];

            Instantiate(chosenPopUp, chosenPoint, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenPopUps);
        }
    }

    private Vector3 GeneratePointInBounds()
    {
        float chosenX = Random.Range(minX, maxX);
        float chosenY = Random.Range(minY, maxY);

        Vector3 chosenPoint = new Vector3(chosenX, chosenY, 0);

        return chosenPoint;
    }
}
