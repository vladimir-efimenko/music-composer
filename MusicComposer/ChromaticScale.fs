namespace MusicComposer

module ChromaticScale = 

    let nextChromaticPitch pitch = 
        match pitch with 
            | { Name = NoteName.C; Alter = NoteAlter.Natural }
            | { Name = NoteName.D; Alter = NoteAlter.Natural }  
            | { Name = NoteName.F; Alter = NoteAlter.Natural }
            | { Name = NoteName.G; Alter = NoteAlter.Natural } 
            | { Name = NoteName.A; Alter = NoteAlter.Natural } ->
                { pitch with Alter = NoteAlter.Sharp }
            | { Name = NoteName.C; Alter = NoteAlter.Sharp } -> 
                { pitch with Name = NoteName.D; Alter = NoteAlter.Natural }
            | { Name = NoteName.D; Alter = NoteAlter.Sharp } -> 
                {  pitch with Name = NoteName.E; Alter = NoteAlter.Natural }
            | { Name = NoteName.E; Alter = NoteAlter.Natural } -> 
                { pitch with Name = NoteName.F }
            | { Name = NoteName.F; Alter = NoteAlter.Sharp } -> 
                { pitch with Name = NoteName.G; Alter = NoteAlter.Natural }
            | { Name = NoteName.G; Alter = NoteAlter.Sharp } -> 
                { pitch with Name = NoteName.A; Alter = NoteAlter.Natural }
            | { Name = NoteName.A; Alter = NoteAlter.Sharp } -> 
                { pitch with Name = NoteName.B; Alter = NoteAlter.Natural }
            | { Name = NoteName.B; Alter = NoteAlter.Natural; Octave = oct } -> 
                let nextOct = Octave.next oct 
                match nextOct with
                    None -> failwith "Cannot get the next octave"
                    | Some(next) -> { Name = NoteName.C; Alter = NoteAlter.Natural; Octave = next }
            | _ -> failwith "Not supported"
                

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
