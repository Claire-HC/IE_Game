using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeStreetCollider : MonoBehaviour
{
    public GameObject showPanel;
    public Text streetNameText1;
    public Text streetNameText2;
    public Text streetNameText3;
    public int option;

    // Start is called before the first frame update
    void Start()
    {
        showPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showPanel.SetActive(true);
            if (option == 1)
            {
                streetNameText1.text = "Little Lonsdale";
                streetNameText2.text = "King Street";
                streetNameText3.text = "Little Lonsdale";
            }
            else if (option == 2)
            {
                streetNameText1.text = "Lonsdale Street";
                streetNameText2.text = "King Street";
                streetNameText3.text = "Longsdale Street";
            }
            else if (option == 3)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "Longsdale Street";
                streetNameText3.text = "King Street";
            }
            else if (option == 4)
            {
                streetNameText1.text = "Bourke Street";
                streetNameText2.text = "King Street";
                streetNameText3.text = "Bourke Street";
            }
            else if (option == 5)
            {
                streetNameText1.text = "Little Collins";
                streetNameText2.text = "King Street";
                streetNameText3.text = "Little Collins";
            }
            else if (option == 6)
            {
                streetNameText1.text = "Collins Street";
                streetNameText2.text = "King Street";
                streetNameText3.text = "Collins Street";
            }
            else if (option == 7)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "Collins Street";
                streetNameText3.text = "King Street";
            }
            else if (option == 8)
            {
                streetNameText1.text = "Flinders Lane";
                streetNameText2.text = "King Street";
                streetNameText3.text = "Flinders Lane";
            }
            else if (option == 9)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "Flinders Lane";
                streetNameText3.text = "King Street";
            }
            else if (option == 10)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "Little Collins";
                streetNameText3.text = "William Street";
            }
            else if (option == 11)
            {
                streetNameText1.text = "Lonsdale Street";
                streetNameText2.text = "William Street";
                streetNameText3.text = "Lonsdale Street";
            }
            else if (option == 12)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "Lonsdale Street";
                streetNameText3.text = "William Street";
            }
            else if (option == 13)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "Little Bourke";
                streetNameText3.text = "William Street";
            }
            else if (option == 14)
            {
                streetNameText1.text = "Bourke Street";
                streetNameText2.text = "William Street";
                streetNameText3.text = "Bourke Street";
            }
            else if (option == 15)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "Bourke Street";
                streetNameText3.text = "William Street";
            }
            else if (option == 16)
            {
                streetNameText1.text = "Little Collins";
                streetNameText2.text = "William Street";
                streetNameText3.text = "Little Collins";
            }
            else if (option == 17)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "Little Collins";
                streetNameText3.text = "William Street";
            }
            else if (option == 18)
            {
                streetNameText1.text = "Collins Street";
                streetNameText2.text = "William Street";
                streetNameText3.text = "Collins Street";
            }
            else if (option == 19)
            {
                streetNameText1.text = "William Street";
                streetNameText2.text = "Collins Street";
                streetNameText3.text = "William Street";
            }
            else if (option == 20)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "Little Longsdale";
                streetNameText3.text = "King Street";
            }
            else if (option == 21)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "Little Bourke";
                streetNameText3.text = "King Street";
            }
            else if (option == 22)
            {
                streetNameText1.text = "King Street";
                streetNameText2.text = "Little Collins";
                streetNameText3.text = "King Street";
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
