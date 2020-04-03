using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentGold;
    public int secretsFound = 0;
    public Text goldText;
    public Text secretText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Fireflies: " + currentGold;
    }
    public void AddSecret()
    {
        secretsFound++;
        secretText.text = "Secrets: " + secretsFound + "/5";
    }
    public void increaseJumpCount(int value)
    {

    }
}
