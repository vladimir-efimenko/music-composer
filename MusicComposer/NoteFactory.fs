namespace MusicComposer
open System

module NoteFactory =

    let private randNotes = Random()

    let c1 = Note({ Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C4}, Duration.Quarter)
    let c2 = Note({ Name = NoteName.C; Alter = NoteAlter.Natural; Octave = Octave.C5}, Duration.Quarter)

    let getNote note duration octave alter = Note({ Name = note; Alter = alter; Octave = octave}, duration)

    let ``16th`` note octave = getNote note Duration.``16th`` octave NoteAlter.Natural

    let ``16thSharp`` note octave = getNote note Duration.``16th`` octave NoteAlter.Sharp

    let ``16thFlat`` note octave = getNote note Duration.``16th`` octave NoteAlter.Flat

    let ``8th`` note octave = getNote note Duration.Eighth octave NoteAlter.Natural

    let ``8thSharp`` note octave = getNote note Duration.Eighth octave NoteAlter.Sharp

    let ``8thFlat`` note octave = getNote note Duration.Eighth octave NoteAlter.Flat
    
    let ``4th`` note octave = getNote note Duration.Quarter octave NoteAlter.Natural

    let ``4thSharp`` note octave = getNote note Duration.Quarter octave NoteAlter.Sharp

    let ``4thFlat`` note octave = getNote note Duration.Quarter octave NoteAlter.Flat

    let random octave = ``16th`` (randNotes.Next(0, 7) |> enum) octave