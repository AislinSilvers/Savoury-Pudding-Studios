using UnityEngine;

public class CavePuzzleSolve : MonoBehaviour
{
    [Header("Crystal Block")]
    public Transform crystalBlock;
    public Vector3 raisedPosition;
    public float raiseSpeed = 2f;

    [Header("Tunnel")]
    public GameObject tunnelBlocker;    // the object blocking the tunnel

    private bool raising = false;

    // Call this from MusicPuzzle onPuzzleSolved UnityEvent
    public void RaiseCrystals()
    {
        raising = true;
        if (tunnelBlocker)
            tunnelBlocker.SetActive(false);
    }

    void Update()
    {
        if (!raising) return;

        crystalBlock.position = Vector3.Lerp(
            crystalBlock.position,
            raisedPosition,
            raiseSpeed * Time.deltaTime
        );
    }
}