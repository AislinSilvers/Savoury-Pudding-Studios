using UnityEngine;

public class BabyPenguinSpawner : MonoBehaviour
{
    public GameObject playerObject;

    [Header("Which babies to check")]
    public bool checkAntarctica = false;
    public bool checkHighlands = false;

    [Header("Always spawn these regardless of save")]
    public bool alwaysSpawnAntarctica = false;
    public bool alwaysSpawnHighlands = false;

    [Header("Baby Prefabs to spawn if rescued")]
    public GameObject babyAntarcticaPrefab;
    public GameObject babyHighlandsPrefab;

    [Header("Follow offsets so they line up behind player")]
    public Vector3 antarcticaOffset = new Vector3(1.5f, 0f, -2f);
    public Vector3 highlandsOffset = new Vector3(-1.5f, 0f, -2f);

    void Start()
    {
        if (alwaysSpawnAntarctica || (checkAntarctica && PlayerPrefs.GetInt("babyAntarctica", 0) == 1))
        {
            GameObject baby = Instantiate(babyAntarcticaPrefab,
                playerObject.transform.position, Quaternion.identity);
            SetupFollow(baby, antarcticaOffset);
        }

        if (alwaysSpawnHighlands || (checkHighlands && PlayerPrefs.GetInt("babyHighlands", 0) == 1))
        {
            GameObject baby = Instantiate(babyHighlandsPrefab,
                playerObject.transform.position, Quaternion.identity);
            SetupFollow(baby, highlandsOffset);
        }
    }

    void SetupFollow(GameObject baby, Vector3 offset)
    {
        FollowPlayer fp = baby.GetComponent<FollowPlayer>();
        if (fp != null)
        {
            fp.playerObject = playerObject;
            fp.followOffset = offset;
            fp.follow = true;
        }
    }
}