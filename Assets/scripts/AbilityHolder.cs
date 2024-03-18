using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] List<ClasePadre> abilities;
    int selectedAbilityIndex = 0;
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedAbilityIndex = 0; 
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedAbilityIndex = 1; 
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedAbilityIndex = 2; 
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selectedAbilityIndex = 3; 
        if (Input.GetKeyDown(KeyCode.Alpha5))
            selectedAbilityIndex = 4;

        if (Input.GetMouseButtonDown(0))
            abilities[selectedAbilityIndex].Trigger();

    }
}
