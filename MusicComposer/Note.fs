namespace MusicComposer

type Note(pitch:Pitch, duration: Duration, chord:bool) = 
    member val Pitch = pitch
    member val Duration = duration
    member val Chord = chord
    member this.SetDuration(duration:Duration) = Note(this.Pitch, duration, this.Chord)
    member this.MakeChord() = Note(pitch, duration, true)
    new (pitch:Pitch) = Note(pitch, Duration.Quarter, false)
    new (pitch:Pitch, duration:Duration) = Note(pitch, duration, false)

and Pitch = {
            Name: NoteName
            Alter : NoteAlter
            Octave : Octave
        }  

and NoteName = C = 0 | D = 1 | E = 2 | F = 3| G = 4 | A = 5 | B = 6

and NoteAlter = Natural = 0 | Flat = -1 | Sharp = 1

and Duration =  Whole = 192 | Half = 96 | Quarter  = 48 | Eighth = 24 | ``16th`` = 12 | ``32th`` = 6 | ``64th`` = 3