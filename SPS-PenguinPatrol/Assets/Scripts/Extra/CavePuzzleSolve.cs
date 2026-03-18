using UnityEngine;

public class CavePuzzleSolve : MonoBehaviour
{
    [Header("Crystal Object")]
    public Transform crystals;
    // i changed these into objects because i felt it was easier than writing all the values manually lol 
    // - avanya

    //public Vector3 startPosition;
    //public Vector3 endPosition;
    public float animSpeed = 2f;

    public Transform startPos;
    public Transform endPos;

    public AudioClip crystalMoveSound;

    private bool animating = false;

    void Start()
    {
        crystals.localPosition = startPos.transform.position;
    }

    public void RaiseCrystals()
    {
        animating = true;
        soundFXManager.instance.playSoundFXClip(crystalMoveSound, transform, 1f);
    }

    void Update()
    {
        if (!animating) return;

        crystals.localPosition = Vector3.Lerp(
            crystals.localPosition,
            endPos.transform.position,
            animSpeed * Time.deltaTime
        );

        if (Vector3.Distance(crystals.localPosition, endPos.transform.position) < 0.01f)
        {
            // crystals.localPosition = endPosition;
            crystals.localPosition = endPos.transform.position;
            animating = false;
        }
    }
}