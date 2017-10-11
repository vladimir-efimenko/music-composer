namespace MusicComposer

type Key = 
    struct
        val Signature : KeySignature
        val KeyType: KeyType 
        new (signature:KeySignature, keyType:KeyType) = 
            { Signature = signature; KeyType = keyType }
    end

and KeyType = Major | Minor

and KeySignature = C = 0 | a = 0 | G = 1 | e = 1| D = 2 | b = 2 | A = 3 | fsharp = 3 | E = 4 | csharp = 4 | B = 5 | gsharp = 5 
                    | F = -1 | d= -1 | Bflat = -2 | g = -2 | Eflat = -3 | c = -3 | Aflat = -4 | f = -4 | Dflat = -5 | bflat = -5 | Gflat = -6 | eflat = -6  

module Key = 

    open System

    let CMajor = Key(KeySignature.C, KeyType.Major)
    let CMinor = Key(KeySignature.c, KeyType.Minor)
    let DMajor = Key(KeySignature.D, KeyType.Major)
    let DMinor = Key(KeySignature.d, KeyType.Minor)
    let EMajor = Key(KeySignature.E, KeyType.Major)
    let EMinor = Key(KeySignature.e, KeyType.Minor)
    let FMajor = Key(KeySignature.F, KeyType.Major)
    let FMinor = Key(KeySignature.f, KeyType.Minor)
    let GMajor = Key(KeySignature.G, KeyType.Major)
    let GMinor = Key(KeySignature.g, KeyType.Minor)
    let AMajor = Key(KeySignature.A, KeyType.Major)
    let AMinor = Key(KeySignature.a, KeyType.Minor)
    let BMajor = Key(KeySignature.B, KeyType.Major)
    let BMinor = Key(KeySignature.b, KeyType.Minor)

    let private sharpKeyAlters = [(NoteName.F, NoteAlter.Sharp); (NoteName.C, NoteAlter.Sharp); (NoteName.G, NoteAlter.Sharp); (NoteName.D, NoteAlter.Sharp);(NoteName.A, NoteAlter.Sharp); (NoteName.E, NoteAlter.Sharp); (NoteName.B, NoteAlter.Sharp)]
    let private flatKeyAlters = [(NoteName.B, NoteAlter.Flat); (NoteName.E, NoteAlter.Flat); (NoteName.A, NoteAlter.Flat); (NoteName.D, NoteAlter.Flat);(NoteName.G, NoteAlter.Flat); (NoteName.C, NoteAlter.Flat); (NoteName.F, NoteAlter.Flat)]

    // Map of all possible alters for the specified key signature
    let keyAlters = Map([ for k in Enum.GetValues(typeof<KeySignature>) do 
                            let key = k :?> KeySignature
                            let num = int key
                            let alters = if num >= 0 then Seq.take num sharpKeyAlters else Seq.take -num flatKeyAlters
                            let rest = seq { for n in Enum.GetValues(typeof<NoteName>) do 
                                                let note = n:?> NoteName
                                                if not (alters |> Seq.map fst |> Seq.contains note ) then 
                                                    yield note, NoteAlter.Natural
                                            }
                            yield (key, Seq.append alters rest)
                        ])