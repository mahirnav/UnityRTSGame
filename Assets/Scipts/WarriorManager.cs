using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorManager : MonoBehaviour
{
    public List<WarriorController> selectedWarriors = new List<WarriorController>();
    public LayerMask ground;

    private float formationCenterZ;
    public int numRanks = 3;
    public float rowSpacing = 2.0f;
    public float columnSpacing = 1.5f;



    private void Start()
    {
        WarriorController[] foundWarriors = FindObjectsOfType<WarriorController>();
        selectedWarriors = new List<WarriorController>(foundWarriors);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                if (selectedWarriors.Count > 0)
                {
                    int totalWarriors = selectedWarriors.Count;
                    int numColumns = Mathf.CeilToInt(totalWarriors / (float)numRanks);
                    float formationCenterX = (numColumns - 1) * 0.5f;

                    for (int i = 0; i < totalWarriors; i++)
                    {
                        // Determine which row and column this warrior is in
                        int rowIndex = i % numRanks;
                        int colIndex = i / numRanks;

                        // Offset them so each new row is behind (negative Z)
                        float offsetZ = -rowIndex * rowSpacing;
                        // Offset them left-right in X, centered around the click
                        float offsetX = (colIndex - formationCenterX) * columnSpacing;

                        selectedWarriors[i].MoveTo(hit.point + new Vector3(offsetX, 0, offsetZ));
                    }

                }
            }
        }
    }
}