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

Piece("MUSICC!", ResizeArray([Measure((4,4), 
                                    [
                                        NoteFactory.B4.WithDuration Duration.Eighth
                                        NoteFactory.G4.WithDuration Duration.Eighth
                                        NoteFactory.B4.WithDuration Duration.Eighth
                                        NoteFactory.G4.WithDuration Duration.Eighth
                                        NoteFactory.C5.WithDuration Duration.Eighth
                                        NoteFactory.B4.WithDuration Duration.Eighth
                                        NoteFactory.A4.WithDuration Duration.Half
                                        NoteFactory.D4.WithDuration Duration.Eighth
                                        NoteFactory.D4.WithDuration Duration.Eighth
                                        NoteFactory.D4.WithDuration Duration.Eighth
                                        NoteFactory.D4.WithDuration Duration.Eighth
                                        NoteFactory.G4.WithDuration Duration.Eighth
                                        NoteFactory.G4.WithDuration Duration.Eighth
                                        NoteFactory.G4.WithDuration Duration.Half
                                    ], Key.GMajor)]))

|> MusicXMLWriter.write @"C:\Users\YEFVOL\Documents\temp.xml" 