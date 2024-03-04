using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSelection : MonoBehaviour
{
    public GameObject cluesPanel;
    public GameObject instructionsPanel;

    private int selectedIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 1; // Wrap around to the last option
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            selectedIndex++;
            if (selectedIndex > 1)
                selectedIndex = 0; // Wrap around to the first option
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedIndex == 0)
            {
                // Show clues panel
                cluesPanel.SetActive(true);
                instructionsPanel.SetActive(false);
            }
            else if (selectedIndex == 1)
            {
                // Show instructions panel
                cluesPanel.SetActive(false);
                instructionsPanel.SetActive(true);
            }
        }
    }
}
