namespace MusicComposer

module ChromaticScale = 

    let nextChromaticPitch pitch = 
        match pitch with 
            | { Name = NoteName.C; Alter = NoteAlter.Natural }
            | { Name = NoteName.D; Alter = NoteAlter.Natural }  
            | { Name = NoteName.F; Alter = NoteAlter.Natural }
            | { Name = NoteName.G; Alter = NoteAlter.Natural } 
            | { Name = NoteName.A; Alter = NoteAlter.Natural } ->
                Some({ pitch with Alter = NoteAlter.Sharp })
            | { Name = NoteName.C; Alter = NoteAlter.Sharp }
            | { Name = NoteName.D; Alter = NoteAlter.Sharp }
            | { Name = NoteName.F; Alter = NoteAlter.Sharp } 
            | { Name = NoteName.G; Alter = NoteAlter.Sharp }
            | { Name = NoteName.A; Alter = NoteAlter.Sharp } -> 
              Some({ pitch with Alter = NoteAlter.Natural; Name = Note.nextNoteName pitch.Name })
            | { Name = NoteName.E; Alter = NoteAlter.Natural } -> 
                Some({ pitch with Name = NoteName.F })
            | { Name = NoteName.B; Alter = NoteAlter.Natural; Octave = oct } -> 
                let nextOct = Octave.next oct 
                match nextOct with
                    None -> None
                    | Some(next) -> Some({ Name = NoteName.C; Alter = NoteAlter.Natural; Octave = next })
            | _ -> None
                

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
