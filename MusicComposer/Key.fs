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
