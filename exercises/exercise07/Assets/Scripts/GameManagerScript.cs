using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject lameCubePrefab;
    public GameObject coolCubePrefab;

    public Image fadePanel;

    bool playCutScene;

    public AudioSource Boop;
    public AudioSource Yawn;
    public AudioSource Guitar;

    GameObject lameCube;
    GameObject coolCube;

    public TMP_Text narrativeText;
    public Image textPanel;

    void Start()
    {
        StartCoroutine(fadeIn());
        fadePanel.gameObject.SetActive(true);
        narrativeText.gameObject.SetActive(false);
        textPanel.gameObject.SetActive(false);
        playCutScene = false;
    }

    void Update()
    {

    }

    IEnumerator fadeIn()
    {
        while (fadePanel.color.a > 0)
        {
            float newAlpha = fadePanel.color.a - 0.5f * Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }

        fadePanel.gameObject.SetActive(false);
        playCutScene = true;
        StartCoroutine(cutScene());
    }

    IEnumerator cutScene()
    {
        while (playCutScene)
        {
            Boop.Play();
            yield return new WaitForSeconds(0.5f);

            lameCube = Instantiate(lameCubePrefab, transform.position, Quaternion.identity);
            lameCube.transform.position = new Vector3(-2.5f, 3.5f, 0);
            yield return new WaitForSeconds(1f);

            narrativeText.gameObject.SetActive(true);
            textPanel.gameObject.SetActive(true);
            narrativeText.text = "This is you.";
            yield return new WaitForSeconds(2f);

            narrativeText.text = "Honestly, you're pretty boring.";
            yield return new WaitForSeconds(2.5f);

            narrativeText.gameObject.SetActive(false);
            textPanel.gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);

            narrativeText.gameObject.SetActive(true);
            textPanel.gameObject.SetActive(true);
            narrativeText.text = "*yawn*";
            Yawn.Play();
            yield return new WaitForSeconds(2f);

            narrativeText.gameObject.SetActive(false);
            textPanel.gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);

            narrativeText.gameObject.SetActive(true);
            textPanel.gameObject.SetActive(true);
            narrativeText.text = "Now let's take a look at me.";
            yield return new WaitForSeconds(2f);

            narrativeText.gameObject.SetActive(false);
            textPanel.gameObject.SetActive(false);
            Guitar.Play();
            Guitar.volume = 1f;
            yield return new WaitForSeconds(2f);

            coolCube = Instantiate(coolCubePrefab, transform.position, Quaternion.identity);
            coolCube.transform.position = new Vector3(2.5f, 3.5f, 0);
            yield return new WaitForSeconds(2f);

            narrativeText.gameObject.SetActive(true);
            textPanel.gameObject.SetActive(true);
            narrativeText.text = "Wow.";
            yield return new WaitForSeconds(2.5f);

            narrativeText.text = "I am so much cooler than you.";
            yield return new WaitForSeconds(2f);

            narrativeText.text = "You should probly just leave.";
            yield return new WaitForSeconds(2.5f);

            narrativeText.gameObject.SetActive(false);
            textPanel.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);

            Boop.Play();
            yield return new WaitForSeconds(0.5f);

            lameCube.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
            yield return new WaitForSeconds(0.5f);

            narrativeText.gameObject.SetActive(true);
            textPanel.gameObject.SetActive(true);
            narrativeText.text = "I hope you learned something today.";
            yield return new WaitForSeconds(3f);

            narrativeText.gameObject.SetActive(false);
            textPanel.gameObject.SetActive(false);
            playCutScene = false;
        }

        fadePanel.gameObject.SetActive(true);
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        while (fadePanel.color.a < 1)
        {
            float newAlpha = fadePanel.color.a + 0.5f * Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, newAlpha);
            Guitar.volume -= 0.5f * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Destroy(lameCube);
        Destroy(coolCube);
        StartCoroutine(fadeIn());
    }
}