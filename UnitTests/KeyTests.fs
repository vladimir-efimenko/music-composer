namespace MusicComposer

module KeyTests =

    open NUnit.Framework

    [<Test>]
    let ``keyAlters for CMajor has neither flats nor sharps``() =
        let alters = Map.find KeySignature.C Key.keyAlters

        Assert.IsTrue(alters |> Seq.forall (fun x -> snd x = NoteAlter.Natural))

    [<Test>]
    let ``keyAlters for CMinor has 3 flats of B E A``() =
        let alters = Map.find KeySignature.c Key.keyAlters |> Seq.filter (fun n -> snd n = NoteAlter.Flat)

        Assert.AreEqual(3, Seq.length alters, "Should be 3 flats")
        Assert.IsTrue(alters |> Seq.exists (fun x -> fst x = NoteName.B), "B should have flat")
        Assert.IsTrue(alters |> Seq.exists (fun x -> fst x = NoteName.E), "E should have flat")
        Assert.IsTrue(alters |> Seq.exists (fun x -> fst x = NoteName.A), "A should have flat")


    [<Test>]
    let ``keyAlters for BMinor has 2 sharps of F C``() =
        let alters = Map.find KeySignature.b Key.keyAlters |> Seq.filter (fun n -> snd n = NoteAlter.Sharp)

        Assert.AreEqual(2, Seq.length alters, "Should be 2 sharps")
        Assert.IsTrue(alters |> Seq.exists (fun x -> fst x = NoteName.F), "B should have sharp")
        Assert.IsTrue(alters |> Seq.exists (fun x -> fst x = NoteName.C), "E should have sharp")