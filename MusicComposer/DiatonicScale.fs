namespace MusicComposer

module DiatonicScale = 

    let nextNaturalPitch key pitch = 
        let nextNoteName name = ((int name) + 1) % 7 |> enum

        let nextPitch (pitch:Pitch) = 
            if pitch.Name = NoteName.B then
                match Octave.next pitch.Octave with 
                    Some(nextOct) -> Some( { Name= nextNoteName pitch.Name; Alter = NoteAlter.Natural; Octave =  nextOct } )
                    | None -> None 
            else 
                Some({ pitch with Name = nextNoteName pitch.Name })
        
        match nextPitch pitch with 
        | Some(p) -> 
            let alter = Map.find key Key.keyAlters |> Seq.find (fun (n, _) -> n = p.Name ) |> snd 
            Some ( { Name = p.Name; Alter = alter; Octave = p.Octave } )
        | None -> None

    let private naturalScale key firstPitch = 
        let mutable first = firstPitch
        seq {
            for _ in 0..7 do 
                yield { Pitch = first; Duration = Duration.Quarter ; Chord = false } 
                if firstPitch.Name = NoteName.C then printfn "%A" first
                first <- (nextNaturalPitch key first).Value
        }

    // Ionian (Major scale)
    let CMajor =  naturalScale KeySignature.C { Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let DMajor = naturalScale KeySignature.D  { Name = NoteName.D; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let EMajor = naturalScale KeySignature.E  { Name = NoteName.E; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let FMajor = naturalScale KeySignature.F  { Name = NoteName.F; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let GMajor = naturalScale KeySignature.G  { Name = NoteName.G; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let AMajor = naturalScale KeySignature.A  { Name = NoteName.A; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let BMajor = naturalScale KeySignature.B  { Name = NoteName.B; Alter = NoteAlter.Natural; Octave = Octave.C4 }

    // Aeolian (Natural minor scale)
    let CMinor = naturalScale KeySignature.c { Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let DMinor = naturalScale KeySignature.d { Name = NoteName.D; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let EMinor = naturalScale KeySignature.e { Name = NoteName.E; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let FMinor = naturalScale KeySignature.f { Name = NoteName.F; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let GMinor = naturalScale KeySignature.g { Name = NoteName.G; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let AMinor = naturalScale KeySignature.a { Name = NoteName.A; Alter = NoteAlter.Natural; Octave = Octave.C4 }
    let BMinor = naturalScale KeySignature.b { Name = NoteName.B; Alter = NoteAlter.Natural; Octave = Octave.C4 }

    let tonic scale = Seq.head scale 
    let supertonic scale = scale |> Seq.skip 1 |> Seq.take 1
    let mediant scale = scale |> Seq.skip 2 |> Seq.take 1
    let subdominant scale = scale |> Seq.skip 3 |> Seq.take 1
    let dominant scale = scale |> Seq.skip 4 |> Seq.take 1
    let submediant scale = scale |> Seq.skip 5 |> Seq.take 1
    let leadingTone scale = scale |> Seq.last