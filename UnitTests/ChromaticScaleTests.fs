namespace MusicComposer

module ChromaticScaleTests = 
    open NUnit.Framework

    [<Test>]
    let ``ChromaticScale next pitch after C should be C#``() =
        let pitch = ChromaticScale.nextChromaticPitch { Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C0 }

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({p with Alter = NoteAlter.Sharp}, p) 
        

    [<Test>]
    let ``ChromaticScale next pitch after C# should be D``() =
        let csharp = { Name = NoteName.C; Alter = NoteAlter.Sharp; Octave = Octave.C0 }
        let pitch = ChromaticScale.nextChromaticPitch csharp
        
        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({p  with Alter = NoteAlter.Natural; Name = NoteName.D}, p)

    [<Test>]
    let ``ChromaticScale next pitch after D should be D#``() =
        let pitch = ChromaticScale.nextChromaticPitch { Name = NoteName.D; Alter = NoteAlter.Natural; Octave = Octave.C0 }
        
        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({p with Alter = NoteAlter.Sharp}, p)

    [<Test>]
    let ``ChromaticScale next pitch after D# should be E``() =
        let dsharp = { Name = NoteName.D; Alter = NoteAlter.Sharp; Octave = Octave.C0 }
        let pitch = ChromaticScale.nextChromaticPitch dsharp

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({p with Alter = NoteAlter.Natural}, p)

    [<Test>]
    let ``ChromaticScale next pitch after E should be F``() =
        let pitch = ChromaticScale.nextChromaticPitch { Name = NoteName.E; Alter = NoteAlter.Natural; Octave = Octave.C0 }
        
        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({p with Name = NoteName.F }, p)
    
    [<Test>]
    let ``ChromaticScale next pitch after F# should be G``() =
        let fsharp = { Name = NoteName.F; Alter = NoteAlter.Sharp; Octave = Octave.C0 }
        let pitch = ChromaticScale.nextChromaticPitch fsharp

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({p with Alter = NoteAlter.Natural; Name = NoteName.G }, p)


    [<Test>]
    let ``ChromaticScale next pitch after G# should be A``() =
        let gsharp = { Name = NoteName.G; Alter = NoteAlter.Sharp; Octave = Octave.C0 }
        let pitch = ChromaticScale.nextChromaticPitch gsharp

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({ p with Alter = NoteAlter.Natural; Name = NoteName.A }, p)

    [<Test>]
    let ``ChromaticScale next pitch after B should be C with a higher octave``() = 
        let b = {Name = NoteName.B; Alter = NoteAlter.Natural; Octave = Octave.C0}
        let pitch = ChromaticScale.nextChromaticPitch b

        Assert.AreEqual(Some {Octave = Octave.C1; Alter = NoteAlter.Natural; Name = NoteName.C}, pitch)
