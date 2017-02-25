using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PianoManager : MonoBehaviour {
    public int midiNote = 60;
    public int midiNoteVolume = 100;
    public int midiInstrument = 1;
    public GameObject keyboardImage;
    
    private int channel = 1;
    private int maxNumberKeyPresses = 5;
    private Color[] keyPressColors = new Color[5];
    private List<PianoKey> pianoKeys = new List<PianoKey>(); //sets size after knowing how many keys there are
    private List<string> pianoKeyNotes = new List<string>(); //keeps track of the note on each key
    
    private List<string> songNotes = new List<string>();
    private List<int> songNotesIndex = new List<int>();
    private int currentSongIndex;
    private bool isPlayingSong;
    private bool isKeyboardImageVisible;

    void Awake()
    {
        InitializeKeyPressColorArray();
        InitializePianoKeyData();
        InitializeGUIControls();
        InitializeSong();
    }

    void Update()
    {
        //White Piano Keys
        if (Input.GetKeyDown(KeyCode.A))
            pianoKeys[0].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.A))
            pianoKeys[0].HandleKeyRelease(channel);
        
        if (Input.GetKeyDown(KeyCode.S))
            pianoKeys[1].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.S))
            pianoKeys[1].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.D))
            pianoKeys[2].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.D))
            pianoKeys[2].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.F))
            pianoKeys[3].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.F))
            pianoKeys[3].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.G))
            pianoKeys[4].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.G))
            pianoKeys[4].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.H))
            pianoKeys[5].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.H))
            pianoKeys[5].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.J))
            pianoKeys[6].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.J))
            pianoKeys[6].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.K))
            pianoKeys[7].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.K))
            pianoKeys[7].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.L))
            pianoKeys[8].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.L))
            pianoKeys[8].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Semicolon))
            pianoKeys[9].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Semicolon))
            pianoKeys[9].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Quote))
            pianoKeys[10].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Quote))
            pianoKeys[10].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Return))
            pianoKeys[11].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Return))
            pianoKeys[11].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Keypad4))
            pianoKeys[12].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Keypad4))
            pianoKeys[12].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Keypad5))
            pianoKeys[13].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Keypad5))
            pianoKeys[13].HandleKeyRelease(channel);
        

        //Black Piano Keys
        if (Input.GetKeyDown(KeyCode.W))
            pianoKeys[14].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.W))
            pianoKeys[14].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.E))
            pianoKeys[15].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.E))
            pianoKeys[15].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.T))
            pianoKeys[16].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.T))
            pianoKeys[16].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Y))
            pianoKeys[17].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Y))
            pianoKeys[17].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.U))
            pianoKeys[18].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.U))
            pianoKeys[18].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.O))
            pianoKeys[19].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.O))
            pianoKeys[19].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.P))
            pianoKeys[20].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.P))
            pianoKeys[20].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.RightBracket))
            pianoKeys[21].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.RightBracket))
            pianoKeys[21].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Backslash))
            pianoKeys[22].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Backslash))
            pianoKeys[22].HandleKeyRelease(channel);

        if (Input.GetKeyDown(KeyCode.Keypad7))
            pianoKeys[23].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
        if (Input.GetKeyUp(KeyCode.Keypad7))
            pianoKeys[23].HandleKeyRelease(channel);
    }

    private void InitializeKeyPressColorArray()
    {
        keyPressColors[0] = Color.cyan;
        keyPressColors[1] = Color.yellow;
        keyPressColors[2] = Color.red;
        keyPressColors[3] = Color.green;
        keyPressColors[4] = Color.magenta;
    }

    private void InitializeGUIControls()
    {
        isKeyboardImageVisible = false;
        keyboardImage.SetActive(isKeyboardImageVisible);
    }

    private void InitializePianoKeyData()
    {
        //Assumes all white piano keys have the same gameObject name and all black piano keys have the same gameObject name (with (1), (2), etc.)
        InitializePianoKeyDataByKeyType("WhitePianoKey");
        InitializePianoKeyDataByKeyType("BlackPianoKey");
    }


    private void InitializePianoKeyDataByKeyType(string keyType)
    {
        int index = 0;
        while (index > -1)
        {
            //For each white piano key
            GameObject pianoKey;
            if (index == 0)
            {
                pianoKey = GameObject.Find(keyType);
            }
            else
            {
                pianoKey = GameObject.Find(keyType + " (" + index + ")");
            }

            if (pianoKey != null)
            {
                PianoKey pkScript = (PianoKey)pianoKey.GetComponent(typeof(PianoKey));
                if (pkScript != null)
                {
                    GetPianoKeyScript(pkScript);
                    GetPianoKeyNote(pkScript);
                }
            }
            else
            {
                break;
            }
            index++;
        }
    }

    private void GetPianoKeyScript(PianoKey pianoKeyScript)
    {
        pianoKeys.Add(pianoKeyScript);
    }

    private void GetPianoKeyNote(PianoKey pianoKeyScript)
    {
        string pianoKeyName = pianoKeyScript.GetPianoKeyName();
        pianoKeyNotes.Add(pianoKeyName);
    }

    private void InitializeSong()
    {
        //Legend of Zelda Theme        
        songNotes.Add("A5#");
        songNotes.Add("F5");
        songNotes.Add("A5#");
        songNotes.Add("A5#");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("D5#");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5#");

        songNotes.Add("G5#");
        songNotes.Add("A5#");
        songNotes.Add("A5#");
        songNotes.Add("A5#");
        songNotes.Add("G5#");
        songNotes.Add("F5#");
        songNotes.Add("G5#");
        songNotes.Add("F5#");
        songNotes.Add("F5");
        songNotes.Add("F5");
        
        songNotes.Add("D5#");
        songNotes.Add("D5#");
        songNotes.Add("F5");
        songNotes.Add("F5#");
        songNotes.Add("F5");
        songNotes.Add("D5#");
        songNotes.Add("C5#");
        songNotes.Add("C5#");
        songNotes.Add("D5#");
        songNotes.Add("F5");

        songNotes.Add("D5#");
        songNotes.Add("C5#");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("E5");
        songNotes.Add("G5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        

        //Super Mario Theme
        songNotes.Add("E5");
        songNotes.Add("E5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("E5");
        songNotes.Add("G5");
        songNotes.Add("G4");
        songNotes.Add("C5");
        songNotes.Add("G4");
        songNotes.Add("E4");
        songNotes.Add("A4");
        songNotes.Add("B4");
        songNotes.Add("A4");
        songNotes.Add("A4");
        songNotes.Add("G4");
        songNotes.Add("E5");
        songNotes.Add("G5");
        songNotes.Add("A5");
        songNotes.Add("F5");
        songNotes.Add("G5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("B4");

        songNotes.Add("C5");
        songNotes.Add("G4");
        songNotes.Add("E4");
        songNotes.Add("A4");
        songNotes.Add("B4");
        songNotes.Add("A4");
        songNotes.Add("A4");
        songNotes.Add("G4");
        songNotes.Add("E5");
        songNotes.Add("G5");
        songNotes.Add("A5");
        songNotes.Add("F5");
        songNotes.Add("G5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("B4");
        songNotes.Add("G5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("D5");
        songNotes.Add("E5");
        songNotes.Add("G4");
        songNotes.Add("A4");
        songNotes.Add("C5");
        songNotes.Add("A4");
        songNotes.Add("C5");
        songNotes.Add("D5");

        /*
        //Rest of Super Mario Theme song removed for now
        songNotes.Add("G5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("D5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("G5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("E5");
        songNotes.Add("G4");
        songNotes.Add("A4");
        songNotes.Add("C5");
        songNotes.Add("A4");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("D5");
        songNotes.Add("D5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");

        
        songNotes.Add("D5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("A4");
        songNotes.Add("G4");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("D5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("A4");
        songNotes.Add("G4");
        songNotes.Add("E5");
        songNotes.Add("E5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("E5");
        songNotes.Add("G5");
        songNotes.Add("G4");


        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("G4");
        songNotes.Add("G4#");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("A4");
        songNotes.Add("B4");
        songNotes.Add("A5");
        songNotes.Add("A5");
        songNotes.Add("A5");
        songNotes.Add("F5");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("A4");
        songNotes.Add("G4");
        songNotes.Add("E5");
        songNotes.Add("C5");
        songNotes.Add("G4");
        songNotes.Add("G4#");
        songNotes.Add("A4");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("A4");
        songNotes.Add("B4");


        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("F5");
        songNotes.Add("E5");
        songNotes.Add("D5");
        songNotes.Add("C5");
        songNotes.Add("C5");
        songNotes.Add("G4");
        songNotes.Add("E4");
        songNotes.Add("A4");
        songNotes.Add("B4");
        songNotes.Add("A4");
        songNotes.Add("G4#");
        songNotes.Add("A5#");
        songNotes.Add("G4#");
        songNotes.Add("E4");
        songNotes.Add("D4");
        songNotes.Add("E4");
        */
        
        foreach (string note in songNotes)
        {
            int index = pianoKeyNotes.IndexOf(note);
            songNotesIndex.Add(index);
        }

        currentSongIndex = 0;
        isPlayingSong = false;
    }

    public void MidiNoteOnHandler(int channel, int note, int velocity)
    {
        Debug.Log("NoteOn: " + note.ToString() + " Velocity: " + velocity.ToString());
    }

    public void MidiNoteOffHandler(int channel, int note)
    {
        Debug.Log("NoteOff: " + note.ToString());
    }

    public void PlaySong()
    {
        currentSongIndex = 0;
        if (!isPlayingSong)
        {
            isPlayingSong = true;
            InvokeRepeating("PlayNextNote", 1.0f, 0.35f);
        }
        else
        {
            isPlayingSong = false;
            CancelInvoke();
        }
    }

    private void PlayNextNote()
    {
        if (isPlayingSong)
        {
            if (currentSongIndex <= songNotesIndex.Count)
            {
                if (currentSongIndex > 0)
                {
                    pianoKeys[songNotesIndex[currentSongIndex - 1]].HandleKeyRelease(channel);
                }
                if (currentSongIndex < songNotesIndex.Count)
                {
                    pianoKeys[songNotesIndex[currentSongIndex]].HandleKeyPress(channel, midiNoteVolume, midiInstrument, keyPressColors[0]);
                    currentSongIndex++;
                }
            }
            else
            {
                currentSongIndex = 0;
                isPlayingSong = false;
                CancelInvoke();
            }
        }
    }

    public void SetVolume(float newVolume)
    {
        midiNoteVolume = (int) newVolume;
        SetVolumeForAllPianoKeys();
    }

    public void SetVolumeForAllPianoKeys()
    {
        foreach(PianoKey pK in pianoKeys){
            pK.SetVolume(midiNoteVolume);
        }
    }

    public void SetInstrument(int instrumentNumber)
    {
        midiInstrument = instrumentNumber + 1;
        SetInstrumentForAllPianoKeys();
    }

    public void SetInstrumentForAllPianoKeys()
    {
        foreach (PianoKey pK in pianoKeys)
        {
            pK.SetInstrument(midiInstrument);
        }
    }

    public void DisplayKeyboardControls()
    {
        isKeyboardImageVisible = !isKeyboardImageVisible;
        keyboardImage.SetActive(isKeyboardImageVisible);
    }

}
