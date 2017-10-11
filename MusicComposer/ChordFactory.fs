namespace MusicComposer

module ChordFactory =

    let tonic (scale: Note array) = 
        [
            Array.get scale 0
            (Array.get scale 2).MakeChord() 
            (Array.get scale 4).MakeChord()
        ]   

    let CMajor = tonic DiatonicScale.CMajor
    let CMinor = tonic DiatonicScale.CMinor
    let DMajor =  tonic DiatonicScale.DMajor
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