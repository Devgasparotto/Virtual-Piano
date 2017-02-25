Application Description

This desktop application simulates a Keyboard Piano, more specifically octaves C4-B5 of a piano.
Several methods of playing the piano, including the use of a computer keyboard, clicking or using the Leap Motion Controller.
There are also several options for instruments, which will change the sound of each of the piano keys.
A single song is also playable from within the application, which will play pre-recorded notes on the piano.
Users may adjust the volume and instrument, and play the song using the GUI controls in the upper left portion of the screen.

The project can be run from Piano/Piano.exe in the zipped project folder included.

A video demo can be found at: https://www.youtube.com/watch?v=IxhOiAWBMMs

========================

Design Decisions

When creating this application I was not certain what technology I was going to use to implement it. I was interested in using
MIDI because it was a standard and thought this would be good opportunity to learn it. From here I researched ways in which to
use MIDI. I found a good library for the Unity Game Engine that utilized MIDI to produce sound - http://csharpsynthproject.codeplex.com/.
This encouraged me to use the Unity Game Engine to create the application. Along with this I knew I may be able to create an
android version if time permitted, and potentially use the Leap Motion Controller.

To give a high level breakdown of why my code is structured the way it is, I wanted to seperate management of the GUI, management 
of sound and the individual piano keys. This worked well in when using a computer keyboard to play sounds; however with the 
addition of mouse clicking and the Leap Motion controller, some of the modularity suffered in my design to accomodate potential
changes in volume and instruments.

After it was decided that the Leap Motion Controller was to be used in the project, I needed to adjust the camera angles and 
spacing between keys to accomodate the use of the controller. In referencing previous Leap Motion piano projects on the internet,
it seemed that the best projects used a slightly above horizontal angle, with only the finger tips of the hand visible on the
screen. I tried to emulate this as closely as possible by adjusting the positioning of the hands in the game, and implementing
the limitation of only allowing the hands' fingertips to press keys. This ultimately helped with more accurately playing the
piano.

It is also because of using the Leap Motion controller that I decided to include only two octaves in the final application, so
that users could reach all the piano keys without losing hand detection.

========================

Areas of Improvement

I found that using the Leap Motion controller is not as seemless as I would like. For future iterations I would spend more time
polishing the use of this controller so that it is more fluid.

The background I used isn't very pleasant, I think a real piano model and maybe a living room scene would be more suiting for
the app.

_____________________________________________________________________________________________________________________________________________