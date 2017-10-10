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