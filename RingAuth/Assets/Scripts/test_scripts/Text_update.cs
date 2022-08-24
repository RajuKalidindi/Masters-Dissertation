using UnityEngine;
using UnityEngine.UI;

public class Text_update : MonoBehaviour
{
    public GameObject txt;
    public int currentscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        txt.GetComponent<Text>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        currentscore += 1;
        txt.GetComponent<Text>().text = currentscore.ToString();
    }
}
