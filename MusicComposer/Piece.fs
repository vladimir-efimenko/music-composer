namespace MusicComposer

/// Represents a musical piece which contains a list of measures
type Piece(name:string, measures: Measure ResizeArray) = 
    member val Name = name
    member val Measures = measures
    new (name:string) = Piece(name, ResizeArray()) 

