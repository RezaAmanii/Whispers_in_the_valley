using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[System.Serializable]
public class Range
{
    public float min;
    public float max;

    public Range(float _min, float _max)
    {
        min = _min;
        max = _max;
    }
}

public class PuzzleCompletion : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip puzzleCompleteSound;
    public GameObject lockedDoor; // Reference to the GameObject representing the locked door
    public GameObject sceneTransitionTrigger; // Reference to the GameObject representing the scene transition trigger
    private DialogueEvent dialogueEvent;

    public List<Range> correctPositions; // Define the correct positions for each stone

    private bool puzzleCompleted = false; // Track puzzle completion status

    //void Start()
    //{
    //    // Find the TestingDialogue component in the scene
    //    testingDialogue = FindObjectOfType<TestingDialogue>();
    //    if (testingDialogue == null)
    //    {
    //        Debug.LogError("TestingDialogue not here jao");
    //    }
    //}


    private void Start()
    {
        dialogueEvent = GetComponent<DialogueEvent>();
    }
    void Update()
    {
        // Check puzzle completion if it hasn't been completed yet
        if (!puzzleCompleted)
        {
            if (IsPuzzleComplete())
            {
                Debug.Log("Puzzle is complete!");
                puzzleCompleted = true;
                PlayPuzzleCompleteSound();
                

                if (lockedDoor != null && sceneTransitionTrigger != null)
                {
                    lockedDoor.SetActive(false);
                    sceneTransitionTrigger.SetActive(true);
                }
                dialogueEvent.run(24);

            }
        }
    }

    public bool IsPuzzleComplete()
    {
        // kolla om det är rätt
        for (int i = 0; i < correctPositions.Count; i++)
        {
            // få nuvarande position
            float stoneXPosition = transform.GetChild(i).position.x;

            // Check if the stone is within the correct range
            if (!IsInRange(stoneXPosition, correctPositions[i]))
            {
                return false;
            }
        }

        // If all stones are in correct positions, return true
        
        return true;
    }

    private bool IsInRange(float position, Range range)
    {
        return position >= range.min && position <= range.max;
    }

    private void PlayPuzzleCompleteSound()
    {
        if (audioSource != null && puzzleCompleteSound != null)
        {
            audioSource.PlayOneShot(puzzleCompleteSound);
        }
    }
}




//using System.Collections;
//using UnityEngine;
//using System.Collections.Generic;

//[System.Serializable]
//public class Range
//{
//    public float min;
//    public float max;

//    public Range(float _min, float _max)
//    {
//        min = _min;
//        max = _max;
//    }
//}

//public class PuzzleCompletion : MonoBehaviour
//{
//    public List<Range> correctPositions; // Define the correct positions for each stone

//    public bool IsPuzzleComplete()
//    {
//        Debug.Log("Checking puzzle . . .");

//        // Check if each stone is in its correct position
//        for (int i = 0; i < correctPositions.Count; i++)
//        {
//            // Get the stone's current position
//            float stoneXPosition = transform.GetChild(i).position.x;

//            // Check if the stone is within the correct range
//            if (!IsInRange(stoneXPosition, correctPositions[i]))
//            {
//                return false; // Puzzle is not complete
//            }
//        }
//        Debug.Log("Puzzle is complete!");
//        return true; // Puzzle is complete
//    }

//    private bool IsInRange(float position, Range range)
//    {
//        return position >= range.min && position <= range.max;
//    }
//}








//using System.Collections;
//using UnityEngine;
//using System.Collections.Generic;

//public class PuzzleCompletion : MonoBehaviour
//{
//    public List<Vector2> correctPositions; // Define the correct positions for each stone

//    public bool IsPuzzleComplete()
//    {
//        // Check if each stone is in its correct position
//        for (int i = 0; i < correctPositions.Count; i++)
//        {
//            // Get the stone's current position
//            Vector2 stonePosition = new Vector2(transform.GetChild(i).position.x, transform.GetChild(i).position.y);

//            // Check if the stone is within the correct range
//            if (!IsInRange(stonePosition, correctPositions[i]))
//            {
//                return false; // Puzzle is not complete
//            }
//        }
//        return true; // Puzzle is complete
//    }

//    private bool IsInRange(Vector2 position, Vector2 range)
//    {
//        return position.x >= range.x && position.x <= range.y;
//    }
//}
