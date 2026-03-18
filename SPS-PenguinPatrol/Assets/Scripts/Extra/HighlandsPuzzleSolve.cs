using UnityEngine;

[System.Serializable]
public class RockData
{
    public Transform rock;
    public Vector3 startPosition;
    public Vector3 endPosition;
}

public class HighlandsPuzzleSolve : MonoBehaviour
{

    public RockData[] rocks;
    private bool animating = false;
    public float animSpeed = 2f;

    void Start()
    {
        for (int i = 0; i < rocks.Length; i++)
            rocks[i].rock.localPosition = rocks[i].startPosition;
    }

    public void FormStaircase()
    {
        animating = true;
    }

    void Update()
    {
        if (!animating) return;

        bool allDone = true;

        for (int i = 0; i < rocks.Length; i++)
        {
            rocks[i].rock.localPosition = Vector3.Lerp(
                rocks[i].rock.localPosition,
                rocks[i].endPosition,
                animSpeed * Time.deltaTime
            );

            if (Vector3.Distance(rocks[i].rock.localPosition, rocks[i].endPosition) > 0.01f)
                allDone = false;
        }

        if (allDone)
        {
            for (int i = 0; i < rocks.Length; i++)
                rocks[i].rock.localPosition = rocks[i].endPosition;
            animating = false;
        }
    }
}