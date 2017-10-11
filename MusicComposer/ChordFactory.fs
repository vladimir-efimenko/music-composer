namespace MusicComposer

module ChordFactory =

    let CMajor = 
        [
            Note(Pitch(name = NoteName.C, octave =  Octave.C4), Duration.Quarter) 
            Note(Pitch(name = NoteName.E, octave =  Octave.C4), Duration.Quarter, chord = true) 
            Note(Pitch(name = NoteName.G, octave =  Octave.C4), Duration.Quarter, chord = true)
        ]
    
    let CMinor = 
        [
            Note(Pitch(name = NoteName.C, octave =  Octave.C4), Duration.Quarter) 
            Note(Pitch(name = NoteName.E, alter = NoteAlter.Flat, octave =  Octave.C4), Duration.Quarter, chord = true) 
            Note(Pitch(name = NoteName.G, octave =  Octave.C4), Duration.Quarter, chord = true) 
        ]

    let DMajor = 
        [
            Note(Pitch(name = NoteName.D, octave =  Octave.C4), Duration.Quarter) 
            Note(Pitch(name = NoteName.F, alter = NoteAlter.Sharp, octave =  Octave.C4), Duration.Quarter, chord = true) 
            Note(Pitch(name = NoteName.A, octave =  Octave.C4), Duration.Quarter, chord = true)
        ]
    
    let DMinor = 
        [
            Note(Pitch(name = NoteName.D, octave =  Octave.C4), Duration.Quarter) 
            Note(Pitch(name = NoteName.F, octave =  Octave.C4), Duration.Quarter, chord = true) 
            Note(Pitch(name = NoteName.A, octave =  Octave.C4), Duration.Quarter, chord = true) 
        ]

    let EMajor = 
        [
            Note(Pitch(name = NoteName.E, octave =  Octave.C4), Duration.Quarter) 
            Note(Pitch(name = NoteName.G, alter = NoteAlter.Sharp, octave =  Octave.C4), Duration.Quarter, chord = true) 
            Note(Pitch(name = NoteName.B, octave =  Octave.C4), Duration.Quarter, chord = true)
        ]
    
    let EMinor = 
        [
            Note(Pitch(name = NoteName.E, octave =  Octave.C4), Duration.Quarter) 
            Note(Pitch(name = NoteName.G, octave =  Octave.C4), Duration.Quarter, chord = true) 
            Note(Pitch(name = NoteName.B, octave =  Octave.C4), Duration.Quarter, chord = true) 
        ]