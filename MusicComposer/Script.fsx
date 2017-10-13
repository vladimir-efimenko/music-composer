#r "System.Xml"
#r "System.Xml.Linq"

#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Octave.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Note.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Key.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Measure.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Piece.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\NoteFactory.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\DiatonicScale.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\ChromaticScale.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\ChordFactory.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\MusicXMLWriter.fs"

open MusicComposer

let melody = [
                NoteFactory.B4.WithDuration Duration.Eighth
                NoteFactory.G4.WithDuration Duration.Eighth
                NoteFactory.B4.WithDuration Duration.Eighth
                NoteFactory.G4.WithDuration Duration.Eighth
                NoteFactory.C5.WithDuration Duration.Eighth
                NoteFactory.B4.WithDuration Duration.Eighth
                NoteFactory.A4.WithDuration Duration.Quarter
                NoteFactory.D4.WithDuration Duration.Eighth
                NoteFactory.D4.WithDuration Duration.Eighth
                NoteFactory.D4.WithDuration Duration.Eighth
                NoteFactory.E4.WithDuration Duration.``16th``
                NoteFactory.F4Sharp.WithDuration Duration.``16th``
                NoteFactory.G4.WithDuration Duration.Eighth
                NoteFactory.G4.WithDuration Duration.Eighth
                NoteFactory.G4.WithDuration Duration.Quarter
            ]

Piece("MUSICC!", ResizeArray [Measure((4,4),  melody |> Seq.take 7, Key.GMajor); Measure( (4,4), melody |> Seq.skip 7 |> Seq.take 8, Key.GMajor)] )

|> MusicXMLWriter.write @"C:\Users\YEFVOL\Documents\temp.xml" 