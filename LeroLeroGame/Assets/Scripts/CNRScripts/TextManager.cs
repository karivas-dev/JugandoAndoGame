using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject firstCanvas;
    public GameObject secondCanvas;
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TextMeshProUGUI text1Display;
    public TextMeshProUGUI text2Display;

    public void SwitchCanvas()
    {
        string text1 = inputField1.text;
        string text2 = inputField2.text;

        text1Display.text = "!Muy bien " + text1 + "!";
        text2Display.text = "Ya casi termina el registro de tu marca '" + text2 + "'";

        firstCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }
}


