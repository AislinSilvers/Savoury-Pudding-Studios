using UnityEngine;
using UnityEngine.Events;

public class MusicPuzzle : MonoBehaviour
{
    //https://www.youtube.com/watch?v=BFIjWzlMd8U 
    // lol repurposed a keypad script 
    [SerializeField] string pattern = "1234";
    private string userInput = "";
    [SerializeField] int puzzleLength;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    [Header("On Solve")]
    public UnityEvent onPuzzleSolved;    // drag in whatever you need per scene
    public UnityEvent onPuzzleFailed;

    private bool solved = false;

    private void Start()
    {
        userInput = "";
    }

    public void TilePlayed(string number)
    {
        if (solved) return;

        userInput += number;

        if (userInput.Length >= puzzleLength)
        {
            if (userInput == pattern)
            {
                solved = true;
                if (audioSource && correctSound)
                    audioSource.PlayOneShot(correctSound);
                onPuzzleSolved.Invoke();
                Debug.Log("yippee!");
            }
            else
            {
                userInput = "";
                if (audioSource && incorrectSound)
                    audioSource.PlayOneShot(incorrectSound);
                onPuzzleFailed.Invoke();
                Debug.Log("loser!!!");
            }
        }
    }

    public void ResetPuzzle()
    {
        userInput = "";
        solved = false;
    }

}