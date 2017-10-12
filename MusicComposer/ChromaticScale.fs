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
                

    let prevChromaticPitch pitch = 
        match pitch with 
            | { Name = NoteName.B; Alter = NoteAlter.Natural }
            | { Name = NoteName.A; Alter = NoteAlter.Natural }
            | { Name = NoteName.G; Alter = NoteAlter.Natural }
            | { Name = NoteName.E; Alter = NoteAlter.Natural }
            | { Name = NoteName.D; Alter = NoteAlter.Natural } ->
                Some({ pitch with Alter = NoteAlter.Flat })
            | { Name = NoteName.F; Alter = NoteAlter.Natural } -> 
                Some({ pitch with Name = NoteName.E })
            | { Name = NoteName.B; Alter = NoteAlter.Flat }
            | { Name = NoteName.A; Alter = NoteAlter.Flat }
            | { Name = NoteName.G; Alter = NoteAlter.Flat }
            | { Name = NoteName.E; Alter = NoteAlter.Flat }
            | { Name = NoteName.D; Alter = NoteAlter.Flat } ->
                Some({ pitch with Name = Note.prevNoteName pitch.Name; Alter = NoteAlter.Natural })
            | { Name = NoteName.C; Alter = NoteAlter.Natural; Octave = oct } -> 
                let prevOct = Octave.prev oct 
                match prevOct with
                    None -> None
                    | Some(prev) -> Some({ Name = NoteName.B; Alter = NoteAlter.Natural; Octave = prev })
            | _ -> None

    let CChromaticAscending = 
        seq {
                let mutable first = NoteFactory.c1
                for _ in 1..13 do  
                    yield first 
                    first <- Note((nextChromaticPitch first.Pitch).Value)
            }
    let CChromaticDescending = 
        seq { 
                let mutable first = NoteFactory.c2
                for _ in 1..13 do
                    yield first 
                    first <- Note((prevChromaticPitch first.Pitch).Value)
            }