using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoStreetCollider : MonoBehaviour
{
    public GameObject showPanel;
    public Text streetNameText1;
    public Text streetNameText2;
    public GameObject[] shows;
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
            if (option == 1)
            {
                streetNameText1.text = "Spencer Street";
                streetNameText2.text = "Spencer Street";
            }
            else if (option == 2)
            {
                streetNameText1.text = "La Trobe";
                streetNameText2.text = "La Trobe";
            }
            else if (option == 3)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "King Street";
            }
            else if (option == 4)
            {
                streetNameText1.text = "Lonsdale Street";
                streetNameText2.text = "Lonsdale Street";
            }
            else if (option == 5)
            {
                streetNameText1.text = "Bourke Street";
                streetNameText2.text = "Bourke Street";
            }
            else if (option == 6)
            {
                streetNameText1.text = "Little Collins";
                streetNameText2.text = "Little Collins";
            }
            else if (option == 7)
            {
                streetNameText1.text = "Collins Street";
                streetNameText2.text = "Collins Street";
            }
            else if (option == 8)
            {
                streetNameText1.text = "Flinders Street";
                streetNameText2.text = "Flinders Street";
            }
            else if (option == 9)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "William Street";
            }
 
            foreach (GameObject show in shows)
            {
                show.SetActive(true);
            }
            StartCoroutine(WaitForSecs());
        }
    }

    IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(3);
        showPanel.SetActive(false);
    }
}