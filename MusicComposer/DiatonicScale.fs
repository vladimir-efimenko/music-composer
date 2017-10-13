namespace MusicComposer

module DiatonicScale = 

    let nextNaturalPitch key pitch = 
        let nextPitch (pitch:Pitch) = 
            if pitch.Name = NoteName.B then
                match Octave.next pitch.Octave with 
                    Some(nextOct) -> Some( { Name= NoteName.C; Alter = NoteAlter.Natural; Octave =  nextOct } )
                    | None -> None 
            else 
                Some({ pitch with Name = Note.nextNoteName pitch.Name })
        
        match nextPitch pitch with 
        | Some(p) -> 
            let alter = Map.find key Key.keyAlters |> Seq.find (fun (n, _) -> n = p.Name ) |> snd 
            Some ( { Name = p.Name; Alter = alter; Octave = p.Octave } )
        | None -> None

    let private naturalScale key firstPitch = 
        let mutable first = firstPitch
        seq {
            for _ in 0..7 do 
                yield Note(pitch = first, duration = Duration.Quarter, chord = false) 
                first <- (nextNaturalPitch key first).Value
        }

    // Ionian (Major scale)
    let CMajor = naturalScale KeySignature.C NoteFactory.C4.Pitch |> Seq.toArray
    let DMajor = naturalScale KeySignature.D NoteFactory.D4.Pitch |> Seq.toArray
    let EMajor = naturalScale KeySignature.E NoteFactory.E4.Pitch |> Seq.toArray
    let FMajor = naturalScale KeySignature.F NoteFactory.F4.Pitch |> Seq.toArray
    let GMajor = naturalScale KeySignature.G NoteFactory.G4.Pitch |> Seq.toArray
    let AMajor = naturalScale KeySignature.A NoteFactory.A4.Pitch |> Seq.toArray
    let BMajor = naturalScale KeySignature.B NoteFactory.B4.Pitch |> Seq.toArray

    // Aeolian (Natural minor scale)
    let CMinor = naturalScale KeySignature.c NoteFactory.C4.Pitch |> Seq.toArray
    let DMinor = naturalScale KeySignature.d NoteFactory.D4.Pitch |> Seq.toArray
    let EMinor = naturalScale KeySignature.e NoteFactory.E4.Pitch |> Seq.toArray
    let FMinor = naturalScale KeySignature.f NoteFactory.F4.Pitch |> Seq.toArray
    let GMinor = naturalScale KeySignature.g NoteFactory.G4.Pitch |> Seq.toArray
    let AMinor = naturalScale KeySignature.a NoteFactory.A4.Pitch |> Seq.toArray
    let BMinor = naturalScale KeySignature.b NoteFactory.B4.Pitch |> Seq.toArray

    let tonic scale = Seq.head scale 
    let supertonic scale = scale |> Seq.skip 1 |> Seq.head
    let mediant scale = scale |> Seq.skip 2 |> Seq.head
    let subdominant scale = scale |> Seq.skip 3 |> Seq.head
    let dominant scale = scale |> Seq.skip 4 |> Seq.head
    let submediant scale = scale |> Seq.skip 5 |> Seq.head
    let leadingTone scale = scale |> Seq.last