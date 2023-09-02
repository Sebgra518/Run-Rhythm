using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{

    [Header("UI GameObjects")]
    public Text startDisplay;
    public Text titleText;
    public Image cover;

    [Header("Sound")]
    public AudioSource menuFade;
    public AudioSource menuLoop;

    private float a = 0.0f;
    private float a1 = 1.0f;
    private float a2 = 0.0f;

    private bool fadeOut = false;
    private bool disableFadeIn = false;
    private bool disableTitleFadeIn= false;


    private Color txtColor = new Color(255f, 255f, 255f, 0.0f);
    private Color coverColor = new Color(0f, 0f, 0f, 1.0f);
    private Color titleTextColor = new Color(255f, 0f, 0f, 0.0f);

    private bool pageUp = false;

    [Header("Level Selector")]
    public GameObject LevelSelect;
    public GameObject backArrow;
    public GameObject nextArrow;
    private int currentLevelSelect = 0;
    public GameObject[] pages;



    void Start()
    {
        menuFade.Play();
    }


    // Update is called once per frame
    void Update()
    {
        //Fade in and flashing text
        if (!disableFadeIn)
        {
            a1 -= 0.001f;
            coverColor = new Color(0f, 0f, 0f, a1);
            cover.color = coverColor;
            if (a1 <= 0.001f)
            {
                disableFadeIn = true;
                menuLoop.Play();
            }
        } 
        else if (!disableTitleFadeIn)
        {
            a2 += 0.001f;
            titleTextColor = new Color(255f, 0f, 0f, a2);
            titleText.color = titleTextColor;
            if (a2 >= 0.98f)
            {
                disableTitleFadeIn = true;
            }
        }
        else
        {

            //Flashing Start Display
            if (fadeOut)
            {
                a -= 0.001f;
                if (a <= 0.1f)
                {
                    fadeOut = false;
                }
            }
            else
            {
                a += 0.001f;
                if (a >= 0.9f)
                {
                    fadeOut = true;
                }
            }
            txtColor = new Color(255f, 255f, 255f, a);
            startDisplay.color = txtColor;
        }

        if (Input.anyKeyDown && !pageUp)
        {
            pageUp = true;
            pages[0].SetActive(true);
            LevelSelect.SetActive(true);

        }

    }

    public void nextPage()
    {
        backArrow.SetActive(true);
        if (currentLevelSelect + 1 == pages.Length-1)
        {
            nextArrow.SetActive(false);
        }
        pages[currentLevelSelect].SetActive(false);
        currentLevelSelect++;
        pages[currentLevelSelect].SetActive(true);
    }
    public void previousPage()
    {
        nextArrow.SetActive(true);
        if (currentLevelSelect - 1 == 0)
        {
            backArrow.SetActive(false);
        }
        pages[currentLevelSelect].SetActive(false);
        currentLevelSelect--;
        pages[currentLevelSelect].SetActive(true);
    }
    public void loadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevelSelect + 1);
    }
}
