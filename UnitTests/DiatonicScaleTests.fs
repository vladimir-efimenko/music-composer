namespace UnitTests

module DiatonicScaleTests = 

    open MusicComposer
    open NUnit.Framework

    let pitch = { Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C4 }

    [<Test>]
    let ``CMajor Scale should contain C D E F G A B C notes``() = 
        Assert.AreEqual(8, Seq.length DiatonicScale.CMajor, "Wrong count of notes")

        Assert.AreEqual(pitch, (Seq.head DiatonicScale.CMajor).Pitch, "First note should be C")
        Assert.AreEqual({ pitch with Name = NoteName.D }, (Seq.item 1 DiatonicScale.CMajor).Pitch, "2nd note should be D")
        Assert.AreEqual({ pitch with Name = NoteName.E }, (Seq.item 2 DiatonicScale.CMajor).Pitch, "3rd note should be E")
        Assert.AreEqual({ pitch with Name = NoteName.F }, (Seq.item 3 DiatonicScale.CMajor).Pitch, "4th note should be F")
        Assert.AreEqual({ pitch with Name = NoteName.G }, (Seq.item 4 DiatonicScale.CMajor).Pitch, "5th note should be G")
        Assert.AreEqual({ pitch with Name = NoteName.A }, (Seq.item 5 DiatonicScale.CMajor).Pitch, "6th note should be A")
        Assert.AreEqual({ pitch with Name = NoteName.B }, (Seq.item 6 DiatonicScale.CMajor).Pitch, "7th note should be B")
        Assert.AreEqual({ pitch with Name = NoteName.C; Octave = Octave.C5 }, (Seq.last DiatonicScale.CMajor).Pitch, "Last note should be C")

    
    [<Test>]
    let ``DMajor Scale should contain D E F# G A B C# E notes``() = 
        Assert.AreEqual(8, Seq.length DiatonicScale.DMajor, "Wrong count of notes")

        Assert.AreEqual({ pitch with Name = NoteName.D }, (Seq.head DiatonicScale.DMajor).Pitch, "First note should be D")
        Assert.AreEqual({ pitch with Name = NoteName.E }, (Seq.item 1 DiatonicScale.DMajor).Pitch, "2nd note should be E")
        Assert.AreEqual({ pitch with Name = NoteName.F; Alter = NoteAlter.Sharp }, (Seq.item 2 DiatonicScale.DMajor).Pitch, "3rd note should be F#")
        Assert.AreEqual({ pitch with Name = NoteName.G }, (Seq.item 3 DiatonicScale.DMajor).Pitch, "4th note should be G")
        Assert.AreEqual({ pitch with Name = NoteName.A }, (Seq.item 4 DiatonicScale.DMajor).Pitch, "5th note should be A")
        Assert.AreEqual({ pitch with Name = NoteName.B }, (Seq.item 5 DiatonicScale.DMajor).Pitch, "6th note should be B")
        Assert.AreEqual({ pitch with Name = NoteName.C; Alter = NoteAlter.Sharp; Octave = Octave.C5 }, (Seq.item 6 DiatonicScale.DMajor).Pitch, "7th note should be C#")
        Assert.AreEqual({ pitch with Name = NoteName.D; Octave = Octave.C5 }, (Seq.last DiatonicScale.DMajor).Pitch, "Last note should be D")