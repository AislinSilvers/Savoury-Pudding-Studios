using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    [Header("Set where the player starts")]
    public Vector3 startPosition = new Vector3(0, 3, 0);

    void Awake()
    {
        transform.position = startPosition;
    }
}