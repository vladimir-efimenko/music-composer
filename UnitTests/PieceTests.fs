namespace MusicComposer

module PieceTests = 
    open NUnit.Framework

    [<Test>]
    let ``Piece can hold a list of measures``() = 
        let piece = Piece("Music piece")
        let measure = Measure((4,4), [NoteFactory.C4; NoteFactory.D4; NoteFactory.E4; NoteFactory.F4])

        piece.Measures.Add measure

        Assert.AreEqual(1, piece.Measures.Count)
        Assert.AreEqual(measure, piece.Measures.Item 0)
        
    
    [<Test>]
    let ``Can read XML file``() = 
        
        let p = MusicXMLReader.read "temp.xml"

        Assert.AreEqual("MUSICC!", p.Name)
        Assert.IsNotNull(p.Measures, "Measures cannot be null")
        Assert.AreEqual(2, p.Measures.Count, "Measures count")
