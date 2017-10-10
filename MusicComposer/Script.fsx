#r "System.Xml"
#r "System.Xml.Linq"

#load @"D:\Development\MusicComposer\MusicComposer\Note.fs"
#load @"D:\Development\MusicComposer\MusicComposer\Measure.fs"
#load @"D:\Development\MusicComposer\MusicComposer\NoteFactory.fs"
#load @"D:\Development\MusicComposer\MusicComposer\ChordFactory.fs"
#load @"D:\Development\MusicComposer\MusicComposer\Scale.fs"
#load @"D:\Development\MusicComposer\MusicComposer\MusicXMLWriter.fs"

open MusicComposer

MusicXMLWriter.write ([ Measure((4,4), Scale.CMajor |> Seq.map (fun n -> Note(pitch = n.Pitch, duration = Duration.Eighth)));
                        Measure((13,4), Scale.CChromatic |> Seq.take 13);
                        Measure((13,4), Scale.CChromatic |> Seq.skip 12 |> Seq.take 13);
                        Measure((2,4), Seq.append ChordFactory.CMajor ChordFactory.CMinor, Key(-3, KeyType.Minor))
                      ]) "d:/temp.xml"