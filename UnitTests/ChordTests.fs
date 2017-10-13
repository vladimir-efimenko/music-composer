namespace MusicComposer

module ChordTests =
    open NUnit.Framework

    [<Test>]
    let ``Second and third notes in chord have chord flag on``() = 
        let cMaj = DiatonicScale.CMajor

        let tonic = ChordFactory.tonic cMaj |> ChordFactory.makeChord

        Assert.IsFalse((Seq.head tonic).Chord, "First sound")
        Assert.IsTrue((Seq.tail tonic |> Seq.head).Chord, "Second sound")
        Assert.IsTrue((Seq.last tonic).Chord, "Third sound")

    [<Test>]
    let ``Tonic chord is C E G for CMajor``() = 
        let cMaj = DiatonicScale.CMajor

        let tonic = ChordFactory.tonic cMaj 

        Assert.AreEqual((DiatonicScale.tonic cMaj).Pitch, tonic.Item(0).Pitch, "Tonic sound")
        Assert.AreEqual((DiatonicScale.mediant cMaj).Pitch, tonic.Item(1).Pitch, "Mediant sound")
        Assert.AreEqual((DiatonicScale.dominant cMaj).Pitch, tonic.Item(2).Pitch, "Dominant sound")

    [<Test>]
    let ``Subdominant chord is F Ab C for CMinor``() = 
        let cMin = DiatonicScale.CMinor

        let sub = ChordFactory.subdominant cMin 

        Assert.AreEqual({ Name = NoteName.F; Alter = NoteAlter.Natural; Octave = Octave.C4 }, sub.Item(0).Pitch, "First sound")
        Assert.AreEqual({ Name = NoteName.A; Alter = NoteAlter.Flat; Octave = Octave.C4 }, sub.Item(1).Pitch, "Second sound")
        Assert.AreEqual({ Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C5 }, sub.Item(2).Pitch, "Third sound")

    [<Test>]
    let ``Dominant chord is A C# E for DMajor``() = 
        let dMaj = DiatonicScale.DMajor

        let dom = ChordFactory.dominant dMaj 

        Assert.AreEqual({ Name = NoteName.A; Alter = NoteAlter.Natural; Octave = Octave.C4 }, dom.Item(0).Pitch, "First sound")
        Assert.AreEqual({ Name = NoteName.C; Alter = NoteAlter.Sharp; Octave = Octave.C5 }, dom.Item(1).Pitch, "Second sound")
        Assert.AreEqual({ Name = NoteName.E; Alter = NoteAlter.Natural; Octave = Octave.C5 }, dom.Item(2).Pitch, "Third sound")