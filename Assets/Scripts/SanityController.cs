using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    public Slider m_Slider;

    [Header("Sanity")]
    public float maxSanityPoints = 40f;
    public float pointReduceEachSecond = 1;
    [Range(0f, 1f)]
    public float PercentageToEnterAlertMode = 0.70f;

    [Header("Anxiety")]
    public float maxSecondsInAnxiety = 20f;

    [Header("Fear")]
    private float secondsInFear = 0f;

    private float currentTime = 0f;
    private float currentTimeInsanity = 0;

    private bool showWarning = true;

    public static SanityController Instance;

    private PlayerMovement m_PlayerMovement;

    private void Awake()
    {
        Instance = this;
    }

    public float GetSecondsInFear()
    {
        return secondsInFear;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();

        m_Slider.minValue = maxSanityPoints * -1;
        m_Slider.maxValue = maxSanityPoints;
    }

    void UpdateCurrentFadigue(float value)
    {
        if (currentTime <= maxSanityPoints * -1 && value < 0)
        {
            value = 0;
        }

        if (currentTime >= maxSanityPoints && value > 0)
        {
            value = 0;
        }

        currentTime += value * Time.deltaTime;
    }

    void UpdateSlider()
    {
        m_Slider.value = currentTime;
    }


    public void Reset()
    {
        showWarning = true;
        secondsInFear = 0f;
        currentTime = 0f;
        currentTimeInsanity = 0;

        UpdateSlider();
    }

    void Update()
    {

        if (!m_PlayerMovement.playerStartGame)
        {
            return;
        }

        if (EyesManager.Instance.LeftAndRightEyesIsOpen())
        {
            UpdateCurrentFadigue(pointReduceEachSecond);
        }
        else
        {
            UpdateCurrentFadigue(pointReduceEachSecond * -1);
        }


        if (currentTime < 0 && currentTime <= (maxSanityPoints * PercentageToEnterAlertMode * -1))
        {
            currentTimeInsanity += Time.deltaTime;

            if (showWarning)
            {
                Popup.Instance.ShowPopup("You have entered the anxiety state. Will die in " + maxSecondsInAnxiety + " seconds!");
                showWarning = false;
            }

            if (currentTimeInsanity > maxSecondsInAnxiety)
            {
                PlayerController.Instance.Death();
            }
        }
        else
        if (currentTime > 0 && currentTime >= (maxSanityPoints * PercentageToEnterAlertMode))
        {
            if (showWarning)
            {
                Popup.Instance.ShowPopup("You have entered the state of fear. The demons are faster!");
                showWarning = false;
            }


            secondsInFear += Time.deltaTime;
        }
        else
        {
            Debug.Log("neutro");
            showWarning = true;
            secondsInFear = 0f;
            currentTimeInsanity = 0;
        }


        UpdateSlider();
    }
}
