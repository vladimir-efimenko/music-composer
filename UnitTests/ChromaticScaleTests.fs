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

    [<Test>]
    let ``ChromaticScale next pitch after B C9 should be None``() = 
        let c = {Name = NoteName.B; Alter = NoteAlter.Natural; Octave = Octave.C9}

        Assert.AreEqual(None, ChromaticScale.nextChromaticPitch c)

    [<Test>]
    let ``ChromaticScale prev pitch after C should be B with a lower octave``() = 
        let c = {Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C1}
        let pitch = ChromaticScale.prevChromaticPitch c

        Assert.AreEqual(Some {Octave = Octave.C0; Alter = NoteAlter.Natural; Name = NoteName.B}, pitch)

    [<Test>]
    let ``ChromaticScale prev pitch before C C0 should be None``() = 
        let c = {Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C0}

        Assert.AreEqual(None, ChromaticScale.prevChromaticPitch c)

    [<Test>]
    let ``ChromaticScale prev pitch before Bb should be A``() = 
        let c = {Name = NoteName.B; Alter = NoteAlter.Flat; Octave = Octave.C1}
        let pitch = ChromaticScale.prevChromaticPitch c

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({ p with Alter = NoteAlter.Natural; Name = NoteName.A }, p)

    [<Test>]
    let ``ChromaticScale prev pitch before F should be E``() = 
        let c = {Name = NoteName.F; Alter = NoteAlter.Natural; Octave = Octave.C1}
        let pitch = ChromaticScale.prevChromaticPitch c

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({ p with Alter = NoteAlter.Natural; Name = NoteName.E }, p)

    [<Test>]
    let ``ChromaticScale prev pitch before G should be Gb``() = 
        let c = {Name = NoteName.G; Alter = NoteAlter.Natural; Octave = Octave.C1}
        let pitch = ChromaticScale.prevChromaticPitch c

        match pitch with 
            None -> Assert.Fail("Pitch cannot be None")
            | Some(p) -> Assert.AreEqual({ p with Alter = NoteAlter.Flat }, p)

    [<Test>]
    let ``ChromaticScale CChromaticAscending contains 13 notes``() =
        Assert.AreEqual(13, Seq.length ChromaticScale.CChromaticAscending)

    [<Test>]
    let ``ChromaticScale CChromaticAscending contains correct ascending pitches``() =
        let up = [
            (NoteName.C, NoteAlter.Natural)
            (NoteName.C, NoteAlter.Sharp)
            (NoteName.D, NoteAlter.Natural)
            (NoteName.D, NoteAlter.Sharp)
            (NoteName.E, NoteAlter.Natural)
            (NoteName.F, NoteAlter.Natural)
            (NoteName.F, NoteAlter.Sharp)
            (NoteName.G, NoteAlter.Natural)
            (NoteName.G, NoteAlter.Sharp)
            (NoteName.A, NoteAlter.Natural)
            (NoteName.A, NoteAlter.Sharp)
            (NoteName.B, NoteAlter.Natural)
            (NoteName.C, NoteAlter.Natural)
            ]
        Assert.AreEqual(up, 
            ChromaticScale.CChromaticAscending 
            |> Seq.map (fun note -> note.Pitch.Name, note.Pitch.Alter)
            |> Seq.toList)

    [<Test>]
    let ``ChromaticScale CChromaticDescending contains 13 notes``() =
        Assert.AreEqual(13, Seq.length ChromaticScale.CChromaticDescending)

    [<Test>]
    let ``ChromaticScale CChromaticDescending contains correct descending pitches``() =
        let down = [
            (NoteName.C, NoteAlter.Natural)
            (NoteName.B, NoteAlter.Natural)
            (NoteName.B, NoteAlter.Flat)
            (NoteName.A, NoteAlter.Natural)
            (NoteName.A, NoteAlter.Flat)
            (NoteName.G, NoteAlter.Natural)
            (NoteName.G, NoteAlter.Flat)
            (NoteName.F, NoteAlter.Natural)
            (NoteName.E, NoteAlter.Natural)
            (NoteName.E, NoteAlter.Flat)
            (NoteName.D, NoteAlter.Natural)
            (NoteName.D, NoteAlter.Flat)
            (NoteName.C, NoteAlter.Natural)
            ]
        Assert.AreEqual(down, 
            ChromaticScale.CChromaticDescending 
            |> Seq.map (fun note -> note.Pitch.Name, note.Pitch.Alter)
            |> Seq.toList)