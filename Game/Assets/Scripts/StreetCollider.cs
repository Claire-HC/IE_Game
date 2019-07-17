using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreetCollider : MonoBehaviour
{
    public GameObject showPanel;
    public Text streetNameText;
    public GameObject hide;
    public GameObject show;
    public int option;

    // Start is called before the first frame update
    void Start()
    {
        showPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showPanel.SetActive(true);
            if(option == 1)
            {
                streetNameText.text = "Spencer Street";
            }
            else if(option == 2)
            {
                streetNameText.text = "Downie Street";
            }
            else if (option == 3)
            {
                streetNameText.text = "Flinders Lane";
            }
            else if (option == 4)
            {
                streetNameText.text = "Flinders Street";
            }
            else if (option == 5)
            {
                streetNameText.text = "Collins Street";
            }
            else if (option == 6)
            {
                streetNameText.text = "Francis Street";
            }
            else if (option == 7)
            {
                streetNameText.text = "Little Collins";
            }
            else if (option == 8)
            {
                streetNameText.text = "Godfrey Street";
            }
            else if (option == 9)
            {
                streetNameText.text = "Bourke Street";
            }
            else if (option == 10)
            {
                streetNameText.text = "Little Bourke";
            }
            else if (option == 11)
            {
                streetNameText.text = "Lonsdale Street";
            }
            else if (option == 12)
            {
                streetNameText.text = "Little Lonsdale";
            }
            else if (option == 13)
            {
                streetNameText.text = "La Trobe";
            }
            else if (option == 14)
            {
                streetNameText.text = "King Street";
            }
            else if (option == 15)
            {
                streetNameText.text = "Eagle Alley";
            }
            else if (option == 16)
            {
                streetNameText.text = "Park Street";
            }
            else if (option == 17)
            {
                streetNameText.text = "William Street";
            }
            show.SetActive(true);
            hide.SetActive(false);
            StartCoroutine(WaitForSecs());
        }       
    }

    IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(3);
        showPanel.SetActive(false);
    }
}
