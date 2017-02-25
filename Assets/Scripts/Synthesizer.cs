using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CSharpSynth.Effects;
using CSharpSynth.Sequencer;
using CSharpSynth.Synthesis;
using CSharpSynth.Midi;

public class Synthesizer : MonoBehaviour {
    public string midiFilePath = "Midis/Groove.mid";
    public string bankFilePath = "GM Bank/gm";
    
    /*
    public int midiNote = 60;
    public int midiNoteVolume = 100;
    public int midiInstrument = 1;
    */
    private int bufferSize = 1024;
    private float[] sampleBuffer;
    private float gain = 1f;
    private MidiSequencer midiSequencer;
    private StreamSynthesizer midiStreamSynthesizer;

    void Awake()
    {
        midiStreamSynthesizer = new StreamSynthesizer(44100, 2, bufferSize, 40);
        sampleBuffer = new float[midiStreamSynthesizer.BufferSize];

        midiStreamSynthesizer.LoadBank(bankFilePath);

        midiSequencer = new MidiSequencer(midiStreamSynthesizer);
        midiSequencer.LoadMidi(midiFilePath, false);
        //These will be fired by the midiSequencer when a song plays. Check the console for messages
        midiSequencer.NoteOnEvent += new MidiSequencer.NoteOnEventHandler(MidiNoteOnHandler);
        midiSequencer.NoteOffEvent += new MidiSequencer.NoteOffEventHandler(MidiNoteOffHandler);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
            midiStreamSynthesizer.NoteOn(1, midiNote, midiNoteVolume, midiInstrument);
        if (Input.GetKeyUp(KeyCode.A))
            midiStreamSynthesizer.NoteOff(1, midiNote);
        */
    }

    public void StartPlayingKey(int channel, int note, int volume, int instrumentNumber)
    {
        //UnityEditor.EditorUtility.DisplayDialog("A", volume.ToString(), "A");
        midiStreamSynthesizer.NoteOn(channel, note, volume, instrumentNumber);
    }

    public void StopPlayingKey(int channel, int note)
    {
        midiStreamSynthesizer.NoteOff(channel, note);
    }


    private void OnAudioFilterRead(float[] data, int channels)
    {
        //This uses the Unity specific float method we added to get the buffer
        midiStreamSynthesizer.GetNext(sampleBuffer);
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = sampleBuffer[i] * gain;
        }
    }

    public void MidiNoteOnHandler(int channel, int note, int velocity)
    {
        Debug.Log("NoteOn: " + note.ToString() + " Velocity: " + velocity.ToString());
    }

    public void MidiNoteOffHandler(int channel, int note)
    {
        Debug.Log("NoteOff: " + note.ToString());
    }
}
