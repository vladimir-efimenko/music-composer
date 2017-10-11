namespace MusicComposer

type Octave = C0 = 0| C1 = 1 | C2 = 2| C3 =3 | C4 = 4 | C5 = 5 | C6 = 6 | C7 = 7 | C8 = 8 | C9 = 9 

module Octave = 

    let next (octave:Octave) : Octave option = if int octave = 9 then None else Some((int octave) + 1 |> enum)
    let prev (octave:Octave) : Octave option = if int octave = 0 then None else Some((int octave) - 1 |> enum)