namespace MusicComposer

module Scale = 

    let private diatonicScale key = 
        seq {
            for name, alter in Map.find key Key.keyAlters do 
                yield Note(Pitch(name, alter, Octave.C4), Duration.Quarter)
        } |> Seq.sortBy (fun x -> int (x.Pitch.Name))

    let CMajor =  diatonicScale KeySignature.C
    let CMinor = diatonicScale KeySignature.c

    let CChromatic = 
        [
            NoteFactory.``4th`` NoteName.C Octave.C4
            NoteFactory.``4thSharp`` NoteName.C Octave.C4
            NoteFactory.``4th`` NoteName.D Octave.C4 
            NoteFactory.``4thSharp`` NoteName.D Octave.C4
            NoteFactory.``4th`` NoteName.E Octave.C4
            NoteFactory.``4th`` NoteName.F Octave.C4
            NoteFactory.``4thSharp`` NoteName.F Octave.C4
            NoteFactory.``4th`` NoteName.G Octave.C4
            NoteFactory.``4thSharp`` NoteName.G Octave.C4
            NoteFactory.``4th`` NoteName.A Octave.C4
            NoteFactory.``4thSharp`` NoteName.A Octave.C4
            NoteFactory.``4th`` NoteName.B Octave.C4
            NoteFactory.``4th`` NoteName.C Octave.C5

            NoteFactory.``4th`` NoteName.B Octave.C4
            NoteFactory.``4thFlat`` NoteName.B Octave.C4 
            NoteFactory.``4th`` NoteName.A Octave.C4
            NoteFactory.``4thFlat`` NoteName.A Octave.C4
            NoteFactory.``4th`` NoteName.G Octave.C4
            NoteFactory.``4thFlat`` NoteName.G Octave.C4
            NoteFactory.``4th`` NoteName.F Octave.C4
            NoteFactory.``4th`` NoteName.E Octave.C4
            NoteFactory.``4thFlat`` NoteName.E Octave.C4
            NoteFactory.``4th`` NoteName.D Octave.C4
            NoteFactory.``4thFlat`` NoteName.D Octave.C4
            NoteFactory.``4th`` NoteName.C Octave.C4
        ]