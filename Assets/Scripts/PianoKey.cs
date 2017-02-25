using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PianoKey : MonoBehaviour {
    public GameObject synthesizer;
    public Material whiteMaterial;
    public string keyName;
    public int note;
    
    private Material defaultMaterial;
    private Synthesizer synthesizerScript;
    
    //currentVolume, currentInstrument, currentChannel, currentColor introduced to accomodate on click of mouse key
    private int currentVolume;
    private int currentInstrument;
    private int currentChannel;
    private Color currentColor;

    private bool isKeyPressed;
    private bool isMousePressed;

    void Awake()
    {
        synthesizerScript = (Synthesizer)synthesizer.GetComponent(typeof(Synthesizer));
        defaultMaterial = gameObject.GetComponent<Renderer>().material;
        currentColor = Color.cyan;
        currentChannel = 1;
        currentVolume = 100;
        currentInstrument = 1;
        EndKeyGlow();
        isKeyPressed = false;
        isMousePressed = false;
    }

    void OnMouseDown()
    {
        HandleKeyPress(currentChannel, currentVolume, currentInstrument, currentColor);
    }

    void OnMouseUp()
    {
        HandleKeyRelease(currentChannel);
    }

    void OnMouseExit()
    {
        HandleKeyRelease(currentChannel);
    }

    void OnMouseEnter()
    {
        if (isMousePressed)
        {
            HandleKeyPress(currentChannel, currentVolume, currentInstrument, currentColor);
        }
        else
        {
            StartKeyGlow(Color.grey);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        HandleKeyPress(currentChannel, currentVolume, currentInstrument, currentColor);
    }

    void OnTriggerExit(Collider c)
    {
        HandleKeyRelease(currentChannel);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isKeyPressed)
        {
            //indicate mouse is held for pressing key on entry
            isMousePressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Stop holding key, if mouse is released when inside key
            isMousePressed = false;
            HandleKeyRelease(currentChannel);
        }
    }

    public void HandleKeyPress(int channel, int volume, int instrumentNumber, Color colorOnPress)
    {
        if (!isKeyPressed)
        {
            isKeyPressed = true;
            PlaySound(channel, volume, instrumentNumber);
            StartKeyGlow(colorOnPress);
        }
    }

    public void HandleKeyRelease(int channel)
    {
        if (isKeyPressed)
        {
            isKeyPressed = false;
            StopSound(channel);
        }
        EndKeyGlow();
    }

    public string GetPianoKeyName()
    {
        return keyName;
    }

    public void SetVolume(int newVolume)
    {
        currentVolume = newVolume;
    }

    public void SetInstrument(int newInstrument)
    {
        currentInstrument = newInstrument;
    }

    public void SetCurrentColor(Color newColor)
    {
        currentColor = newColor;
    }

    public void SetChannel(int newChannel)
    {
        currentChannel = newChannel;
    }

    private void PlaySound(int channel, int volume, int instrumentNumber)
    {
        synthesizerScript.StartPlayingKey(channel, note, volume, instrumentNumber);
    }

    private void StopSound(int channel)
    {
        synthesizerScript.StopPlayingKey(channel, note);
    }

    private void StartKeyGlow(Color keyColor)
    {
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
        gameObject.GetComponent<Renderer>().material.color = keyColor;
    }

    private void EndKeyGlow()
    {
        gameObject.GetComponent<Renderer>().material = whiteMaterial;
    }
}
