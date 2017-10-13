namespace MusicComposer

module ChordFactory =

    let tonic (scale: Note array) = 
        [
            Array.get scale 0
            Array.get scale 2 
            Array.get scale 4
        ]
        
    let subdominant (scale: Note array) = 
        [
            Array.get scale 3
            Array.get scale 5
            Array.get scale 7
        ]

    let dominant (scale: Note array) = 
        [
            Array.get scale 4
            Array.get scale 6 
            (Array.get scale 1).AddOctave()
        ]
    
    let makeChord (notes: Note seq) = 
        notes |> Seq.mapi (fun i note -> if i = 0 then note else note.MakeChord())

    let CMajor = tonic DiatonicScale.CMajor
    let CMinor = tonic DiatonicScale.CMinor
    let DMajor = tonic DiatonicScale.DMajor
    let DMinor = tonic DiatonicScale.DMinor
    let EMajor = tonic DiatonicScale.EMajor
    let EMinor = tonic DiatonicScale.EMinor
    let FMajor = tonic DiatonicScale.FMajor
    let FMinor = tonic DiatonicScale.FMinor
    let GMajor = tonic DiatonicScale.GMajor
    let GMinor = tonic DiatonicScale.GMinor
    let AMajor = tonic DiatonicScale.AMajor
    let AMinor = tonic DiatonicScale.AMinor
    let BMajor = tonic DiatonicScale.BMajor
    let BMinor = tonic DiatonicScale.BMinor