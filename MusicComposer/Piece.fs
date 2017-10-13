namespace MusicComposer

type Piece(name:string, measures: Measure ResizeArray) = 
    member val Name = name
    member val Measures = measures
    new (name:string) = Piece(name, ResizeArray()) 

