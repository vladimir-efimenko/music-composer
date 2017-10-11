namespace MusicComposer

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
        override this.ToString() = sprintf "%s %s %s" (string this.Name) 
                                                   (match this.Alter with NoteAlter.Sharp -> "#" | NoteAlter.Flat -> "b" | _ -> "")
                                                   (string this.Octave)

and NoteName = C = 0 | D = 1 | E = 2 | F = 3| G = 4 | A = 5 | B = 6

and NoteAlter = Natural = 0 | Flat = -1 | Sharp = 1

and Duration =  Whole = 192 | Half = 96 | Quarter  = 48 | Eighth = 24 | ``16th`` = 12 | ``32th`` = 6 | ``64th`` = 3