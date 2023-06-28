using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour
{

    public GameObject[] scenes;
    public string[] titles = { "INTRODUÇÃO", "LEI ZERO", "PRIMEIRA LEI", "ISOTÉRMICA", "ISOVOLUMÉTRICA", "ISOBARICA", "SEGUNDA  LEI", "FIM" };
    public AudioSource[] sounds;
    public bool audioAwait = true;
    public TextMeshPro title;

    public GameObject[] actionButtons;

    public EventTrigger ev;

    public List<int> hasSeen = new List<int>();
    public int currentScene;
    // Start is called before the first frame update
    void Start()
    {

        title.text = "INICIAR";
        foreach (GameObject bts in actionButtons)
        {
            bts.SetActive(false);
        }
        foreach (GameObject scene in scenes)
        {
            scene.SetActive(false);
        }

        foreach (AudioSource sound in sounds)
        {
            sound.Stop();
        }

        //scenes[0].SetActive(true);
        //sounds[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (scenes[currentScene] == scenes[0])
        {
            actionButtons[1].SetActive(false);
        }
        else if (scenes[currentScene] == scenes[scenes.Length - 1])
        {
            actionButtons[0].SetActive(false);
        }
        else
        {
            actionButtons[0].SetActive(true);
            actionButtons[1].SetActive(true);
        }
    }

    public void nextScene()
    {
        bool playing = false;
        foreach (AudioSource sound in sounds)
        {
            if (audioAwait && sound.isPlaying)
            {
                playing = true;
            }
        }
        if (!playing || hasSeen.Contains(currentScene + 1))
        {
            if (!hasSeen.Contains(currentScene + 1)) hasSeen.Add(currentScene + 1);
            sounds[currentScene].Stop();
            scenes[currentScene].SetActive(false);
            sounds[currentScene + 1].Play();
            scenes[currentScene + 1].SetActive(true);
            title.text = titles[currentScene + 1];
            currentScene++;
        }
    }

    public void previewScene()
    {
        if (!hasSeen.Contains(currentScene + 1)) hasSeen.Add(currentScene + 1);
        sounds[currentScene].Stop();
        scenes[currentScene].SetActive(false);
        sounds[currentScene - 1].Play();
        scenes[currentScene - 1].SetActive(true);
        title.text = titles[currentScene - 1];
        currentScene--;
    }

    public void OpenScene(int index)
    {

        scenes[index].SetActive(true);
        sounds[index].Play();
        actionButtons[0].SetActive(true);
        title.text = titles[index];
        ev.enabled = false;
        currentScene = index;


    }

}