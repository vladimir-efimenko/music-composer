namespace MusicComposer

type Octave = C0 = 0| C1 = 1 | C2 = 2| C3 =3 | C4 = 4 | C5 = 5 | C6 = 6 | C7 = 7 | C8 = 8 | C9 = 9 
type NoteName = C = 0 | D = 1 | E = 2 | F = 3| G = 4 | A = 5 | B = 6
type NoteAlter = Natural = 0 | Flat = -1 | Sharp = 1

type Note = 
        val Pitch:Pitch
        val Duration : Duration
        val Chord : bool
        new (pitch: Pitch, duration : Duration) = 
            {Pitch = pitch; Duration = duration; Chord = false }
        new (pitch: Pitch, duration : Duration, chord : bool) = 
            {Pitch = pitch; Duration = duration; Chord = chord }
and Pitch = 
        val Name: NoteName
        val Alter : NoteAlter
        val Octave : Octave
        new (name: NoteName, octave: Octave) = 
            { Name = name; Octave = octave; Alter = NoteAlter.Natural }
        new (name: NoteName, alter: NoteAlter, octave: Octave) = 
            { Name = name; Octave = octave; Alter = alter }
and Duration =  Whole = 192 | Half = 96 | Quarter  = 48 | Eighth = 24 | ``16th`` = 12 | ``32th`` = 6 | ``64th`` = 3