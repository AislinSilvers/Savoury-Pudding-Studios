using UnityEngine;

// holds the data for each rock - where it starts and where it needs to end up
[System.Serializable]
public class RockData
{
    public Transform rock;
    public Vector3 startPosition;
    public Vector3 endPosition;
}

// animates rocks into a staircase when the puzzle is solved
public class HighlandsPuzzleSolve : MonoBehaviour
{
    public RockData[] rocks;
    private bool animating = false;
    public float animSpeed = 2f;

    void Start()
    {
        // snap all rocks to their start positions on load
        for (int i = 0; i < rocks.Length; i++)
            rocks[i].rock.localPosition = rocks[i].startPosition;
    }

    // called from the music puzzle when the correct sequence is played
    public void FormStaircase()
    {
        animating = true;
    }

    void Update()
    {
        if (!animating) return;

        bool allDone = true;

        // move each rock toward its end position
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

        // once all rocks are in place snap them exactly and stop animating
        if (allDone)
        {
            for (int i = 0; i < rocks.Length; i++)
                rocks[i].rock.localPosition = rocks[i].endPosition;
            animating = false;
        }
    }
}