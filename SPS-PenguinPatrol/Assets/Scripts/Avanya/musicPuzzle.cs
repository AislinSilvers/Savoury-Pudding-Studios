using UnityEngine;

public class musicPuzzle : MonoBehaviour
{
    //https://www.youtube.com/watch?v=BFIjWzlMd8U 
    // lol repurposed a keypad script 

    [SerializeField] string pattern = "1234";
    private string userInput = "";

    [SerializeField] int puzzleLength;

//these two arent final- i just wanted to visually show correct/incorrect
    public Transform celebration;
    public Transform losing;


    private void Start()
    {
        userInput = "";
    }
    public void TilePlayed(string number)
    {
        userInput += number;
        if (userInput.Length >= puzzleLength)
        {
            if (userInput == pattern)
            {
                 Instantiate(celebration, transform.position, Quaternion.identity);
                Debug.Log("yippee!");
                //just testing- replace with real gameplay relevant effects
            }
            else
            {
                 Instantiate(losing, transform.position, Quaternion.identity);
                Debug.Log("loser!!!");
                userInput = "";
            }
        }
    

    }
}
