namespace MusicComposer

module PieceTests = 
    open NUnit.Framework

    [<Test>]
    let ``Piece can hold a list of measures``() = 
        let piece = Piece("Music piece")
        let measure = Measure((4,4), [NoteFactory.])
        
