using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject instructionCanvas;
    public GameObject firstCanvas;
    public GameObject certificateCanvas;
    public Animator verifyEntry;
    public Animator certificate;

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
        verifyEntry.Play("OutroWindow");
        firstCanvas.SetActive(false);
        StartCoroutine(LoadAfterTimeline1());
    }

    public void playAgain()
    {
        certificate.Play("CertiOutro");
        StartCoroutine(LoadAfterTimeline());
    }

    IEnumerator LoadAfterTimeline()
    {
        yield return new WaitForSeconds(3.0f); 
        Loader.Load(Loader.Scene.MapWorld);
    }

    IEnumerator LoadAfterTimeline1()
    {
        yield return new WaitForSeconds(0.5f); 
        certificateCanvas.SetActive(true);
        certificate.Play("CertiEntry");
        StartCoroutine(LoadAfterTimeline2());
    }

    IEnumerator LoadAfterTimeline2()
    {
        yield return new WaitForSeconds(1.0f); 
        string text1 = inputField1.text;
        string text2 = inputField2.text;
        certificate.Play("CertiLoop");

        text1Display.text = "¡FELICIDADES " + text1 + "!";
        text2Display.text = "TU COLECCIÓN '" + text2 + "' ESTÁ REGISTRADA";
    }
}


