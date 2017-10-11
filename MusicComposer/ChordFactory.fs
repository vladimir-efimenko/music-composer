namespace MusicComposer

module ChordFactory =

    let tonic (scale:Note seq) = 
        let arr = scale |> Seq.toArray
        [
            Array.get arr 0
            { Array.get arr 2 with Chord = true } 
            { Array.get arr 4 with Chord = true }
         ]   

    let CMajor = tonic DiatonicScale.CMajor
    let CMinor = tonic DiatonicScale.CMinor
    let DMajor =  tonic DiatonicScale.DMajor
    let DMinor = tonic DiatonicScale.DMinor
    let EMajor = tonic DiatonicScale.EMajor
    let EMinor = tonic DiatonicScale.EMinor