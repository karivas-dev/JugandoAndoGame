using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject instructionCanvas;
    public GameObject firstCanvas;
    public GameObject secondCanvas;
    public Animator verifyEntry;

    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TextMeshProUGUI text1Display;
    public TextMeshProUGUI text2Display;

    private void Awake()
    {
        verifyEntry = firstCanvas.GetComponent<Animator>();
    }

    public void vamosButton()
    {
        instructionCanvas.SetActive(false);
        firstCanvas.SetActive(true);
        verifyEntry.Play("IntroForm");
    }

    public void enviarButton()
    {
        verifyEntry.Play("OutroForm");
    }

    public void siguienteButton()
    {
        verifyEntry.Play("PaymentStage");
    }

    public void pagarButton()
    {
        
    }

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


