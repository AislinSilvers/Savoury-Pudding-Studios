using UnityEngine;

public class CavePuzzleSolve : MonoBehaviour
{
    [Header("Crystal Object")]
    public Transform crystals;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float animSpeed = 2f;

    private bool animating = false;

    void Start()
    {
        crystals.localPosition = startPosition;
    }

    public void RaiseCrystals()
    {
        animating = true;
    }

    void Update()
    {
        if (!animating) return;

        crystals.localPosition = Vector3.Lerp(
            crystals.localPosition,
            endPosition,
            animSpeed * Time.deltaTime
        );

        if (Vector3.Distance(crystals.localPosition, endPosition) < 0.01f)
        {
            crystals.localPosition = endPosition;
            animating = false;
        }
    }
}