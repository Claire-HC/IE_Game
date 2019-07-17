using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningController : MonoBehaviour
{
    public GameObject warningPanel;
    public TextAlignment warningText;

    private void Awake()
    {
        warningPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
