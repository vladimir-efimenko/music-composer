namespace MusicComposer

module DiatonicScale = 

    let nextDiatonicPitch key pitch = 
        let nextNoteName name = ((int name) + 1) % 7 |> enum

        let nextPitch (pitch:Pitch) = 
            if pitch.Name = NoteName.B then
                match Octave.next pitch.Octave with 
                    Some(nextOct) -> Some(Pitch( (nextNoteName pitch.Name), nextOct))
                    | None -> None 
            else Some(Pitch(nextNoteName pitch.Name, pitch.Octave))
        
        match nextPitch pitch with 
        | Some(p) -> 
            let alter = Map.find key Key.keyAlters |> Seq.find (fun (n, _) -> n = p.Name ) |> snd 
            Some (Pitch (p.Name, alter, p.Octave))
        | None -> None

    let private diatonicScale key firstPitch = 
        let mutable first = firstPitch
        seq {
            for _ in 0..7 do 
                yield Note(first, Duration.Quarter) 
                first <- (nextDiatonicPitch key first).Value
        }

    let CMajor =  diatonicScale KeySignature.C (Pitch(NoteName.C, Octave.C4))
    let CMinor = diatonicScale KeySignature.c (Pitch(NoteName.C, Octave.C4))
    let DMajor = diatonicScale KeySignature.D (Pitch(NoteName.D, Octave.C4))
    let DMinor = diatonicScale KeySignature.d (Pitch(NoteName.D, Octave.C4))
    let EMajor = diatonicScale KeySignature.E (Pitch(NoteName.E, Octave.C4))
    let EMinor = diatonicScale KeySignature.e (Pitch(NoteName.E, Octave.C4))
    let FMajor = diatonicScale KeySignature.F (Pitch(NoteName.F, Octave.C4))
    let FMinor = diatonicScale KeySignature.f (Pitch(NoteName.F, Octave.C4))
    let GMajor = diatonicScale KeySignature.G (Pitch(NoteName.G, Octave.C4))
    let GMinor = diatonicScale KeySignature.g (Pitch(NoteName.G, Octave.C4))
    let AMajor = diatonicScale KeySignature.A (Pitch(NoteName.A, Octave.C4))
    let AMinor = diatonicScale KeySignature.a (Pitch(NoteName.A, Octave.C4))
    let BMajor = diatonicScale KeySignature.B (Pitch(NoteName.B, Octave.C4))
    let BMinor = diatonicScale KeySignature.b (Pitch(NoteName.B, Octave.C4))