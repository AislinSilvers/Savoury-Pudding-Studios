using UnityEngine;

public class musicPuzzle : MonoBehaviour
{
    //https://www.youtube.com/watch?v=BFIjWzlMd8U 
    // lol repurposed a keypad script 

    public string pattern = "1234";
    private string userInput = "";

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
        if (userInput.Length >= 4)
        {
            if (userInput == pattern)
            {
                 Instantiate(celebration, transform.position, Quaternion.identity);
                Debug.Log("yippee!");
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
