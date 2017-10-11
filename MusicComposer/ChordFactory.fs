namespace MusicComposer

module ChordFactory =

    let tonic scale = 
        [
            Array.get scale 0
            { Array.get scale 2 with Chord = true } 
            { Array.get scale 4 with Chord = true }
        ]   

    let CMajor = tonic DiatonicScale.CMajor
    let CMinor = tonic DiatonicScale.CMinor
    let DMajor =  tonic DiatonicScale.DMajor
    let DMinor = tonic DiatonicScale.DMinor
    let EMajor = tonic DiatonicScale.EMajor
    let EMinor = tonic DiatonicScale.EMinor