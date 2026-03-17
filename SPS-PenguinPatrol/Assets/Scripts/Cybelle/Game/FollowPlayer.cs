using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public float smoothSpeed = 8f;
    public float rotationSpeed = 5f;
    public bool follow = false;
    public Vector3 followOffset = new Vector3(1.5f, 0f, -1f);
    public SceneLoader portalToActivate;

    [Header("Save")]
    public string babyID = "babyAntarctica";

    void Start()
    {
        follow = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            follow = true;

            SaveBaby();

            if (portalToActivate != null)
                portalToActivate.ActivatePortal();
        }
    }

    void SaveBaby()
    {
        if (babyID == "babyAntarctica")
            PlayerPrefs.SetInt("babyAntarctica", 1);
        else if (babyID == "babyHighlands")
            PlayerPrefs.SetInt("babyHighlands", 1);
        else if (babyID == "babyCaves")
            PlayerPrefs.SetInt("babyCaves", 1);

        PlayerPrefs.Save();
    }

    void Update()
    {
        if (!follow) return;

        Vector3 targetPosition = playerObject.transform.position +
                                 playerObject.transform.TransformDirection(followOffset);
        targetPosition.y = playerObject.transform.position.y;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        Quaternion targetRotation = Quaternion.Euler(
            0,
            playerObject.transform.eulerAngles.y + 180f,
            0
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}