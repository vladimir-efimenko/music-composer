#r "System.Xml"
#r "System.Xml.Linq"

#load @"C:\Users\Alena\source\repos\MusicComposer\MusicComposer\Note.fs"
#load @"C:\Users\Alena\source\repos\MusicComposer\MusicComposer\Measure.fs"
#load @"C:\Users\Alena\source\repos\MusicComposer\MusicComposer\NoteFactory.fs"
#load @"C:\Users\Alena\source\repos\MusicComposer\MusicComposer\ChordFactory.fs"
#load @"C:\Users\Alena\source\repos\MusicComposer\MusicComposer\Scale.fs"
#load @"C:\Users\Alena\source\repos\MusicComposer\MusicComposer\MusicXMLWriter.fs"

open MusicComposer

MusicXMLWriter.write ([ Measure((4,4), Scale.CMajor |> Seq.map (fun n -> Note(pitch = n.Pitch, duration = Duration.Eighth)));
                        Measure((13,4), Scale.CChromatic |> Seq.take 13);
                        Measure((13,4), Scale.CChromatic |> Seq.skip 12 |> Seq.take 13);
                        Measure((2,4), Seq.append ChordFactory.CMajor ChordFactory.CMinor, Key(-3, KeyType.Minor))
                      ]) "d:/temp.xml"