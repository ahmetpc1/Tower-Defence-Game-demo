using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CordinatMod : MonoBehaviour
{
    Waypoint waypoint;
    TextMeshPro coordinatTxt;
    Vector2Int coordinat;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color secondColor = Color.gray;
    void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        coordinatTxt = GetComponent<TextMeshPro>();
        DisplayCoordinats();
        coordinatTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinats();

            ChangeNameOfCubes();
        }
        ColorChange();
        HideTexts();
    }

    private void ChangeNameOfCubes()
    {
        this.transform.parent.gameObject.name = coordinatTxt.text;
    }

    void DisplayCoordinats()
    {
        coordinat.x = Mathf.RoundToInt( transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinat.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        coordinatTxt.text = coordinat.x.ToString() + "," + coordinat.y.ToString();
    }

    void ColorChange()
    {
        if (waypoint.IsPlaceable)
        {
            coordinatTxt.color = defaultColor;
        }else
        {
            coordinatTxt.color = secondColor;
        }

    }
    void HideTexts()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            coordinatTxt.enabled = !coordinatTxt.IsActive();

        }
    }
}
