namespace MusicComposer

type Note = { 
            Pitch:Pitch
            Duration : Duration
            Chord : bool
        }

and Pitch = {
            Name: NoteName
            Alter : NoteAlter
            Octave : Octave
        }  
        //with 
        //override this.ToString() = sprintf "%s %s %s" (string this.Name) 
        //                                           (match this.Alter with NoteAlter.Sharp -> "#" | NoteAlter.Flat -> "b" | _ -> "")
        //                                           (string this.Octave)

and NoteName = C = 0 | D = 1 | E = 2 | F = 3| G = 4 | A = 5 | B = 6

and NoteAlter = Natural = 0 | Flat = -1 | Sharp = 1

and Duration =  Whole = 192 | Half = 96 | Quarter  = 48 | Eighth = 24 | ``16th`` = 12 | ``32th`` = 6 | ``64th`` = 3